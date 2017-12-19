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

        /// <summary>
        /// Output virtual address
        /// </summary>
        public string Address { get; private set; }

        /// <summary>
        /// Transaction index
        /// </summary>
        public long TxIndex { get; private set; }


        public string Script { get; private set; }

        /// <summary>
        /// Do this transaction spent
        /// </summary>
        public bool Spent { get; private set; }
    }
}