

using System.Collections.Generic;

namespace DataStructures.Interfaces.HashTable
{
    public interface IHashTable<TKey, TValue> 
    {
        /// <summary>
        /// Adds pair to the node
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Add(TKey key, TValue value);

        /// <summary>
        /// Update val of the existing key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Update(TKey key, TValue value);

        /// <summary>
        /// Remove item by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Remove(TKey key);

        /// <summary>
        /// Find and return value by key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool TryGetValue(TKey key, out TValue value);

        /// <summary>
        /// Capacity of arr
        /// </summary>
        int Capacity { get; }

        /// <summary>
        /// Remove every item from table
        /// </summary>
        void Clear();

        IEnumerable<TKey> Keys { get; }

        IEnumerable<TValue> Values { get; }

        int Count { get; }

        TValue this[TKey key] { get; }

    }
}
