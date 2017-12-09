using BlockChain.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Util
{
    public class PrefixTree<String,V> : IDictionary<String,V>
    {
        private PrefixTreeNode<V> _parentTreeNode = new PrefixTreeNode<V>();

        public V this[String key]
        {
            set => Add(key, value);
            get
            {
                var b = GetStringAsciiBytes(key.ToString());
                var node = _parentTreeNode;

                foreach (Nibble n in Nibble.GetList(b))
                {
                    node = node.Children[n.Value];
                    if (node == null) return default(V);
                }
                return node.Value;
            }
        }

        public ICollection<String> Keys => throw new NotImplementedException();

        public ICollection<V> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(String key, V value)
        {
            var b = GetStringAsciiBytes(key.ToString());
            var node = _parentTreeNode;

            foreach(Nibble n in Nibble.GetList(b))
            {
                node = node.AddChild(n.Value);
            }
            node.Value = value;
        }

        public void Add(KeyValuePair<String, V> item) => Add(item.Key, item.Value);

        public void Clear() => _parentTreeNode.ClearChildren();


        public bool Contains(KeyValuePair<String, V> item)
        {
            var value = this[item.Key];
            return value != null && value.Equals(item.Value);
        }

        public bool ContainsKey(String key)
        {
            return this[key] != null; 
        }

        public void CopyTo(KeyValuePair<String, V>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        private List<V> GetList()
        {
            var list = new List<V>();



            return list;
        }


        public IEnumerator<KeyValuePair<String, V>> GetEnumerator()
        {

            throw new NotImplementedException();
        }

        public bool Remove(String key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<String, V> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(String key, out V value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private byte[] GetStringAsciiBytes(string str) => Encoding.ASCII.GetBytes(str);

    }
}
