using Blockchain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blockchain.Core.Events
{
    public class TransactionEventArgs : EventArgs
    {
        public Transaction Transaction { get; set; }
    }
}
