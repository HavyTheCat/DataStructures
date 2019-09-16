using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Interfaces.List;
using DataStructures.Interfaces.Set;

namespace DataStructures.Set
{
    public class Set<T> : Interfaces.Set.ISet<T>
        where T : IComparable<T>
    {
        private readonly IlinkedList<T> _list = new List.LinkedList<T>();

        public int Count => _list.Count;

        public IEnumerable<T> Items { get => _list; }

        public Set()
        {

        }

        public Set(IEnumerable<T> data)
        {
            AddRage(data);
        }

        public void Add(T data)
        {
            if (Contains(data))
                throw new InvalidOperationException("already in set");

            _list.Add(data);
        }

        public void AddRage(IEnumerable<T> dataList)
        {
            foreach (var data in dataList)
                Add(data);
        }

        public bool Contains(T data)
        {
            return _list.Contains(data);
        }

        /// <summary>
        /// [1, 2, 3, 4] & [2, 3, 4, 5] => [1]
        /// </summary>
        /// <param name="otherSet"></param>
        /// <returns></returns>
        public Interfaces.Set.ISet<T> Difference(Interfaces.Set.ISet<T> otherSet)
        {
            Interfaces.Set.ISet<T> res = new Set<T>(Items);
            foreach (var item in otherSet.Items)
                res.Remove(item);

            return res;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        /// <summary>
        /// [1, 2, 3] & [2, 3, 4, 5] => [2, 3]
        /// </summary>
        /// <param name="otherSet"></param>
        /// <returns></returns>
        public Interfaces.Set.ISet<T> Intersection(Interfaces.Set.ISet<T> otherSet)
        {
            Interfaces.Set.ISet<T> res = new Set<T>();
            foreach (var data in _list)
                if (otherSet.Contains(data))
                    res.Add(data);
            return res;
        }

        public bool Remove(T data)
        {
            return _list.Remove(data);
        }

        /// <summary>
        /// [1, 2, 3] & [2, 3, 4, 5] => [1, 4, 5]
        /// </summary>
        /// <param name="otherSet"></param>
        /// <returns></returns>
        public Interfaces.Set.ISet<T> SymmetricDifference(Interfaces.Set.ISet<T> otherSet)
        {
            var itersecSet = Intersection(otherSet);
            var unionSet = Union(otherSet);

            return unionSet.Difference(itersecSet);
        }

        /// <summary>
        /// [1, 2, 3] & [2, 3, 4, 5] => [1, 2, 3, 4, 5]
        /// </summary>
        /// <param name="otherSet"></param>
        /// <returns></returns>
        public Interfaces.Set.ISet<T> Union(Interfaces.Set.ISet<T> otherSet)
        {
            var res = new Set<T>(_list);
            res.AddRageSkipDuplicates(otherSet.Items);
            return res;
        }

        private void AddRageSkipDuplicates(IEnumerable<T> items)
        {
            foreach (var item in items)
                if (!_list.Contains(item))
                    Add(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
