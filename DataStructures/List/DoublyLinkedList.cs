using DataStructures.Interfaces.List;
using DataStructures.Interfaces.Node;
using DataStructures.Node;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.List
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private void IncrementIndex() => Count++;

        private void DecrementIndex() => Count--;

        public IDoublyLinkedNode<T> Head { get; private set; }
        public IDoublyLinkedNode<T> Tail { get; private set; }
        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public virtual void AddLast(T data)
        {
            IDoublyLinkedNode<T> node = new DoublyLinkedNode<T>(data);

            if (Count == 0)
                Head = node;
            else
            {
                node.Previous = Tail;
                Tail.Next = node;
            }

            Tail = node;
            IncrementIndex();
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        public virtual void AddFirst(T data)
        {
            IDoublyLinkedNode<T> node = new DoublyLinkedNode<T>(data);

            if (Count == 0)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                var tNode = Head;
                tNode.Previous = node;
                Head = node;
                node.Next = tNode;
            }
        }

        /// <summary>
        /// Remove last node
        /// </summary>
        public bool RemoveLast()
        {
            if (Count > 0)
            {
                if (Count > 1)
                {
                    Tail.Previous.Next = null;
                    Tail = Tail.Previous;
                }
                else
                {
                    Head = null;
                    Tail = null;
                }
                DecrementIndex();
                return true;
            }
            return false;
        }

        public bool RemoveFirst()
        {
            if (Count > 0)
            {
                Head = Head.Next;
                if (Count == 1)
                    Tail = null;
                if (Count > 1)
                {
                    Head.Previous = null;
                }

                DecrementIndex();
                return true;
            }
            return false;
        }

        public void Add(T item)
        {
            AddLast(item);
        }

        public void Clear()
        {
            Head = Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            bool res = false;

            var current = Head;
            while (current != null && !res)
            {
                res = current.Data.Equals(item);
                current = current.Next;
            }
            return res;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Data;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            if (Count != 0)
            {
                IDoublyLinkedNode<T> prev = null;
                IDoublyLinkedNode<T> current = Head;

                if (Tail.Data.Equals(item))
                    return RemoveLast();

                while (current != null)
                {
                    if (current.Data.Equals(item))
                    {
                        if (prev == null)
                            return RemoveFirst();
                        else
                        {
                            prev.Next = current.Next;
                            current.Next.Previous = prev;
                            DecrementIndex();

                            return true;
                        }
                    }
                    prev = current;
                    current = current.Next;
                }
            }
            return false;
        }
    }
}