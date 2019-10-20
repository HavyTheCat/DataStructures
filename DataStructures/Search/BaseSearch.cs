using DataStructures.Interfaces.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Search
{
    public abstract class BaseSearch
    {

        public abstract IEnumerable<ISearchMatch> Search(string toFind, string toSearch);

        protected void CheckPreSerchCondition(string toFind, string toSearch)
        {
            if (string.IsNullOrEmpty(toFind))
                throw new ArgumentException("specify searching string");

            if (string.IsNullOrEmpty(toSearch))
                throw new ArgumentException("specify string in which to search");

        }

        /// <summary>
        /// Compare left argument with right
        /// </summary>
        /// <param name="leftArg"></param>
        /// <param name="rightArg"></param>
        /// <returns></returns>
        protected int Compare(char leftArg, char rightArg) => leftArg.CompareTo(rightArg);

    }
}
