using DataStructures.Interfaces.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Interfaces.Tree
{
    public interface IAVLTree<T> : IBinaryTree<T>
        where T: IComparable<T>
    {
        IAVLTreeNode<T> Head { get; set; }
    }
}
