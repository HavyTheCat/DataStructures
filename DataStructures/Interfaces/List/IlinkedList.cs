using DataStructures.Interfaces.Node;
using System.Collections.Generic;

namespace DataStructures.Interfaces.List
{
    public interface IlinkedList<T> : IEnumerable<T>, ICollection<T>
    {
        /// <summary>
        /// First node
        /// </summary>
        IBaseNode<T> Head { get; }

        /// <summary>
        /// Last node
        /// </summary>
        IBaseNode<T> Tail { get; }

        /// <summary>
        /// Add new node
        /// </summary>
        void AddLast(T data);

        /// <summary>
        /// Add to Head
        /// </summary>
        /// <param name="node"></param>
        void AddFirst(T data);

        void AddBefore(IBaseNode<T> node, T data);

        /// <summary>
        /// Remove last node
        /// </summary>
        bool RemoveLast();

        /// <summary>
        /// Remove first node
        /// </summary>
        bool RemoveFirst();
    }
}