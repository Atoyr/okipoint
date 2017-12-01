using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Model
{
    public class Block
    {
        UInt64 index;
        UInt64 timestanp;
        UInt64 proof;
        byte[] previous_hash;
    }
}
