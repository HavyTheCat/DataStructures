using DataStructures.Interfaces.HashTable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HashTableTests
{
    [TestClass]
    public class GetTest
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Get_From_Empty()
        {
            IHashTable<string, int> table = new DataStructures.HashTable.LinkedListHashTable<string, int>();
            int value = table["missing"];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Get_Missing()
        {
            IHashTable<string, int> table = new DataStructures.HashTable.LinkedListHashTable<string, int>();
            table.Add("100", 100);

            int value = table["missing"];
        }

        [TestMethod]
        public void Get_Succeeds()
        {
            IHashTable<string, int> table = new DataStructures.HashTable.LinkedListHashTable<string, int>();
            table.Add("100", 100);

            int value = table["100"];
           Assert.AreEqual(100, value, "The returned value was incorrect");

            for (int i = 0; i < 100; i++)
            {
                table.Add(i.ToString(), i);

                value = table["100"];
               Assert.AreEqual(100, value, "The returned value was incorrect");
            }
        }

        [TestMethod]
        public void TryGet_From_Empty()
        {
            IHashTable<string, int> table = new DataStructures.HashTable.LinkedListHashTable<string, int>();
            int value;

           Assert.IsFalse(table.TryGetValue("missing", out value));
        }

        [TestMethod]
        public void TryGet_Missing()
        {
            IHashTable<string, int> table = new DataStructures.HashTable.LinkedListHashTable<string, int>();
            table.Add("100", 100);

            int value;
            Assert.IsFalse(table.TryGetValue("missing", out value));
        }

        [TestMethod]
        public void TryGet_Succeeds()
        {
            IHashTable<string, int> table = new DataStructures.HashTable.LinkedListHashTable<string, int>();
            table.Add("100", 100);

            int value;
           Assert.IsTrue(table.TryGetValue("100", out value));
           Assert.AreEqual(100, value, "The returned value was incorrect");

            for (int i = 0; i < 100; i++)
            {
                table.Add(i.ToString(), i);

               Assert.IsTrue(table.TryGetValue("100", out value));
               Assert.AreEqual(100, value, "The returned value was incorrect");
            }
        }
    }
}
