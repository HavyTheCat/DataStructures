using DataStructures.Interfaces.Search;
using DataStructures.Interfaces.Search.BoyerMoore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Search.BoyerMoore
{
    public class BoyerMooreSearch : BaseSearch, IStringSearchAlgorithm
    {
        public override IEnumerable<ISearchMatch> Search(string toFind, string toSearch)
        {
            if (toFind.Length > 0 && toSearch.Length > 0)
            {
                BadMatchTable badMatchTable = new BadMatchTable(toFind);

                int currStartIndex = 0;
                while (currStartIndex <= toSearch.Length - toFind.Length)
                {
                    int charsLeftToMatch = toFind.Length - 1;

                    while (charsLeftToMatch >= 0 &&
                        Compare(toFind[charsLeftToMatch], toSearch[currStartIndex + charsLeftToMatch]) == 0)
                        charsLeftToMatch--;

                    if (charsLeftToMatch < 0)
                    {
                        yield return new SearchMatchStruct(currStartIndex, toFind.Length);
                        currStartIndex += toFind.Length;
                    }
                    else
                    {
                        currStartIndex += badMatchTable[toSearch[currStartIndex + toFind.Length - 1]];
                    }
                }
            }
        }
    }
}
