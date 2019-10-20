using DataStructures.Interfaces.Node;
using DataStructures.Interfaces.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Node
{
    public class AVLTreeNode<T> : IAVLTreeNode<T>
        where T : IComparable<T>
    {
        public AVLTreeNode(T value, IAVLTreeNode<T> parent, IAVLTree<T> tree)
        {
            Value = value;
            Parent = parent;
            _tree = tree;
        }

        IAVLTree<T> _tree;

        private enum TreeState
        {
            LeftHeavy,
            RightHeavy,
            Balanced
        }

        private IAVLTreeNode<T> _left;
        public IAVLTreeNode<T> Left
        {
            get
            {
                return _left;
            }
            set
            {
                _left = value;
                if (_left != null)
                    _left.Parent = this;
            }
        }

        private IAVLTreeNode<T> _right;

        public AVLTreeNode(T value) => Value = value;

        public IAVLTreeNode<T> Right
        {
            get
            {
                return _right;
            }
             set
            {
                _right = value;
                if (_right != null)
                    _right.Parent = this;
            }
        }

        public IAVLTreeNode<T> Parent { get; set; }
    
        /// <summary>
        /// Current val
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Compare current node to provided
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(T data) => Value.CompareTo(data);

        /// <summary>
        /// Height of left child
        /// </summary>
        private int LeftHeight
        {
            get
            {
                return MaxChildHeight(Left);
            }
        }

        /// <summary>
        /// Height of right child
        /// </summary>
        private int RightHeight
        {
            get
            {
                return MaxChildHeight(Right);
            }
        }

        public int BalanceFactor
        {
            get
            {
                return RightHeight - LeftHeight;
            }
        }

        private TreeState State
        {
            get
            {
                if (LeftHeight - RightHeight > 1)
                    return TreeState.LeftHeavy;
                if (RightHeight - LeftHeight > 1)
                    return TreeState.RightHeavy;

                return TreeState.Balanced;
            }
        }

        /// <summary>
        /// Max height of node
        /// </summary>
        /// <param name="right"></param>
        /// <returns></returns>
        private int MaxChildHeight(IAVLTreeNode<T> node)
        {
            if (node != null)
            {
                return 1 + Math.Max(MaxChildHeight(node.Left),
                MaxChildHeight(node.Right));
            }
            else
                return 0;
        }

        public void Balance()
        {
            switch (State)
            {
                case TreeState.RightHeavy:
                    {
                        if (Right != null && Right.BalanceFactor < 0)
                            LeftRightRotation();
                        else
                            LeftRotation();
                    }
                    break;
                case TreeState.LeftHeavy:
                    {
                        if (Left != null && Left.BalanceFactor > 0)
                            RightLeftRotation();
                        else
                            RightRotation();
                    }
                    break;
                case TreeState.Balanced:
                    break;
            }
        }

        public void RightLeftRotation()
        {
            Left.LeftRotation();
            RightRotation();
        }

        public void RightRotation()
        {
            var newRoot = Left;
            ReplaceRoot(newRoot);
            Left = newRoot.Right;
            newRoot.Right = this;
        }

        public void LeftRightRotation()
        {
            Right.RightRotation();
            LeftRotation();
        }

        public void LeftRotation()
        {
            var newRoot = Right;
            //replace current root with new 
            ReplaceRoot(newRoot);

            // set rights left child as right
            Right = newRoot.Left;

            // new root take current node as left
            newRoot.Left = this;
        }

        private void ReplaceRoot(IAVLTreeNode<T> newRoot)
        {
            if (Parent != null)
            {
                if (Parent.Left == this)
                    Parent.Left = newRoot;
                else if (Parent.Right == this)
                    Parent.Right = newRoot;
            }
            else
                _tree.Head = newRoot;

            newRoot.Parent = Parent;
            Parent = newRoot;



        }
    }
}