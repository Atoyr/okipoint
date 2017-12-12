using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Util
{
    class PatriciaTreeNode<T> : PrefixTreeNode<T>
    {
        public List<int> ShortcutPass { set; get; } = new List<int>();

        PatriciaTreeNode()
        {
            Children = new PatriciaTreeNode<T>[ARRAY_LENGTH];
        }
    }
}
