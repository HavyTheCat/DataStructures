﻿using DataStructures.Interfaces.Node.Pair;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Node.Pair
{
    public class HashTableNodePair<TKey, TValue> : IHashTableNodePair<TKey, TValue>
    {
        public HashTableNodePair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public TKey Key { get; private set; }

        public TValue Value { get; set; }
    }
}
