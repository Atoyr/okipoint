using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Blockchain.Api.Utility;
using System.Collections.ObjectModel;

namespace Blockchain.Api.Models
{
    public class Transaction
    {
        private Transaction() { }

        public static Transaction NewTransaction(ICollection<Input> inputs,ICollection<Output> outputs)
        {
            if (inputs is null) throw new NullReferenceException(nameof(inputs));
            if(outputs is null) throw new NullReferenceException(nameof(outputs));

            var tx = new Transaction();
            tx.Timestamp = DateTime.UtcNow;

            // Input,Output検証
            Coin value = 0;
            string sender;
            string recipient;

            foreach(Input i in inputs)
            {
                value += i.PreviousOutput.Value;
                throw new ArgumentException(nameof(inputs));
            }


            return tx;
        }

        public int Version { get; private set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public int Amount { get; set; }

        public byte[] DigitalSignature { set; get; }
        public byte[] PublicKey { set; get; }

        public DateTime Timestamp { get; private set; }

        public int InputCount { get => Inputs?.Count ?? 0; }
        public int OutputCount { get => Outputs?.Count ?? 0; }

        public ReadOnlyCollection<Input> Inputs { get; private set; }
        public ReadOnlyCollection<Output> Outputs { get; private set; }

        public byte[] ToBytes()
        {
            var bytes = new List<byte>();
            //bytes.AddRange(Sender);
            //bytes.AddRange(Recipient);
            //bytes.AddRange(BitConverter.GetBytes(Amount));
            return Hash.GetHash<HMACSHA256>(bytes.ToArray()); 
        }
    }
}
