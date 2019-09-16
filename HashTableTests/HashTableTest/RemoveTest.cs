

using DataStructures.Interfaces.HashTable;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.HashTableTest
{
    [TestClass]
    public class RemoveTest
    {
        [TestMethod]
        public void Remove_Empty()
        {
            IHashTable<string, int> table = new DataStructures.HashTable.LinkedListHashTable< string, int>();
            Assert.IsFalse(table.Remove("missing"), "Remove on an empty collection should return false");

        }

        [TestMethod]
        public void Remove_Missing()
        {
            IHashTable<string, int> table = new DataStructures.HashTable.LinkedListHashTable<string, int>();
            table.Add("100", 100);

            Assert.IsFalse(table.Remove("missing"), "Remove on an empty collection should return false");
        }

        [TestMethod]
        public void Remove_Found()
        {
            IHashTable<string, int> table = new DataStructures.HashTable.LinkedListHashTable<string, int>();
            for (int i = 0; i < 100; i++)
            {
                table.Add(i.ToString(), i);
            }

            for (int i = 0; i < 100; i++)
            {
                Assert.IsTrue(table.ContainsKey(i.ToString()), "The key was not found in the collection");
                Assert.IsTrue(table.Remove(i.ToString()), "The value was not removed (or remove returned false)");
                Assert.IsFalse(table.ContainsKey(i.ToString()), "The key should not have been found in the collection");
            }
        }
    }
}
