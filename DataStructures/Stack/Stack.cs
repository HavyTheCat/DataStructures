using DataStructures.Interfaces.Stack;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Stack
{
    public class Stack<T> : IStack<T>
    {
        private List.LinkedList<T> _list = new List.LinkedList<T>();

        public int Count => _list.Count;

        public bool IsReadOnly => false;

        public void Add(T item) => Push(item);

        public void Clear() => _list.Clear();

        public bool Contains(T item) => _list.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => _list.CopyTo(array, arrayIndex);

        public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();

        public T Peek()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("Stack empty");

            T res = _list.Head.Data;
            return res;
        }

        public T Pop()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("Stack empty");

            T res = _list.Head.Data;
            _list.RemoveFirst();
            return res;
        }

        public void Push(T data) => _list.AddFirst(data);

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();
    }
}