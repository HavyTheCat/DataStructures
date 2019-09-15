using DataStructures.Interfaces.Queue;
using System;

namespace DataStructures.Queue
{
    public class PriorityQueue<T> : Queue<T>, IPriorityQueue<T>
        where T : IComparable<T>
    {
        public override void Enqueue(T data)
        {
            if (_itemsList.Count == 0)
                _itemsList.AddLast(data);
            else
            {
                var current = _itemsList.Head;
                while (current != null && current.Data.CompareTo(data) > 0)
                    current = current.Next;

                if (current == null)
                    _itemsList.AddLast(data);
                else
                    _itemsList.AddBefore(current, data);
            }
        }
    }
}