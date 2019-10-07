using DataStructures.Interfaces.Sort;
using DataStructures.Sort;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Sort
{
    [TestClass]
    public abstract class BaseSortTest<T>
        where T :  BaseSort<int>

    {
        [TestMethod]
        public void Sort()
        {
            int[] items = new[] { 1, 0, 9, 7, 4 };
            T sorting = (T)Activator.CreateInstance(typeof(T));
            sorting.Sort(items);
            var checkArr = new[] { 0, 1, 4, 7, 9 };

            bool res = false;
            for (int i = 0; i < items.Length; i++)
                res = items[i] == checkArr[i];
            Assert.IsTrue(res);
        }
    }
}
