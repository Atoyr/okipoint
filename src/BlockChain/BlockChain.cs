﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using BlockChain.Model;

namespace BlockChain
{
    //public static const int HASH_SIZE = 256;
    public class BlockChain
    {
        private List<Transaction> _currentTransactions = new List<Transaction>();
        private List<Block> _chain = new List<Block>();
        private List<Node> _nodes = new List<Node>();
        private Block _lastBlock => _chain.Last();
        private static BlockChain _instance;

        public string NodeId { get; private set; }

        public static BlockChain Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BlockChain();
                }
                return _instance;
            }
        }

        public BlockChain()
        {
            NodeId = Guid.NewGuid().ToString().Replace("-", "");
            // TODO : Genesis Block 
            CreateNewBlock(proof: 100, previousHash: null); //genesis block
        }

        private void RegisterNode(string address)
        {
            _nodes.Add(new Node { Address = new Uri(address) });
        }

        /// <summary>
        /// Chainの整合性を確認
        /// </summary>
        /// <param name="chain"></param>
        /// <returns></returns>
        private bool IsValidChain(List<Block> chain)
        {
            Block block = null;
            Block lastBlock = chain.First();
            int currentIndex = 1;
            while (currentIndex < chain.Count)
            {
                block = chain.ElementAt(currentIndex);
                Debug.WriteLine($"{lastBlock}");
                Debug.WriteLine($"{block}");
                Debug.WriteLine("----------------------------");

                //Check that the hash of the block is correct
                //if (block.PreviousHash != lastBlock.Hash) return false;
                ////Check that the Proof of Work is correct
                //if (!IsValidProof(lastBlock.Proof, block.Proof, lastBlock.PreviousHash)) return false;

                lastBlock = block;
                currentIndex++;
            }
            return true;
        }

        public Transaction NewTransaction()
        {
            return null;
        }

        public byte[] GetHash()
        {
            return null;
        }

        public Block GetLastBlock()
        {
            return _chain.Last();
        }

        //private Block CreateNewBlock(int proof, byte[] previousHash = null)
        //{
        //    var block = new Block
        //    {
        //        Index = _chain.Count,
        //        Timestamp = DateTime.UtcNow,
        //        Transactions = _currentTransactions.ToList(),
        //        PreviousHash = previousHash ?? GetHash(_chain.Last())
        //    };

        //    _currentTransactions.Clear();
        //    _chain.Add(block);
        //    return block;
        //}

        //private int CreateProofOfWork(int lastProof, string previousHash)
        //{
        //    int proof = 0;
        //    //while (!IsValidProof(lastProof, proof, previousHash))
        //    //    proof++;

        //    return proof;
        //}

        private bool IsValidProof(int lastProof, int proof, byte[] previousHash)
        {
            //string guess = $"{lastProof}{proof}{previousHash}";
            //string result = GetSha256(guess);
            //return result.StartsWith("0000");
            return false;
        }

        #region static method

        public static byte[] GetHash(Block block)
        {
            return GetHash(block.PreviousHash,block.Timestamp,block.Transactions,block.Nonce);
        }

        public static byte[] GetHash(byte[] PreviousHash,DateTime Timestamp,List<Transaction> Transactions,int Nonce)
        {
            var bytes = new List<byte>();
            bytes.AddRange(PreviousHash);
            bytes.AddRange(BitConverter.GetBytes(Timestamp.ToUniversalTime().ToBinary()));
            foreach (Transaction t in Transactions)
            {
                bytes.AddRange(t.ToBytes());
            }
            bytes.AddRange(BitConverter.GetBytes(Nonce));
            return Util.Hash.GetHash<SHA256Managed>(bytes.ToArray());
        }

        public static Block CreateNewBlock(int proof, byte[] previousHash = null)
        {
            return new Block();
            //var block = new Block
            //{
            //    Index = _chain.Count,
            //    Timestamp = DateTime.UtcNow,
            //    Transactions = _currentTransactions.ToList(),
            //    PreviousHash = previousHash ?? GetHash(_chain.Last())
            //};

            //_currentTransactions.Clear();
            //_chain.Add(block);
            //return block;
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
