﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Blockchain.Core.Models
{
    public class Output
    {
        private Output() { }

        internal Output(string recipient,decimal value)
        {
            Address = recipient;
            Value = value;
        }

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