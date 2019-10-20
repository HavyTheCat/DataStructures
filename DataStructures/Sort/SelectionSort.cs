using DataStructures.Interfaces.Sort;
using System;


namespace DataStructures.Sort
{
    public class SelectionSort<T> : BaseSort<T>, ISorting<T>
        where T : IComparable<T>
    {
        public override void Sort(T[] items)
        {
            int sortedEnd = 0;
            while(sortedEnd < items.Length)
            {
                int index = GetIndexOfSmolestItem(items, sortedEnd);
                Swap(items, sortedEnd, index);
                sortedEnd++;
            }
        }

        private int GetIndexOfSmolestItem(T[] items, int sortedEnd)
        {
            T current = items[sortedEnd];
            int currentIndex = sortedEnd;
            for(int i = currentIndex + 1; i < items.Length; i++)
            {
                if(Compare(current, items[i]) > 0)
                {
                    current = items[i];
                    currentIndex = i;
                }
            }
            return currentIndex;
        }
    }
}
