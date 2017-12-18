using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.Api.Models
{
    public class Wallet
    {
        byte[] PublicKey { set; get; }
        byte[] PrivateKey { set; get; }
    }
}
