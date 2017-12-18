using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Interface
{
    public interface ITreeNode<T> 
    {
        ITreeNode<T> Parent { get; }
        ITreeNode<T>[] Children { get; }
        T Value { set; get; }

        ITreeNode<T> AddChild(int i);
        T AddChild(int i,T child);
        T RemoveChild(int i);
        T RemoveChild(T child);
        bool TryRemoveChild(int i);
        bool TryRemoveChild(T key);
        void ClearChildren();
        bool TryRemoveOwn();
        T RemoveOwn();
    }
}
