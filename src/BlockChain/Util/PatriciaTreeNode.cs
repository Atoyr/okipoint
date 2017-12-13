using BlockChain.Interface;
using BlockChain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Util
{
    class PatriciaTreeNode<T> : PrefixTreeNode<T>
    {
        public List<Nibble> ShortcutPass { set; get; } = new List<Nibble>();

        PatriciaTreeNode()
        {
            Children = new PatriciaTreeNode<T>[ARRAY_LENGTH];
        }

        public new ITreeNode<T> AddChild(int i)
        {
            if (KeyValidate(i))
            {
                Children[i] = new PatriciaTreeNode<T>();
                return Children[i];
            }
            return null;
        }

        public new T AddChild(int i, T child)
        {
            if (KeyValidate(i))
            {
                Children[i] = new PatriciaTreeNode<T>() { Value = child };
                return child;
            }
            return default(T);
        }

        public T AddChild(Nibble[] nibbles, T child)
        {
            if (nibbles.Length == 0 || nibbles[0] == null) return default(T);
            var i = nibbles[0].Value;
            if (KeyValidate(i))
            {
                Children[i] = new PatriciaTreeNode<T>();
                if(nibbles.Length == 1)
                {
                    Children[i].Value = child;
                }
                else
                {
                    (Children[i] as PatriciaTreeNode<T>).AddChild(nibbles.Skip(1).ToArray(), child);
                }
                return child;
            }
            return default(T);
        }

        public new void ClearChildren()
        {
            foreach (PatriciaTreeNode<T> child in Children)
            {
                if (child != null)
                {
                    child.ClearChildren();
                }
            }
            Children = new PatriciaTreeNode<T>[16];
        }
    }
}
