using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Blockchain.Api.Models
{
    public class Output
    {
        private Output() { }

        /// <summary>
        /// Output virtual address
        /// </summary>
        public string Address { get; private set; }

        /// <summary>
        /// Issue Amount
        /// </summary>
        public decimal Value { get; private set; }

        /// <summary>
        /// Script
        /// </summary>
        public string Script { get; private set; }

        /// <summary>
        /// Is this transaction spent
        /// </summary>
        public bool Spent { get; private set; }
    }
}