using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Util
{
    class PrefixTreeNode<T>
    {
        public PrefixTreeNode<T> Parent { set; get; }

        private PrefixTreeNode<T>[] _children = new PrefixTreeNode<T>[16];
        public PrefixTreeNode<T>[] Children { get => _children; }

        public T Value { get; set; }

        public PrefixTreeNode<T> AddChild(int i)
        {
            if (KeyValidate(i))
            {
                _children[i] = new PrefixTreeNode<T>();
                return _children[i];
            }
            return null;
        }

        public T AddChild(int i, T child)
        {
            if (KeyValidate(i))
            {
                _children[i] = new PrefixTreeNode<T>() { Value = child };
                return child;
            }
            return default(T);
        }

        public void ClearChildren()
        {
            foreach (PrefixTreeNode<T> child in _children)
            {
                if (child != null)
                {
                    child.ClearChildren();
                }
            }
            _children = new PrefixTreeNode<T>[16];
        }

        public T RemoveChild(int i)
        {
            if (KeyValidate(i) && _children[i] != null)
            {
                var value = _children[i].Value;
                _children[i] = null;
                return value;
            }
            return default(T);
        }

        public T RemoveChild(T child)
        {
            for (int i = 0; i < 16; i++)
            {
                if (_children[i] != null && _children[i].Value.Equals(child))
                {
                    var value = _children[i].Value;
                    _children[i] = null;
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

        private bool KeyValidate(int key) => key >= 0 && key < 16;

    }
}
