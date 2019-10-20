using DataStructures.Interfaces.Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Sort
{
    public class QuickSort<T> : BaseSort<T>, ISorting<T>
        where T : IComparable<T>
    {
        private Random _coreRng = new Random();

        public override void Sort(T[] items)
        {
            QSort(items, 0, items.Length - 1);
        }

        private void QSort(T[] items, int left, int right)
        {
            if(left < right)
            {
                var core = _coreRng.Next(left, right);
                var newCore = Partition(items, left, right, core);
                QSort(items, left, newCore - 1);
                QSort(items, newCore + 1, right); 
            }
        }

        private int Partition(T[] items, int left, int right, int core)
        {
            T coreVal = items[core];
            Swap(items, core, right);

            int store = left;
            for(int i = left; i < right; i++)
            {
                if (Compare(items[i], coreVal) < 0)
                {
                    Swap(items, i, store);
                    store++;
                }
            }
            Swap(items, store, right);
            return store;
        }
    }
}
