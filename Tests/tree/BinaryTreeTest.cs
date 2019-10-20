using DataStructures.Tree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.tree
{
    [TestClass]
    public sealed class BinaryTreeTest : BaseTreeTest<BinaryTree<int>>
    {
        [TestMethod]
        public void PreOrder_Delegate()
        {
            var _tree = new BinaryTree<int>();

            _tree.Add(4);
            _tree.Add(5);
            _tree.Add(2);
            _tree.Add(7);
            _tree.Add(3);
            _tree.Add(6);
            _tree.Add(1);
            _tree.Add(8);

            int[] expected = new[] { 4, 2, 1, 3, 5, 7, 6, 8 };
            int index = 0;
            _tree.PreOrderTraversal(item => Assert.AreEqual(expected[index++], item, "Wrong order"));

        }

        [TestMethod]
        public void PostOrder_Delegate()
        {
            BinaryTree<int> tree = new BinaryTree<int>();

            tree.Add(4);
            tree.Add(5);
            tree.Add(2);
            tree.Add(7);
            tree.Add(3);
            tree.Add(6);
            tree.Add(1);
            tree.Add(8);

            int[] expected = new[] { 1, 3, 2, 6, 8, 7, 5, 4 };

            int index = 0;

            tree.PostOrderTraversal(item => Assert.AreEqual(expected[index++], item, "Wrong order"));
        }

    }
}
