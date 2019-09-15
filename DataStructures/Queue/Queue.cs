using DataStructures.Interfaces.Queue;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Queue
{
    public class Queue<T> : IQueue<T>
    {
        protected List.LinkedList<T> _itemsList = new List.LinkedList<T>();

        public int Count => _itemsList.Count;

        public bool IsReadOnly => false;

        public void Add(T item) => Enqueue(item);

        public void Clear() => _itemsList.Clear();

        public bool Contains(T item) => _itemsList.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => _itemsList.CopyTo(array, arrayIndex);

        public T Dequeue()
        {
            if (_itemsList.Count == 0)
                throw new InvalidOperationException("queue empty");

            T res = _itemsList.Head.Data;
            _itemsList.RemoveFirst();
            return res;
        }

        public virtual void Enqueue(T data)
        {
            _itemsList.AddLast(data);
        }

        public IEnumerator<T> GetEnumerator() => _itemsList.GetEnumerator();

        public T Peek()
        {
            if (_itemsList.Count == 0)
                throw new InvalidOperationException("queue empty");

            T res = _itemsList.Head.Data;
            return res;
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() => _itemsList.GetEnumerator();
    }
}