using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blockchain.Core.Models;

namespace Blockchain.Core.Common
{
    public static class TransactionHelper
    {
        public static Transaction CreateTransaction(ICollection<Input> inputs, ICollection<Output> outputs) => new Transaction(inputs, outputs);

        public static (ICollection<Input> inputs, ICollection<Output> outputs) CreateIO(
            ICollection<Output> utxos, 
            string sender,
            string recipient, 
            decimal amount, 
            decimal commission)
        {
            if (amount < 0) throw new ArgumentException(nameof(amount));
            decimal temp = 0;
            foreach(Output o in utxos)
            {
                if (o.Spent) throw new ArgumentException(nameof(utxos));
                temp += o.Value;
            }
            if(temp < amount + commission) throw new ArgumentException(nameof(utxos));

            ICollection<Input> inputs = utxos.Select(x => new Input(x)).ToList();
            ICollection<Output> outputs = new List<Output>();
            outputs.Add(new Output(recipient, amount));
            outputs.Add(new Output(sender, temp - amount));
            return (inputs: inputs, outputs: outputs);
        }

        public static Output GetOutput(string address,decimal amount) => new Output(address, amount);
    }
}
