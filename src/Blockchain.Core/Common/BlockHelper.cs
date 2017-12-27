using Blockchain.Core.Models;
using Blockchain.Core.Utility;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Blockchain.Core.Common
{
    public static class BlockHelper
    {
        public static string GetHash(Block block) => GetHash(block.PreviousHash, block.Transactions, block.Nonce);

        public static string GetHash(string previousHash, IList<Transaction> txs, int nonce)
        {
            var bytes = new List<byte>();
            bytes.AddRange(Encoding.ASCII.GetBytes(previousHash));
            //bytes.AddRange(BitConverter.GetBytes(timestamp.ToUniversalTime().ToBinary()));
            foreach (Transaction t in txs)
            {
                bytes.AddRange(t.ToBytes());
            }
            bytes.AddRange(BitConverter.GetBytes(nonce));
            return Encoding.ASCII.GetString(Hash.GetHashToByte<SHA256Managed>(bytes.ToArray()));
        }


        public static bool IsValidBlock(Block previousBlock,Block block)
        {
            var prevHash = GetHash(previousBlock);
            if (block.PreviousHash != prevHash) return false;
            return GetHash(block).StartsWith(new string('0', block.Difficult));
        }
        public static bool IsValidBlock(Block previousBlock, string previousHash, IList<Transaction> txs, int nonce, int difficult)
        {
            var prevHash = GetHash(previousBlock);
            if (previousHash != prevHash) return false;
            return GetHash(previousHash,txs,nonce).StartsWith(new string('0', difficult));
        }

    }
}
