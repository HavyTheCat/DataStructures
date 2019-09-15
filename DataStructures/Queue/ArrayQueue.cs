using DataStructures.Interfaces.Queue;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class ArrayQueue<T> : IQueue<T>
    {
        private T[] _itemsArr = new T[0];

        private int _size = 0;

        private int _head = 0;

        private int _tail = -1;

        public int Count => _size;

        public bool IsReadOnly => false;

        public void Add(T item) => Enqueue(item);

        public void Clear()
        {
            _size = 0;
            _head = 0;
            _tail = -1;
            _itemsArr = new T[0];
        }

        public bool Contains(T item)
        {
            bool res = false;
            foreach (var data in _itemsArr)
            {
                res = data.Equals(item);
                if (res) break;
            }
            return res;
        }

        public void CopyTo(T[] array, int arrayIndex) => _itemsArr.CopyTo(array, arrayIndex);

        public T Dequeue()
        {
            if (_size == 0)
                throw new InvalidOperationException("Queue empty");

            T res = _itemsArr[_head];

            if (_head == _itemsArr.Length - 1)
                _head = 0;
            else
                _head++;

            _size--;

            return res;
        }

        public void Enqueue(T data)
        {
            if (_itemsArr.Length == _size)
            {
                int newLength = _size == 0 ? 4 : _size * 2;
                T[] newArray = new T[newLength];

                if (_size > 0)
                {
                    int targetIndex = 0;
                    if (_tail < _head)
                    {
                        //_itemsArr[head].. _itemsArr[end] -> newArr[0]..newArr[N]
                        for (int index = _head; index < _itemsArr.Length; index++)
                        {
                            newArray[targetIndex] = _itemsArr[index];
                            targetIndex++;
                        }
                        for (int index = 0; index <= _tail; index++)
                        {
                            newArray[targetIndex] = _itemsArr[index];
                            targetIndex++;
                        }
                    }
                    else
                    {
                        for (int index = _head; index <= _tail; index++)
                        {
                            newArray[targetIndex] = _itemsArr[index];
                            targetIndex++;
                        }
                    }
                    _head = 0;
                    _tail = targetIndex - 1;
                }
                else
                {
                    _head = 0;
                    _tail = -1;
                }
                _itemsArr = newArray;
            }

            if (_tail == _itemsArr.Length - 1)
                _tail = 0;
            else
                _tail++;

            _itemsArr[_tail] = data;
            _size++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_size > 0)
            {
                if (_tail < _head)
                {
                    // from head to end
                    for (int index = _head; index < _itemsArr.Length; index++)
                        yield return _itemsArr[index];
                    //from start to tail
                    for (int index = _head; index <= _tail; index++)
                        yield return _itemsArr[index];
                }
                else
                    // from head to tail
                    for (int index = _head; index <= _tail; index++)
                        yield return _itemsArr[index];
            }
        }

        public T Peek()
        {
            if (_size == 0)
                throw new InvalidOperationException("Nothing to peek for");
            return _itemsArr[_head];
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}