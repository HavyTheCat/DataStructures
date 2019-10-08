using DataStructures.Interfaces.Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Sort
{
    /// <summary>
    /// Repeatedly breaks down a list 
    /// into several sublists until each
    /// sublist consists of a single element 
    /// and merging those sublists in a manner that 
    /// results into a sorted list
    /// </summary>
    public class MergeSort<T> : BaseSort<T>, ISorting<T>
        where T : IComparable<T>
    {
        public override void Sort(T[] items)
        {
            if (items.Length <= 1)
                return;

            var leftPart = items.Length / 2;
            var rightPart = items.Length - leftPart;

            T[] leftItems = new T[leftPart];
            T[] rightItems = new T[rightPart];

            System.Array.Copy(items, 0, leftItems, 0, leftPart);
            System.Array.Copy(items, leftPart, rightItems, 0, rightPart);

            Sort(leftItems);
            Sort(rightItems);

            Merge(items, leftItems, rightItems);
        }

        private void Merge(T[] items, T[] leftItems, T[] rightItems)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int targetIndex = 0;

            var remain = leftItems.Length + rightItems.Length;

            while (remain > 0)
            {
                if (leftIndex >= leftItems.Length)
                {
                    items[targetIndex] = rightItems[rightIndex++];
                }
                else if (rightIndex >= rightItems.Length)
                {
                    items[targetIndex] = leftItems[leftIndex++];
                }
                else if (Compare(leftItems[leftIndex], rightItems[rightIndex]) < 0)
                {
                    items[targetIndex] = leftItems[leftIndex++];
                }
                else
                    items[targetIndex] = rightItems[rightIndex++];

                targetIndex++;
                remain--;
            }
        }
    }
}
