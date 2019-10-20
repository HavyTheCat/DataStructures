using DataStructures.Interfaces.Tree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.tree
{
    [TestClass]
    public abstract class BaseTreeTest<T>
        where T : ICollection<int>, IBinaryTree<int>
    {
        [TestMethod]
        public void Enum_OF_Single()
        {
            T _tree = (T)Activator.CreateInstance(typeof(T));

            foreach(var item in _tree)
                Assert.Fail("Nothing to enumerate");

            Assert.IsFalse(_tree.Contains(10), "Nothing");
            _tree.Add(10);
            Assert.IsTrue(_tree.Contains(10), "There should be 10");

            int _count = 0;
            foreach(var item in _tree)
            {
                _count++;
                Assert.AreEqual(1, _count, "Only one item in tree");
                Assert.AreEqual(10, item, "addet item is 10");
            }
        }

        [TestMethod]
        public void InOrder_enumerator()
        {
            T _tree = (T)Activator.CreateInstance(typeof(T));
            _tree.Add(4);
            _tree.Add(5);
            _tree.Add(2);
            _tree.Add(7);
            _tree.Add(3);
            _tree.Add(6);
            _tree.Add(1);
            _tree.Add(8);

            int[] expected = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            int index = 0;
            foreach (int actual in _tree)
            {
                Assert.AreEqual(expected[index], actual, $"item in wrong order. Expect {expected[index]}, get {actual}");
                index++;
            }   
        }

        [TestMethod]
        public void InOrder_Delegate()
        {
            T _tree = (T)Activator.CreateInstance(typeof(T));

            _tree.Add(4);
            _tree.Add(5);
            _tree.Add(2);
            _tree.Add(7);
            _tree.Add(3);
            _tree.Add(6);
            _tree.Add(1);
            _tree.Add(8);

            int[] expected = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            int index = 0;

            _tree.InOrderTraversal(item => Assert.AreEqual(expected[index++], item, "Wrong order"));

        }
    }
}
