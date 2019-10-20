using DataStructures.Interfaces.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Node
{
    /// <summary>
    /// Binary tree node class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTreeNode<T> : IBinaryTreeNode<T>
        where T : IComparable<T>
    {
        public BinaryTreeNode(T data) => Value = data;
        /// <summary>
        /// Link on left node
        /// </summary>
        public IBinaryTreeNode<T> Left { get;  set; }

        /// <summary>
        /// Link on right node
        /// </summary>
        public IBinaryTreeNode<T> Right { get; set; }

        /// <summary>
        /// Current val
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Compare current node to provided
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(T data) => Value.CompareTo(data);

    }
}
