using System;
using System.Collections.Generic;
using System.Text;

namespace Blockchain.Api.Models
{
    public class Input
    {
        private Input() { }

        internal Input(Output utxo)
        {
            if (utxo.Spent) throw new ArgumentException(nameof(utxo));
            PreviousOutput = utxo;
        }

        public string ScriptSignature { get; private set; }
    }
}
