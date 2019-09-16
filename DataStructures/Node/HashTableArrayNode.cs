using DataStructures.Interfaces.Node;
using DataStructures.Interfaces.Node.Pair;
using DataStructures.Node.Pair;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Node
{
    public class HashTableArrayNode<TKey, TValue> : IHashTableArrayNode<TKey, TValue>
    {
        List.LinkedList<IHashTableNodePair<TKey, TValue>> _list;

        public IEnumerable<TKey> Keys
        {
            get
            {
                if (_list != null)
                    foreach (var pair in _list)
                        yield return pair.Key;
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                if (_list != null)
                    foreach (var pair in _list)
                        yield return pair.Value;
            }
        }

        public int Capacity => _list.Count;

        public void Add(TKey key, TValue value)
        {
            if (_list == null)
                _list = new List.LinkedList<IHashTableNodePair<TKey, TValue>>();
            else
            {
                foreach(var pair in _list)
                {
                    if (pair.Key.Equals(key))
                        throw new ArgumentException("Already contain key");
                }
            }

            _list.AddFirst(new HashTableNodePair<TKey, TValue>(key, value));
        }

        public void Clear()
        {
            if (_list != null)
                _list.Clear();
        }

        public bool Remove(TKey key)
        {
            var res = false;
            if (_list != null)
            {
                var current = _list.Head;
                while(current != null)
                {
                    if (current.Data.Key.Equals(key))
                    {
                        res = _list.Remove(current.Data);
                        break;
                    }
                    current = current.Next;
                }
            }
            return res;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);

            var res = false;
            if (_list != null)
            {
                foreach (var pair in _list)
                {
                    if (pair.Key.Equals(key))
                    {
                        value = pair.Value;
                        res = true;
                        break;
                    }
                }
            }
            return res;
        }

        public void Update(TKey key, TValue value)
        {
            var res = false;
           if(_list != null)
            {
                foreach(var pair in _list)
                {
                    if (pair.Key.Equals(key))
                    {
                        pair.Value = value;
                        res = true;
                        break;
                    }
                }
            }
            if (!res) throw new ArgumentException("Collection not contain key");
        }

        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool ContainsValue(TValue value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns an enumerator for all the key/value pairs in the list
        /// </summary>
        public IEnumerable<HashTableNodePair<TKey, TValue>> Items
        {
            get
            {
                if (_list != null)
                {
                    foreach (HashTableNodePair<TKey, TValue> node in _list)
                    {
                        yield return node;
                    }
                }
            }
        }

        public int Count => throw new NotImplementedException();

        public TValue this[TKey key] => throw new NotImplementedException();
    }
}
