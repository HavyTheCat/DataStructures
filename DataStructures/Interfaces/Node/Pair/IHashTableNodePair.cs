using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Interfaces.Node.Pair
{
    public interface IHashTableNodePair<TKey, TValue>
    {
        /// <summary>
        /// Key
        /// </summary>
        TKey Key { get; }

        /// <summary>
        /// Value
        /// </summary>
        public TValue Value { get; set; }
    }
}
