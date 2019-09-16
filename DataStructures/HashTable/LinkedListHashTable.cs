using DataStructures.Array;
using DataStructures.Interfaces.Array;
using DataStructures.Interfaces.HashTable;
using DataStructures.Interfaces.Node;
using DataStructures.Node;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashTable
{
    public class LinkedListHashTable<TKey, TValue> : IHashTable<TKey, TValue>
    {
        /// <summary>
        /// if arr exceed this fill percent it will grow
        /// </summary>
        const double _fillFac = 0.75;

        /// <summary>
        /// Max size before growing
        /// </summary>
        int _maxItemsAtCurrSize;

        /// <summary>
        /// number of items in table
        /// </summary>
        int _count;

        private HashTableArray<TKey, TValue> _array; 

        public LinkedListHashTable():this(1000)
        { }

        public LinkedListHashTable(int initCapacity)
        {
            if (initCapacity < 1)
                throw new ArgumentOutOfRangeException("initCapacity");
            _array = new HashTableArray<TKey, TValue>(initCapacity);

            _maxItemsAtCurrSize = (int)(initCapacity * _fillFac) + 1;
        }

        public int Capacity => _array.Capacity;

        public void Add(TKey key, TValue value)
        {
            if(_count >= _maxItemsAtCurrSize)
            {
                HashTableArray<TKey, TValue> largerArr = new HashTableArray<TKey, TValue>(_array.Capacity * 2);

                foreach(var node in _array.Items)
                {
                    largerArr.Add(node.Key, node.Value);
                }
                _array = largerArr;

                _maxItemsAtCurrSize = (int)(_array.Capacity * _fillFac) + 1;
            }
            _array.Add(key, value);
            _count++;

        }

        /// <summary>
        /// The number of items currently in the hash table
        /// </summary>
        public int Count
        {
            get
            {
                return _count;
            }
        }

        public void Clear()
        {
            _count = 0;
            _array = new HashTableArray<TKey, TValue>(1000);

        }

        public bool Remove(TKey key)
        {
            bool res = _array.Remove(key);
            if (res)
                _count--;
            return res;

        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return _array.TryGetValue(key, out value);
        }

        public void Update(TKey key, TValue value)
        {
             _array.Update(key, value);
        }

        public bool ContainsKey(TKey key)
        {
            TValue value;
            return _array.TryGetValue(key, out value);
        }

        public bool ContainsValue(TValue value)
        {
            foreach (TValue foundValue in _array.Values)
            {
                if (value.Equals(foundValue))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns an enumerator for all of the keys in the hash table
        /// </summary>
        public IEnumerable<TKey> Keys
        {
            get
            {
                foreach (TKey key in _array.Keys)
                {
                    yield return key;
                }
            }
        }

        /// <summary>
        /// Returns an enumerator for all of the values in the hash table
        /// </summary>
        public IEnumerable<TValue> Values
        {
            get
            {
                foreach (TValue value in _array.Values)
                {
                    yield return value;
                }
            }
        }
        public TValue this[TKey key]
        {
            get
            {
                TValue value;
                if (!_array.TryGetValue(key, out value))
                {
                    throw new ArgumentException("key");
                }

                return value;
            }
            set
            {
                _array.Update(key, value);
            }
        }


    }
}
