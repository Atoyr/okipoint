using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Model
{
    public class Transaction
    {
        public byte[] Sender { get; set; }
        public byte[] Recipient { get; set; }
        public int Amount { get; set; }
        //public object Data { get; set; }

        public byte[] ToBytes()
        {
            var sha256 = new SHA256Managed();
            var bytes = new List<byte>();
            bytes.AddRange(Sender);
            bytes.AddRange(Recipient);
            bytes.AddRange(BitConverter.GetBytes(Amount));
            //if(Data != null)bytes.AddRange(BitConverter.GetBytes(Data.GetHashCode()));
            return sha256.ComputeHash(bytes.ToArray());
        }
    }
}
