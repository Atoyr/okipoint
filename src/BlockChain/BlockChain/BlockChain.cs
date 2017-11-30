using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockChain.Model;

namespace BlockChain
{
    public class BlockChain
    {
        private static BlockChain instance;
        public static BlockChain Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BlockChain();
                }

                return instance;
            }
        }

        private byte[] chain;
        private byte[] current_transactions;

        public Block NewBlock()
        {
            return null;
        }

        public Transaction NewTransaction()
        {
            return null;
        }

        public byte[] GetHash()
        {
            return null;
        }

        public Block GetLastBlock()
        {
            return null;
        }
    }
}
