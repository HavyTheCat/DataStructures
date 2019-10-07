using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Interfaces.Sort
{
    public interface ISorting<T>
        where T : IComparable<T>
    {
        void Sort(T[] items);
    }
}
