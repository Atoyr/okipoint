using Blockchain.Core.Events;
using Blockchain.Core.Models;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Blockchain.Core.Common
{
    public class BlockchainCliant
    {
        #region Private Variable Property
        /// <summary>
        /// Transaction the instance is pooling
        /// Include this transaction when issuing blocks
        /// </summary>
        private List<Transaction> _transactionPool = new List<Transaction>();
        /// <summary>
        /// Blocks chain this instance has
        /// </summary>
        private List<Block> _chain = new List<Block>();
        /// <summary>
        /// Other BlockChain Instance Nodes
        /// </summary>
        private List<Node> _nodes = new List<Node>();
        /// <summary>
        /// Last of the BlockChain this instance has
        /// </summary>
        private Block _lastBlock => _chain.Last();
        /// <summary>
        /// UTXO Collection
        /// </summary>
        private ConcurrentDictionary<string,Output> _utxoTable;
        /// <summary>
        /// This private instance
        /// </summary>
        private static BlockchainCliant _instance;

        #endregion

        #region Public Variable Property
        /// <summary>
        /// This BlockChain Instance Id
        /// </summary>
        public string NodeId { get; private set; }

        /// <summary>
        /// BlockChain singleton Instance
        /// </summary>
        public static BlockchainCliant Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BlockchainCliant();
                }
                return _instance;
            }
        }

        #endregion

        #region Event

        public event EventHandler<TransactionEventArgs> TransactionAdding;
        public event EventHandler<TransactionEventArgs> TransactionAdded;

        protected virtual void OnTransactionAdding(TransactionEventArgs e) => TransactionAdding?.Invoke(this,e);
        protected virtual void OnTransactionAdded(TransactionEventArgs e) => TransactionAdded?.Invoke(this, e);

        #endregion

        #region Constractor
        private BlockchainCliant()
        {
            NodeId = Guid.NewGuid().ToString().Replace("-", "");
            _nodes = new List<Node>();//TODO
            //CreateNewBlock(nonce: 100, previousHash: null); //genesis block
            _utxoTable = new ConcurrentDictionary<string,Output>();
        }
        #endregion

        #region private method
        /// <summary>
        /// Regist new node
        /// </summary>
        /// <param name="address">Regist node address</param>
        private void RegisterNode(string address)
        {
            _nodes.Add(new Node { Address = new Uri(address) });
        }

        /// <summary>
        /// Confirm chains integrity
        /// </summary>
        /// <param name="chain">Confirm chains</param>
        /// <returns>Confirm result</returns>
        private bool IsValidChain(List<Block> chain)
        {
            Block prevBlock = chain.First();
            Block block = null;
            int currentIndex = 1;
            while (currentIndex < chain.Count)
            {
                block = chain.ElementAt(currentIndex);
                Debug.WriteLine($"{prevBlock}");
                Debug.WriteLine($"{block}");
                Debug.WriteLine("----------------------------");

                if (!BlockHelper.IsValidBlock(prevBlock, block)) return false;

                prevBlock = block;
                currentIndex++;
            }
            return true;
        }

        #endregion

        #region public methid

        /// <summary>
        /// test method
        /// </summary>
        /// <param name="o"></param>
        public void AddUtxo(Output o)
        {
            _utxoTable.AddOrUpdate(o.OutputId,o,(x,y) => o);
        }

        /// <summary>
        /// Add transaction
        /// </summary>
        /// <param name="tran">Transaction</param>
        public void AddTransaction(Transaction tran)
        {
            OnTransactionAdding(new TransactionEventArgs() { Transaction = tran });
            foreach (Input i in tran.Inputs)
            {
                if(!_utxoTable.Remove(i.PreviousOutput.OutputId, out var o))
                {
                    throw new ArgumentException(nameof(tran));
                }
            }
            foreach (Output o in tran.Outputs)
            {
                _utxoTable.AddOrUpdate(o.OutputId,o,(x,y) => o);
            }
            _transactionPool.Add(tran);
            OnTransactionAdded(new TransactionEventArgs() { Transaction = tran });
        }

        public decimal GetBalance(string address)
        {
            return _utxoTable.Where(x => x.Value.Address == address).Sum(x => x.Value.Value);
        }

        /// <summary>
        /// Get blockchain tail
        /// </summary>
        /// <returns>Tail Block</returns>
        public Block GetLastBlock() => _chain.Last();

        #endregion

        #region static method

        public static Block CreateNewBlock(int nonce, string previousHash = null)
        {
            if (previousHash is null || BlockHelper.IsValidBlock(Instance._chain.Last(), previousHash, Instance._transactionPool, nonce, 0/*difficult*/))
            {
                var block = new Block(Instance._transactionPool)
                {
                    Index = Instance._chain.Count,
                    Timestamp = DateTime.UtcNow,
                    PreviousHash = previousHash ?? BlockHelper.GetHash(Instance._chain.Last())
                };
                Instance._transactionPool.Clear();
                Instance._chain.Add(block);
                return block;
            }
            return default(Block);
        }

        public static int Mining()
        {
            int nonce = 0;
            while (!BlockHelper.IsValidBlock(
                        Instance._chain.Last(), 
                        BlockHelper.GetHash(Instance._chain.Last()),
                        Instance._transactionPool,
                        nonce,
                        1 /*difficult*/))
            {
                ++nonce;
            }
            return nonce;
        }
        #endregion

        ////web server calls
        //internal string Mine()
        //{
        //    int proof = CreateProofOfWork(_lastBlock.Proof, _lastBlock.PreviousHash);

        //    CreateTransaction(sender: "0", recipient: NodeId, amount: 1);
        //    Block block = CreateNewBlock(proof /*, _lastBlock.PreviousHash*/);

        //    var response = new
        //    {
        //        Message = "New Block Forged",
        //        Index = block.Index,
        //        Transactions = block.Transactions.ToArray(),
        //        Proof = block.Proof,
        //        PreviousHash = block.PreviousHash
        //    };

        //    return JsonConvert.SerializeObject(response);
        //}

        //internal string GetFullChain()
        //{
        //    var response = new
        //    {
        //        chain = _chain.ToArray(),
        //        length = _chain.Count
        //    };

        //    return JsonConvert.SerializeObject(response);
        //}

        //internal string RegisterNodes(string[] nodes)
        //{
        //    var builder = new StringBuilder();
        //    foreach (string node in nodes)
        //    {
        //        string url = $"http://{node}";
        //        RegisterNode(url);
        //        builder.Append($"{url}, ");
        //    }

        //    builder.Insert(0, $"{nodes.Count()} new nodes have been added: ");
        //    string result = builder.ToString();
        //    return result.Substring(0, result.Length - 2);
        //}

        //internal string Consensus()
        //{
        //    bool replaced = ResolveConflicts();
        //    string message = replaced ? "was replaced" : "is authoritive";

        //    var response = new
        //    {
        //        Message = $"Our chain {message}",
        //        Chain = _chain
        //    };

        //    return JsonConvert.SerializeObject(response);
        //}

        //internal int CreateTransaction(string sender, string recipient, int amount)
        //{
        //    var transaction = new Transaction
        //    {
        //        Sender = sender,
        //        Recipient = recipient,
        //        Amount = amount
        //    };

        //    _currentTransactions.Add(transaction);

        //    return _lastBlock != null ? _lastBlock.Index + 1 : 0;
        //}
    }
}
