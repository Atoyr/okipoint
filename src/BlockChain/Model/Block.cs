using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Model
{
    public class Block
    {
        public int Index { get; set; }
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime Timestamp { get; set; }
        public int Difficult { set; get; }
        public List<Transaction> Transactions { get; set; }
        public byte[] DigitalSignature { set; get; }
        public byte[] PublicKey { set; get; }
        public int Nonce { get; }
        public int Proof { get; set; }
        public byte[] PreviousHash { get; set; }
        public byte[] Hash
        {
            get
            {
                var sha256 = new SHA256Managed();
                var bytes = new List<byte>();
                bytes.AddRange(PreviousHash);
                bytes.AddRange(Id.ToByteArray());
                bytes.AddRange(BitConverter.GetBytes(Timestamp.ToUniversalTime().ToBinary()));
                foreach (Transaction t in Transactions)
                {
                    bytes.AddRange(t.ToBytes());
                }
                return sha256.ComputeHash(bytes.ToArray());
            }
        }

        public override string ToString()
        {
            return $"{Index} [{Timestamp.ToString("yyyy-MM-dd HH:mm:ss")}] Proof: {Proof} | Hash: {System.Text.Encoding.ASCII.GetString(Hash)} | PrevHash: {System.Text.Encoding.ASCII.GetString(PreviousHash)} | Trx: {Transactions.Count}";
        }
    }
}
