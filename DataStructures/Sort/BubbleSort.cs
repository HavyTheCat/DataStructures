using DataStructures.Interfaces.Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Sort
{
    public class BubbleSort<T> : BaseSort<T>,  ISorting<T>
        where T : IComparable<T>
    {
        public override void Sort(T[] items)
        {
            bool swap;

            do
            {
                swap = false;
                for (int i = 0; i < items.Length - 1; i++)
                {
                    if (items[i].CompareTo(items[i + 1]) > 0)
                    {
                        Swap(items, i, i + 1);
                        swap = true;
                    }
                }
            } while (swap);
        }        
    }
}
