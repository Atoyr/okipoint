using System;
using System.Collections.Generic;
using System.Text;

namespace Blockchain.Core.Models
{
    public class Input
    {
        private Input() { }

        internal Input(Output utxo)
        {
            if (utxo.Spent) throw new ArgumentException(nameof(utxo));
            PreviousOutput = utxo;
        }

        public Output PreviousOutput { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public long Sequence { get; private set; }

        /// <summary>
        /// Electric Signature
        /// </summary>
        public string ScriptSignature { get; private set; }
    }
}
