using DataStructures.Interfaces.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Search
{
    public class SearchMatchStruct : ISearchMatch
    {
        private int _start;
        private int _length;

        public SearchMatchStruct(int start, int length)
        {
            _start = start;
            _length = length;
        }

        public int Start => _start;

        public int Length => _length;
    }
}
