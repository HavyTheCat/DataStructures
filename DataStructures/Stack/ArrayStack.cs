using DataStructures.Interfaces.Stack;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Stack
{
    public class ArrayStack<T> : IStack<T>
    {
        /// <summary>
        /// Array of items contained in stack.
        /// </summary>
        private T[] _items = new T[0];

        /// <summary>
        /// Current number of items in stuck
        /// </summary>
        private int _size;

        public int Count => _size;

        public bool IsReadOnly => false;

        public void Add(T item) => Push(item);

        public void Clear() => _size = 0;

        public bool Contains(T item)
        {
            bool res = false;
            foreach (var data in _items)
            {
                res = data.Equals(item);
                if (res) break;
            }
            return res;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _size - 1; i >= 0; i--)
                yield return _items[i];
        }

        public T Peek()
        {
            if (_size == 0)
                throw new InvalidOperationException("Stack is empty");
            return _items[_size - 1];
        }

        /// <summary>
        /// Remove and return top item
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (_size == 0)
                throw new InvalidOperationException("Stack is empty");
            _size--;
            return _items[_size];
        }

        /// <summary>
        /// add data to stack
        /// </summary>
        /// <param name="data"></param>
        public void Push(T data)
        {
            if (_size == _items.Length)
            {
                int newLength = _size == 0 ? 4 : _size * 2;

                var newArray = new T[newLength];
                _items.CopyTo(newArray, 0);
                _items = newArray;
            }
            _items[_size] = data;
            _size++;
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}