using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.Core.Models
{
    public class Wallet
    {
        private readonly string identifier;
        private readonly string password;
        private readonly string secondPassword;

        string PublicKey { set; get; }
        string PrivateKey { set; get; }
    }
}
