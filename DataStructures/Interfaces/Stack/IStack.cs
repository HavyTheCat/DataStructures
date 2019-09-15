using System.Collections.Generic;

namespace DataStructures.Interfaces.Stack
{
    public interface IStack<T> : IEnumerable<T>, ICollection<T>
    {
        /// <summary>
        /// Add data to collection
        /// </summary>
        /// <param name="data"></param>
        void Push(T data);

        /// <summary>
        /// Removes and return top data from collection
        /// </summary>
        /// <returns></returns>
        T Pop();

        /// <summary>
        /// Return top data from collection without removing
        /// </summary>
        /// <returns></returns>
        T Peek();
    }
}