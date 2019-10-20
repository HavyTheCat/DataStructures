using Htable = DataStructures.HashTable.LinkedListHashTable<int, int>;

namespace DataStructures.Interfaces.Search.BoyerMoore
{
    public class BadMatchTable
    {
        private readonly int _defVal;
        private Htable _distance;

        public BadMatchTable(string toFind)
        {
            _defVal = toFind.Length;
            _distance = new Htable();
            for (int i = 0; i < _defVal - 1; i++)
                _distance[toFind[i]] = _defVal - i - 1;
        }

        public int this[int i]
        {
            get
            {
                int val;
                if (!_distance.TryGetValue(i, out val))
                    val = _defVal;
                return val;
            }
            set => _distance[i] = value;
        }
    }
}
