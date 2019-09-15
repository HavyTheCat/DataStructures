using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Interfaces.Node
{
    /// <summary>
    /// Interface of binary tree class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBinaryTreeNode<T> : IComparable<T>
        where T:IComparable<T>
    {
        /// <summary>
        /// Link on left node
        /// </summary>
        IBinaryTreeNode<T> Left { get; set; }

        /// <summary>
        /// Link on right node
        /// </summary>
        IBinaryTreeNode<T> Right { get; set; }

        /// <summary>
        /// current node
        /// </summary>
        T Value { get; }


    }
}
