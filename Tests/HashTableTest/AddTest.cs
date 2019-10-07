using DataStructures.HashTable;
using DataStructures.Interfaces.HashTable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace HashTableTests
{
    [TestClass]
    public class AddTest
    {
        Random _rng = new Random();

        [TestMethod]
        public void Add_Unique_Adds()
        {
            IHashTable<string, int> table = new LinkedListHashTable<string, int>();
            List<int> added = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(i, table.Count, "The count was incorrect");

                int value = _rng.Next();
                string key = value.ToString();

                // this ensure we should never throw on Add
                while (table.ContainsKey(key))
                {
                    value = _rng.Next();
                    key = value.ToString();
                }

                table.Add(key, value);
                added.Add(value);
            }

            // now make sure all the keys and values are there
            foreach (int value in added)
            {
                Assert.IsTrue(table.ContainsKey(value.ToString()), "ContainsKey returned false?");
                Assert.IsTrue(table.ContainsValue(value), "ContainsValue returned false?");

                int found = table[value.ToString()];
                Assert.AreEqual(value, found, "The indexed value was incorrect");
            }
        }

        [TestMethod]
        public void Add_Duplicate_Throws()
        {
            IHashTable<string, int> table = new LinkedListHashTable<string, int>();
            List<int> added = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(i, table.Count, "The count was incorrect");

                int value = _rng.Next();
                string key = value.ToString();

                // this ensure we should never throw on Add
                while (table.ContainsKey(key))
                {
                    value = _rng.Next();
                    key = value.ToString();
                }

                table.Add(key, value);
                added.Add(value);
            }

            // now make sure each attempt to re-add throws
            foreach (int value in added)
            {
                try
                {
                    table.Add(value.ToString(), value);
                    Assert.Fail("The Add operation should have thrown with the duplicate key");
                }
                catch (ArgumentException)
                {
                    // correct!
                }
            }
        }
    }
}
