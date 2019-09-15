using DataStructures.Interfaces.Node;
using DataStructures.Interfaces.Stack;
using DataStructures.Interfaces.Tree;
using DataStructures.Node;
using System;
using System.Collections;
using System.Collections.Generic;


namespace DataStructures.Tree
{
    public class BinaryTree<T> : IBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree()
        {
        }

        private IBinaryTreeNode<T> _head;
        private int _count;

        public int Count => _count;

        public bool IsReadOnly => false;

        public BinaryTree(T data)
        {
            _head = new BinaryTreeNode<T>(data);
        }



        public void Add(T data)
        {
            if (_head == null)
                _head = new BinaryTreeNode<T>(data);
            else
                AddTo(_head, data);

            _count++;
        }

        private void AddTo(IBinaryTreeNode<T> node, T data)
        {
            if (data.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                    node.Left = new BinaryTreeNode<T>(data);
                else
                    AddTo(node.Left, data);
            }
            else if(node.Right == null)
                node.Right = new BinaryTreeNode<T>(data);
            else
                AddTo(node.Right, data);

        }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Clear()
        {
            _head = null;
            _count = 0;
        }

        public bool Contains(T item)
        {
            IBinaryTreeNode<T> parent;
            return FindWithParent(item, out parent) != null;
        }

        private IBinaryTreeNode<T> FindWithParent(T item, out IBinaryTreeNode<T> parent)
        {
            IBinaryTreeNode<T> current = _head;
            parent = null;

            while (current != null)
            {
                var res = current.CompareTo(item);
                if (res > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (res < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                    break;
            }
            return current;
                
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.Remove(T item)
        {
            IBinaryTreeNode<T> current;
            IBinaryTreeNode<T> parent;

            current = FindWithParent(item, out parent);

            if (current == null)
                return false;

            //First case: if current has no right child => currents left replace current
            if (current.Right == null)
            {
                if (parent == null)
                    _head = current.Left;
                else
                {
                    int res = parent.CompareTo(current.Value);

                    // if parent val greater then cur val 
                    // make curr left child a left child of the parent
                    if (res > 0)
                        parent.Left = current.Left;

                    //if parent val less th cur val
                    // make cur left a right child of parent
                    else if (res < 0)
                        parent.Right = current.Left;
                }
            }
            // Second case: currents right child has no left => cur right child
            else if(current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if (parent == null)
                    _head = current.Right;
                else
                {
                    int res = parent.CompareTo(current.Value);
                    // if parent val greate then curr val
                    if (res > 0)
                        parent.Left = current.Right;
                    else if (res < 0)
                        parent.Right = current.Right;
                }
            }
            else
            {
                IBinaryTreeNode<T> mostLeft = current.Right.Left;
                IBinaryTreeNode<T> mostLeftParent = current.Right;

                while (mostLeft.Left != null)
                {
                    mostLeftParent = mostLeft;
                    mostLeft = mostLeft.Left;
                }

                mostLeftParent.Left = mostLeft.Right;

                mostLeft.Left = current.Left;
                mostLeft.Right = current.Right;

                if (parent == null)
                    _head = mostLeft;
                else
                {
                    int res = parent.CompareTo(current.Value);
                    // if parent val greate then curr val
                    if (res > 0)
                        parent.Left = mostLeft;
                    else if (res < 0)
                        parent.Right = mostLeft;
                }
            }
            _count--;
            return true;
        }

        public void PreOrderTraversal(Action<T> action)
        {
            PreOrderTraversal(action, _head);
        }

        private void PreOrderTraversal(Action<T> action, IBinaryTreeNode<T> node)
        {
            if (node != null)
            {
                action(node.Value);
                PreOrderTraversal(action, node.Left);
                PreOrderTraversal(action, node.Right);
            }
        }

        public void PostOrderTraversal(Action<T> action)
        {
            PostOrderTraversal(action, _head);
        }

        private void PostOrderTraversal(Action<T> action, IBinaryTreeNode<T> node)
        {
            if (node != null)
            {
                PostOrderTraversal(action, node.Left);
                PostOrderTraversal(action, node.Right);
                action(node.Value);

            }
        }

        public void InOrderTraversal(Action<T> action)
        {
            InOrderTraversal(action, _head);
        }

        private void InOrderTraversal(Action<T> action, IBinaryTreeNode<T> node)
        {
            if (node != null)
            {
                InOrderTraversal(action, node.Left);

                action(node.Value);

                InOrderTraversal(action, node.Right);
            }
        }

        /// <summary>
        /// non-recursive algoritm 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> InOrderTraversal()
        {
            
            if(_head != null)
            {
                IStack<IBinaryTreeNode<T>> stack = new Stack.ArrayStack<IBinaryTreeNode<T>>();
                IBinaryTreeNode<T> cur = _head;

                var goLeft = true;

                stack.Push(cur);

                while(stack.Count > 0)
                {
                    if (goLeft)
                    {
                        while (cur.Left != null)
                        {
                            stack.Push(cur);
                            cur = cur.Left;
                        }
                            
                    }
                    yield return cur.Value;

                    if(cur.Right != null)
                    {
                        cur = cur.Right;
                        goLeft = true;
                    }
                    else
                    {
                        cur = stack.Pop();
                        goLeft = false;
                    }
                }

            }
        }
    }
}
