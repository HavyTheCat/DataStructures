using DataStructures.Interfaces.Node;
using DataStructures.Interfaces.Stack;
using DataStructures.Interfaces.Tree;
using DataStructures.Node;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree
{
    public class AVLTree<T> : IAVLTree<T>
        where T : IComparable<T>
    {
        private IAVLTreeNode<T> _head;
        private int _count;

        public IAVLTreeNode<T> Head { get => _head; set => _head = value; }
        
        public int Count => _count;

        public bool IsReadOnly => false;

       

        public void Add(T item)
        {
            if (_head == null)
                _head = new AVLTreeNode<T>(item, null, this);
            else
                AddTo(_head, item);

            _count++;
        }

        private void AddTo(IAVLTreeNode<T> head, T item)
        {
            if(item.CompareTo(head.Value) < 0)
            {
                if (head.Left == null)
                    head.Left = new AVLTreeNode<T>(item, head, this);
                else
                    AddTo(head.Left, item);
            }
            else
            {
                if (head.Right == null)
                    head.Right = new AVLTreeNode<T>(item, head, this);
                else
                    AddTo(head.Right, item);
            }
            head.Balance();
        }



        public void Clear()
        {
            _head = null;
            _count = 0;
        }

        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        private IAVLTreeNode<T> Find(T item)
        {
            var current = _head;
            while(current != null)
            {
                int _res = current.CompareTo(item);

                if (_res > 0)
                    current = current.Left;
                else if (_res < 0)
                    current = current.Right;
                else
                    break;
            }
            return current;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal();
        }

        public void InOrderTraversal(Action<T> action)
        {
            InOrderTraversal(action, _head);
        }

        private void InOrderTraversal(Action<T> action, IAVLTreeNode<T> node)
        {
            if(node != null)
            {
                InOrderTraversal(action, node.Left);
                action(node.Value);
                InOrderTraversal(action, node.Right);
            }
        }

        public IEnumerator<T> InOrderTraversal()
        {
            if(_head != null)
            {
                IStack<IAVLTreeNode<T>> stack = new Stack.Stack<IAVLTreeNode<T>>();
                IAVLTreeNode<T> curr = _head;

                bool goLeft = true;
                stack.Push(curr);

                while(stack.Count > 0)
                {
                    if (goLeft)
                    {
                        while(curr.Left != null)
                        {
                            stack.Push(curr);
                            curr = curr.Left;
                        }
                    }

                    yield return curr.Value;

                    if(curr.Right != null)
                    {
                        curr = curr.Right;
                        goLeft = true;
                    }
                    else
                    {
                        curr = stack.Pop();
                        goLeft = false;
                    }
                }
            }

        }

        public void PostOrderTraversal(Action<T> action)
        {
            PostOrderTraversal(action, _head);
        }


        private void PostOrderTraversal(Action<T> action, IAVLTreeNode<T> node)
        {
            if(node != null)
            {
                PostOrderTraversal(action, node.Left);
                PostOrderTraversal(action, node.Right);
                action(node.Value);
            }

        }

        public void PreOrderTraversal(Action<T> action)
        {
            PreOrderTraversal(action, _head);
        }

        private void PreOrderTraversal(Action<T> action, IAVLTreeNode<T> node)
        {
            if (node != null)
            {
                action(node.Value);
                PreOrderTraversal(action, node.Left);
                PreOrderTraversal(action, node.Right);
            }
        }

        public bool Remove(T item)
        {
            IAVLTreeNode<T> _curr = Find(item);
            if (_curr == null)
                return false;

            IAVLTreeNode<T> treeToBalance = _curr.Parent;
            _count--;

            // if curr has no right child then currents left replace current
            if (_curr.Right == null)
            {
                if (_curr.Parent == null)
                {
                    _head = _curr.Left;
                    if (Head != null)
                        _head.Parent = null;
                }
                else
                {
                    int _res = _curr.Parent.CompareTo(_curr.Value);

                    //if parent val is greater then curr val
                    //make curr left a left child of parent
                    if (_res > 0)
                        _curr.Parent.Left = _curr.Left;
                    // if parent val is less then curr val 
                    // make cur left child a right child of parent
                    else if (_res < 0)
                        _curr.Parent.Right = _curr.Left;
                }
            }
            // if curr right child has no left child, then curr right child 
            // replace curr
            else if (_curr.Right.Left == null)
            {
                _curr.Right.Left = _curr.Left;
                if (_curr.Parent == null)
                {
                    _head = _curr.Right;
                    if (_head != null)
                        _head.Parent = null;
                }
                else
                {
                    int _res = _curr.Parent.CompareTo(_curr.Value);
                    if (_res > 0)
                        _curr.Parent.Left = _curr.Right;
                    else
                        _curr.Parent.Right = _curr.Right;
                }
            }
            //if cur right has a left child
            //ewplace curr with current right childs left-most child 
            else
            {
                var _leftMost = _curr.Right.Left;
                while (_leftMost.Left != null)
                    _leftMost = _leftMost.Left;

                _leftMost.Parent.Left = _leftMost.Right;

                _leftMost.Left = _curr.Left;
                _leftMost.Right = _curr.Right;

                if(_curr.Parent == null)
                {
                    _head = _leftMost;
                    if (_head != null)
                        _head.Parent = null;
                }
                else
                {
                    int _res = _curr.Parent.CompareTo(_curr.Value);
                    if (_res > 0)
                        _curr.Parent.Left = _leftMost;
                    else if (_res < 0)
                        _curr.Parent.Right = _leftMost;
                }
            }
            if (treeToBalance != null)
                treeToBalance.Balance();
            else
            {
                if (_head != null)
                    _head.Balance();
            }
            return true;

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return InOrderTraversal();
        }
    }
}
