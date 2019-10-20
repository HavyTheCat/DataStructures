using DataStructures.Interfaces.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.SearchTest
{
    [TestClass]
    public abstract class BaseSearchTest<T>
        where T: class, IStringSearchAlgorithm
    {
        [TestMethod]
        public void SimpleSearch()
        {
            T algorithm = (T)Activator.CreateInstance(typeof(T));

            string _toFind = "amet";
            string _toSearch = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo";

            foreach(ISearchMatch match in algorithm.Search(_toFind, _toSearch))
            {
                Assert.AreEqual(22, match.Start);
                break;
            }
        }

        [TestMethod]
        public void SearchMissingMatch()
        {
            T algorithm = (T)Activator.CreateInstance(typeof(T));

            string _toFind = "eget";
            string _toSearch = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo";

            var matchList = algorithm.Search(_toFind, _toSearch).ToList();
            Assert.AreEqual(0, matchList.Count, "There no match items");
        }

        [TestMethod]
        public void ExactSingleCharMatch()
        {
            T algorithm = (T)Activator.CreateInstance(typeof(T));
            ExactMatch("L", "L");          
        }

        [TestMethod]
        public void ExactWordMatch()
        {
            ExactMatch("Lorem", "Lorem");
        }


        public void ExactMatch(string toFind, string toSearch)
        {
            T algorithm = (T)Activator.CreateInstance(typeof(T));
            var matchList = algorithm.Search(toFind, toSearch).ToList();

            Assert.AreEqual(1, matchList.Count, "The matches list should have not items.");
            Assert.AreEqual(0, matchList.First().Start, "The start of the string match should be 0");
            Assert.AreEqual(toFind.Length, matchList.First().Length, "The length of the string match should equal the string found");
        }

        [TestMethod]
        public void MultipleMatchesExactString()
        {
            T algorithm = (T)Activator.CreateInstance(typeof(T));
            string _toFind = "ipsum";
            string _toSearch = "Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet";

            var matchList = algorithm.Search(_toFind, _toSearch).ToList();

            Assert.AreEqual(2, matchList.Count, "The shoud be two match");

            Assert.AreEqual(6, matchList.First().Start, "The start of the string match should be 6");
            Assert.AreEqual(_toFind.Length, matchList.First().Length, "The length of the string match should equal the string found");

            Assert.AreEqual(34, matchList.Last().Start, "The start of the string match should be 33");
            Assert.AreEqual(_toFind.Length, matchList.Last().Length, "The length of the string match should equal the string found");
        }

    }
}
