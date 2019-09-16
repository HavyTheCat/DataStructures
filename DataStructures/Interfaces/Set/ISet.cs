using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Interfaces.Set
{
    public interface ISet<T> : IEnumerable<T>
        where T: IComparable<T>
    {
        /// <summary>
        /// Collection of items
        /// </summary>
        IEnumerable<T> Items { get; }

        /// <summary>
        /// Set lenght
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Add data to set
        /// </summary>
        /// <param name="data"></param>
        void Add(T data);

        /// <summary>
        /// Add rage of data to set
        /// </summary>
        /// <param name="dataList"></param>
        void AddRage(IEnumerable<T> dataList);

        /// <summary>
        /// Remove specific data from set
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Remove(T data);

        /// <summary>
        /// Check if set contain specific data 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Contains(T data);

        /// <summary>
        /// Combine curr untion with another
        /// </summary>
        /// <param name="otherSet"></param>
        /// <returns></returns>
        ISet<T> Union(ISet<T> otherSet);

        /// <summary>
        /// REturn intersection of curr set and another
        /// </summary>
        /// <param name="otherSet"></param>
        /// <returns></returns>
        ISet<T> Intersection(ISet<T> otherSet);

        /// <summary>
        /// Return only difference of twjo sets
        /// </summary>
        /// <param name="otherSet"></param>
        /// <returns></returns>
        ISet<T> Difference(ISet<T> otherSet);

        /// <summary>
        ///  disjunctive union of two sets
        /// </summary>
        /// <param name="otherSet"></param>
        /// <returns></returns>
        ISet<T> SymmetricDifference(ISet<T> otherSet);



        


    }
}
