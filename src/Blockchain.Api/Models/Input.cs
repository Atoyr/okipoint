using System;
using System.Collections.Generic;
using System.Text;

namespace Blockchain.Api.Models
{
    public class Input
    {
        private Input() { }

        public Output PreviousOutput { set; get; }

        public string ScriptSignature { get; private set; }
    }
}
