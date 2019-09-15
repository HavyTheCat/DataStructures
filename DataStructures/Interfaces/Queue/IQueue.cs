using System.Collections.Generic;

namespace DataStructures.Interfaces.Queue
{
    public interface IQueue<T> : IEnumerable<T>, ICollection<T>
    {
        /// <summary>
        /// Add data to end of collection
        /// </summary>
        /// <param name="data"></param>
        void Enqueue(T data);

        /// <summary>
        /// Remove and returns first data in collection
        /// </summary>
        T Dequeue();

        /// <summary>
        /// Return first data from collection without removing
        /// </summary>
        /// <returns></returns>
        T Peek();
    }
}