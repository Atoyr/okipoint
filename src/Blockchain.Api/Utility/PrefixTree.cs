using BlockChain.Interface;
using Blockchain.Api.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Util
{
    public class PrefixTree<K ,V> : IDictionary<K ,V>
    {
        private PrefixTreeNode<V> _parentTreeNode = new PrefixTreeNode<V>();

        public V this[K key]
        {
            set => Add(key, value);
            get
            {
                var b = ConvertKeyToBytes(key);
                var node = _parentTreeNode;

                foreach (Nibble n in Nibble.GetList(b))
                {
                    node = (PrefixTreeNode<V>)node.Children[n.Value];
                    if (node == null) return default(V);
                }
                return node.Value;
            }
        }

        public ICollection<K> Keys => throw new NotImplementedException();

        public ICollection<V> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(K key, V value)
        {
            var b = ConvertKeyToBytes(key);
            var node = _parentTreeNode;

            foreach (Nibble n in Nibble.GetList(b))
            {
                node = node.Children[n.Value] == null ? (PrefixTreeNode<V>)node.AddChild(n.Value) : (PrefixTreeNode<V>)node.Children[n.Value];
            }
            node.Value = value;
        }

        public void Add(KeyValuePair<K, V> item) => Add(item.Key, item.Value);

        public void Clear() => _parentTreeNode.ClearChildren();


        public bool Contains(KeyValuePair<K, V> item)
        {
            var value = this[item.Key];
            return value != null && value.Equals(item.Value);
        }

        public bool ContainsKey(K key)
        {
            return this[key] != null; 
        }

        public void CopyTo(KeyValuePair<K, V>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        private List<V> GetList()
        {
            return GetList(_parentTreeNode);
        }

        private List<V> GetList(ITreeNode<V> node)
        {
            return GetList(node.Children);
        }

        private List<V> GetList(ITreeNode<V>[] nodes)
        {
            var list = new List<V>();
            foreach (ITreeNode<V> node in nodes)
            {
                if (node != null)
                {
                    if (node.Value != null) list.Add(node.Value);
                    list.AddRange(GetList(node.Children));
                }
            }
            return list;
        }

        private KeyValuePair<K, V> GetKeyValue(Nibble[] nibbles,ITreeNode<V> node)
        {
            var key = ConvertBytesToKey(Nibble.ConvertNibblesToBytes(nibbles));
            return new KeyValuePair<K, V>(key, node.Value);
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            return GetEnumerator(new List<Nibble>(), _parentTreeNode);
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator(List<Nibble> nibble,ITreeNode<V> baseNode)
        {
            if (baseNode.Value != null)
            {
                yield return GetKeyValue(nibble.ToArray(), baseNode);
            }
            for (int i = 0; i < PrefixTreeNode<V>.ARRAY_LENGTH; i++)
            {
                if (_parentTreeNode.Children[i] is ITreeNode<V> node)
                {
                    nibble.Add(new Nibble(i));
                    if (GetEnumerator(new List<Nibble>(nibble), node) is PrefixTree<K, V> enumerator)
                    {
                        foreach (var kv in enumerator)
                        {
                            yield return kv;
                        }
                    }
                }
            }
        }

        public bool Remove(K key)
        {
            var value = this[key];
            if (value != null)
            {
                value = default(V);
                return true;
            }
            return false;
        }

        public bool Remove(KeyValuePair<K, V> item)
        {
            var value = this[item.Key];
            if (value != null && value.Equals(item.Value))
            {
                value = default(V);
                return true;
            }
            return false;
        }

        public bool TryGetValue(K key, out V value)
        {
            value = this[key];
            return value != null;
        }

        private byte[] ConvertKeyToBytes(K key) => Encoding.ASCII.GetBytes(key.ToString());
        private K ConvertBytesToKey(byte[] bytes) => (K)Convert.ChangeType(Encoding.ASCII.GetString(bytes),typeof(K));

        IEnumerator IEnumerable.GetEnumerator() => GetList().GetEnumerator();
    }
}
