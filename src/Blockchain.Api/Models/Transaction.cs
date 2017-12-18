using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.;


namespace BlockChain.Model
{
    public class Transaction
    {
        public int Version { get; private set; }
        public byte[] Sender { get; set; }
        public byte[] Recipient { get; set; }
        public int Amount { get; set; }
        //public object Data { get; set; }

        public int InputCount { get; set; }
        public int OutputCount { get; set; }

        public int Input { set; get; }
        public int Output { set; get; }

        public byte[] DigitalSignature { set; get; }
        public byte[] PublicKey { set; get; }

        public DateTime Timestamp { get; }

        public byte[] ToBytes()
        {
            var bytes = new List<byte>();
            bytes.AddRange(Sender);
            bytes.AddRange(Recipient);
            bytes.AddRange(BitConverter.GetBytes(Amount));
            return Util.Hash.GetHash<SHA256Managed>(bytes.ToArray()); 
        }
    }
}
