using DataStructures.Interfaces.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Search
{
    public class NaiveSearch :BaseSearch, IStringSearchAlgorithm
    {
        public override IEnumerable<ISearchMatch> Search(string toFind, string toSearch)
        {
            CheckPreSerchCondition(toFind, toSearch);

            if(toFind.Length > 0 && toSearch.Length > 0)
            {
                for(int start = 0; start <= toSearch.Length - toFind.Length; start++)
                {
                    int matchCount = 0;
                    while(Compare(toFind[matchCount], toSearch[start + matchCount]) == 0)
                    {
                        matchCount++;
                        if(toFind.Length == matchCount)
                        {
                            yield return new SearchMatchStruct(start, matchCount);
                            start += matchCount - 1;
                            break;
                        }
                    }
                }
            }
        }
    }
}
