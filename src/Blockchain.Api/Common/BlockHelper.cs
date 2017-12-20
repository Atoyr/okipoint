using Blockchain.Api.Models;
using Blockchain.Api.Utility;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Blockchain.Api.Common
{
    public static class BlockHelper
    {
        public static string GetHash(Block block)
        {
            var bytes = new List<byte>();
            bytes.AddRange(Encoding.ASCII.GetBytes(block.PreviousHash));
            bytes.AddRange(BitConverter.GetBytes(block.Timestamp.ToUniversalTime().ToBinary()));
            foreach (Transaction t in block.Transactions)
            {
                bytes.AddRange(t.ToBytes());
            }
            bytes.AddRange(BitConverter.GetBytes(block.Nonce));
            return Encoding.ASCII.GetString(Hash.GetHash<SHA256Managed>(bytes.ToArray()));
        }
    }
}
