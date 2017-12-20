using System;
using System.Collections.Generic;
using System.Text;
using Blockchain.Api.Models;

namespace Blockchain.Api.Common
{
    public static class TransactionHelper
    {
        public static Transaction CreateTransaction(ICollection<Input> inputs, ICollection<Output> outputs)
        {
            decimal Amount = 0;

            foreach(Input i in inputs)
            {
                if (i.PreviousOutput.Value < 0) throw new ArgumentException(nameof(inputs));
                Amount += i.PreviousOutput.Value;
            }
            foreach (Output o in outputs)
            {
                if (o.Value < 0) throw new ArgumentException(nameof(outputs));
                Amount -= o.Value;
            }
            if (Amount < 0) throw new ArgumentException(nameof(inputs));
            return new Transaction(inputs, outputs);
        }
    }
}
