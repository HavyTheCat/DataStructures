using DataStructures.Interfaces.Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Sort
{
    /// <summary>
    /// simple sorting algorithm that 
    /// builds the final sorted array (or list) one 
    /// item at a time
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InsertionSort<T> : BaseSort<T>, ISorting<T>
        where T : IComparable<T>
    {
        public override void Sort(T[] items)
        {
            //Insex of last serted item in collection
            int lastIndex = 1;

            while(lastIndex < items.Length)
            {
                if(Compare(items[lastIndex], items[lastIndex - 1]) < 0)
                {
                    int insetIndex = GetInsertIndex(items, items[lastIndex]);
                    Insert(items, lastIndex, insetIndex);
                }
                lastIndex++;
            }
        }

        /// <summary>
        /// Insert item
        /// </summary>
        /// <param name="items"></param>
        /// <param name="insertedItemIndex"></param>
        /// <param name="insetIndex"></param>
        private void Insert(T[] items, int insertedItemIndex, int insetIndex)
        {
            // store item from inserted index
            var storeItem = items[insetIndex];

            //set current item in desired index
            Assign(items, insetIndex, items[insertedItemIndex]);

            //move item after insert index to the left
            for (int i = insertedItemIndex; i > insetIndex; i--)
                Assign(items, i, items[i - 1]);

            //bring back stored item
            Assign(items, insetIndex + 1, storeItem);        
        }
        private void Assign(T[] items, int insetIndex, T item) => items[insetIndex] = item;

        /// <summary>
        /// Find index where current item 
        /// less then [index + 1] 
        /// </summary>
        /// <param name="items">sorted collection</param>
        /// <param name="item">current item</param>
        /// <returns></returns>
        private int GetInsertIndex(T[] items, T currItem)
        {
            for (int res = 0; res < items.Length; res++)
                if (Compare(items[res], currItem) > 0)
                    return res;

            throw new InvalidOperationException($"There is no index for item {currItem}");
        }
    }
}
