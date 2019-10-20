using DataStructures.Interfaces.Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Sort
{
    public abstract class BaseSort<T> : ISorting<T>
        where T : IComparable<T>
    {
        public abstract void Sort(T[] items);

        /// <summary>
        /// Compare left argument with right
        /// </summary>
        /// <param name="leftArg"></param>
        /// <param name="rightArg"></param>
        /// <returns></returns>
        protected int Compare(T leftArg, T rightArg) => leftArg.CompareTo(rightArg);

        protected void Swap(T[] items, int left, int right)
        {
            if (left != right)
            {
                T temp = items[left];
                items[left] = items[right];
                items[right] = temp;
            }
        }

    }
}
