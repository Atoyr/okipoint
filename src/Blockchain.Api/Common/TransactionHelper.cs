using System;
using System.Collections.Generic;
using System.Text;
using Blockchain.Api.Models;

namespace Blockchain.Api.Common
{
    public static class TransactionHelper
    {
        public static Transaction CreateTransaction(ICollection<Input> inputs, ICollection<Output> outputs) => new Transaction(inputs, outputs);
    }
}
