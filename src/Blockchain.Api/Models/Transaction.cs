using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Blockchain.Core.Utility;
using System.Collections.ObjectModel;

namespace Blockchain.Core.Models
{
    public class Transaction
    {
        private Transaction() { }

        internal Transaction(ICollection<Input> inputs, ICollection<Output> outputs)
        {
            if (inputs is null) throw new NullReferenceException(nameof(inputs));
            if (outputs is null) throw new NullReferenceException(nameof(outputs));
            Timestamp = DateTime.UtcNow;
            TxIndex = Guid.NewGuid().ToString().Replace("-", "");
            Inputs = new ReadOnlyCollection<Input>(inputs.ToList());
            Outputs = new ReadOnlyCollection<Output>(outputs.ToList());
        }

        public int Version { get; private set; }
        public string TxIndex { get; private set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public DateTime Timestamp { get; private set; }

        public string DigitalSignature { set; get; }
        public string PublicKey { set; get; }

        public int InputCount { get => Inputs?.Count ?? 0; }
        public int OutputCount { get => Outputs?.Count ?? 0; }
        public ReadOnlyCollection<Input> Inputs { get; private set; }
        public ReadOnlyCollection<Output> Outputs { get; private set; }

        public byte[] ToBytes()
        {
            var bytes = new List<byte>();
            bytes.addrange(sender);
            bytes.addrange(recipient);
            //bytes.AddRange(BitConverter.GetBytes(Amount));
            return Hash.GetHash<HMACSHA256>(bytes.ToArray()); 
        }
    }
}
