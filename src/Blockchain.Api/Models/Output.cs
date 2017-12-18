using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Blockchain.Api.Models
{
    public class Output
    {
        private Output()
        {

        }

        public string Address { get; private set; }

        public long TxIndex { get; private set; }

        public string Script { get; private set; }

        public bool Spent { get; private set; }
    }
}