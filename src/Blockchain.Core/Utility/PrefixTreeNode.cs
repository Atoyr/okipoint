using BlockChain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Util
{
    class PrefixTreeNode<T> : ITreeNode<T>
    {
        public const int ARRAY_LENGTH = 16;
        public PrefixTreeNode()
        {
            Children = new PrefixTreeNode<T>[ARRAY_LENGTH];
        }

        public ITreeNode<T> Parent { set; get; }

        public ITreeNode<T>[] Children { get; protected set; }

        public T Value { get; set; }

        public ITreeNode<T> AddChild(int i)
        {
            if (KeyValidate(i))
            {
                Children[i] = new PrefixTreeNode<T>();
                return Children[i];
            }
            return null;
        }

        public T AddChild(int i, T child)
        {
            if (KeyValidate(i))
            {
                Children[i] = new PrefixTreeNode<T>() { Value = child };
                return child;
            }
            return default(T);
        }

        public void ClearChildren()
        {
            foreach (PrefixTreeNode<T> child in Children)
            {
                if (child != null)
                {
                    child.ClearChildren();
                }
            }
            Children = new PrefixTreeNode<T>[16];
        }

        public T RemoveChild(int i)
        {
            if (KeyValidate(i) && Children[i] != null)
            {
                var value = Children[i].Value;
                Children[i] = null;
                return value;
            }
            return default(T);
        }

        public T RemoveChild(T child)
        {
            for (int i = 0; i < 16; i++)
            {
                if (Children[i] != null && Children[i].Value.Equals(child))
                {
                    var value = Children[i].Value;
                    Children[i] = null;
                    return value;
                }
            }
            return default(T);
        }

        public T RemoveOwn()
        {
            throw new NotImplementedException();
        }

        public bool TryRemoveChild(int i)
        {
            throw new NotImplementedException();
        }

        public bool TryRemoveChild(T key)
        {
            throw new NotImplementedException();
        }

        public bool TryRemoveOwn()
        {
            throw new NotImplementedException();
        }

        protected bool KeyValidate(int key) => key >= 0 && key < ARRAY_LENGTH;
    }
}
