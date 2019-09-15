using System;

namespace DataStructures.Interfaces.Queue
{
    public interface IPriorityQueue<T> : IQueue<T>
        where T : IComparable<T>
    {
    }
}