using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Interface
{
    public interface TreeNode<T> 
    {
        TreeNode<T> Parent { get; }
        TreeNode<T>[] Children { get; }
        T Value { set; get; }

        T AddChild(BitArray key,T child);
        T RemoveChild(BitArray key);
        T RemoveChild(T child);
        bool TryRemoveChild(BitArray key);
        bool TryRemoveChild(T key);
        T ClearChildren();
        bool TryRemoveOwn();
        T RemoveOwn();
    }
}
