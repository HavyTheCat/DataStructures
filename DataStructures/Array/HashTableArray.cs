using DataStructures.Interfaces.Array;
using DataStructures.Interfaces.HashTable;
using DataStructures.Interfaces.Node;
using DataStructures.Interfaces.Node.Pair;
using DataStructures.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Array
{
    public class HashTableArray<TKey, TValue> : IHashTableArray<TKey, TValue>
    {
        private IHashTableArrayNode<TKey, TValue>[] _array;

        public HashTableArray(int capacity)
        {
            _array = new HashTableArrayNode<TKey, TValue>[capacity];
            for (int i = 0; i < capacity; i++)
                _array[i] = new HashTableArrayNode<TKey, TValue>();
        }

        public int Capacity => _array.Length;

        /// <summary>
        /// Returns an enumerator for all of the values in the node array
        /// </summary>
        public IEnumerable<TValue> Values 
        {
            get
            {
                foreach (HashTableArrayNode<TKey, TValue> node in _array)
                {
                    foreach (TValue value in node.Values)
                    {
                        yield return value;
                    }
                }
            }
        }

        /// <summary>
        /// Returns an enumerator for all of the keys in the node array
        /// </summary>
        public IEnumerable<TKey> Keys
        {
            get
            {
                foreach (HashTableArrayNode<TKey, TValue> node in _array)
                {
                    foreach (TKey key in node.Keys)
                    {
                        yield return key;
                    }
                }
            }
        }


        public void Add(TKey key, TValue value)
        {
            _array[GetIndex(key)].Add(key, value);
        }

        public void Clear()
        {
            foreach (var node in _array)
                node.Clear();
        }

        public bool Remove(TKey key)
        {
            return _array[GetIndex(key)].Remove(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return _array[GetIndex(key)].TryGetValue(key, out value);
        }

        public void Update(TKey key, TValue value)
        {
            _array[GetIndex(key)].Update(key, value);
        }

        /// <summary>
        /// Returns an enumerator for all of the Items in the node array
        /// </summary>
        public IEnumerable<IHashTableNodePair<TKey, TValue>> Items
        {
            get
            {
                foreach (HashTableArrayNode<TKey, TValue> node in _array)
                {
                    foreach (var pair in node.Items)
                    {
                        yield return pair;
                    }
                }
            }
        }

        public int Count => _array.Length;

        public TValue this[TKey key] => throw new NotImplementedException();

        // Maps a key to the array index based on hash code
        private int GetIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode() % Capacity);
        }

        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool ContainsValue(TValue value)
        {
            throw new NotImplementedException();
        }
    }
}
