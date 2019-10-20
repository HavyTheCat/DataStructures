using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Interfaces.Node
{
    public interface IAVLTreeNode<T> : IComparable<T>
        where T : IComparable<T>
    {
        /// <summary>
        /// Link on left node
        /// </summary>
        IAVLTreeNode<T> Left { get; set; }

        /// <summary>
        /// Link on right node
        /// </summary>
        IAVLTreeNode<T> Right { get; set; }

        /// <summary>
        /// Linck to parent of the node
        /// </summary>
        IAVLTreeNode<T> Parent { get; set; }

        /// <summary>
        /// current node
        /// </summary>
        T Value { get; }

        int BalanceFactor { get; }

        void LeftRotation();

        void LeftRightRotation();

        void RightRotation();

        void RightLeftRotation();


        void Balance();
    }
}
