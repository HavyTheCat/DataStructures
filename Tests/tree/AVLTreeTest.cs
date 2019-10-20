using DataStructures.Tree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.tree
{
    [TestClass]
    public sealed class AVLTreeTest : BaseTreeTest<AVLTree<int>>
    {

        [TestMethod]
        public void LeftRotation_Basic()
        {
            AVLTree<int> tree = new AVLTree<int>();

            //  1
            //   \
            //    2
            //     \
            //      3
            tree.Add(1);
            tree.Add(2);
            tree.Add(3);

            //   2
            //  / \
            // 1   3

            int[] expected = new[] { 2, 1, 3 };
            int index = 0;

            tree.PreOrderTraversal(item => Assert.AreEqual(expected[index++], item, "Wrong order"));
        }

        [TestMethod]
        public void RightRotation_Basic()
        {
            AVLTree<int> tree = new AVLTree<int>();

            //      3
            //     /
            //    2
            //   /
            //  1
            tree.Add(3);
            tree.Add(2);
            tree.Add(1);

            //   2
            //  / \
            // 1   3

            int[] expected = new[] { 2, 1, 3 };
            int index = 0;

            tree.PreOrderTraversal(item => Assert.AreEqual(expected[index++], item, "Wrong order"));
        }

        [TestMethod]
        public void LeftRightRotation_Basic()
        {
            AVLTree<int> tree = new AVLTree<int>();

            //  1
            //   \
            //    3
            //   /
            //  2
            tree.Add(1);
            tree.Add(3);
            tree.Add(2);

            //   2
            //  / \
            // 1   3

            int[] expected = new[] { 2, 1, 3 };
            int index = 0;

            tree.PreOrderTraversal(item => Assert.AreEqual(expected[index++], item, "Wrong order"));
        }

        [TestMethod]
        public void RightLeftRotation_Basic()
        {
            AVLTree<int> tree = new AVLTree<int>();

            //   3
            //  /
            // 1
            //  \
            //   2
            tree.Add(3);
            tree.Add(1);
            tree.Add(2);

            //   2
            //  / \
            // 1   3

            int[] expected = new[] { 2, 1, 3 };
            int index = 0;

            tree.PreOrderTraversal(item => Assert.AreEqual(expected[index++], item, "Wrong order"));
        }

        [TestMethod]
        public void Add_And_Remove_1k_Unique_Items()
        {
            AVLTree<int> tree = new AVLTree<int>();
            List<int> items = new List<int>();

            // add random unique items to the tree
            Random rng = new Random();
            while (items.Count < 1000)
            {
                int next = rng.Next();
                if (!items.Contains(next))
                {
                    items.Add(next);
                    tree.Add(next);

                    Assert.AreEqual(items.Count, tree.Count, "items and tree collection should have the same count");
                }
            }

            // make sure they all exist in the tree
            foreach (int value in items)
            {
                Assert.IsTrue(tree.Contains(value), "The tree does not contain the expected value " + value.ToString());
            }

            // remove the item from the tree and make sure it's gone
            foreach (int value in items)
            {
                Assert.IsTrue(tree.Remove(value), "The tree does not contain the expected value " + value.ToString());
                Assert.IsFalse(tree.Contains(value), "The tree should not have contained the value " + value.ToString());
                Assert.IsFalse(tree.Remove(value), "The tree should not have contained the value " + value.ToString());
            }

            // now make sure the tree is empty
            Assert.AreEqual(0, tree.Count, "The tree should be empty");
        }

        [TestMethod]
        public void Rotation_Complexish()
        {
            AVLTree<int> tree = new AVLTree<int>();

            //      3
            //     /
            //    2
            //   /
            //  1
            tree.Add(3);
            tree.Add(2);
            tree.Add(1);

            //   2
            //  / \
            // 1   3

            int[] expected = new[] { 2, 1, 3 };
            int index = 0;

            tree.PreOrderTraversal(item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
            Assert.AreEqual(index, expected.Length, "The wrong number of items were enumerated?");

            //   2
            //  / \
            // 1   3
            //      \
            //       4

            tree.Add(4);

            expected = new[] { 2, 1, 3, 4 };
            index = 0;

            tree.PreOrderTraversal(item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
            Assert.AreEqual(index, expected.Length, "The wrong number of items were enumerated?");

            //   2
            //  / \
            // 1   3
            //      \
            //       4
            //        \
            //         5

            tree.Add(5);

            //   2
            //  / \
            // 1   4
            //    /  \
            //   3    5

            expected = new[] { 2, 1, 4, 3, 5 };
            index = 0;

            tree.PreOrderTraversal(item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
            Assert.AreEqual(index, expected.Length, "The wrong number of items were enumerated?");

            //   2
            //  / \
            // 1   4
            //    /  \
            //   3    5
            //         \
            //          6

            tree.Add(6);

            //     4
            //    / \
            //   2   5
            //  / \   \
            // 1   3   6

            expected = new[] { 4, 2, 1, 3, 5, 6 };
            index = 0;

            tree.PreOrderTraversal(item => Debug.WriteLine(item));

            tree.PreOrderTraversal(item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
            Assert.AreEqual(index, expected.Length, "The wrong number of items were enumerated?");
        }






    }
}
