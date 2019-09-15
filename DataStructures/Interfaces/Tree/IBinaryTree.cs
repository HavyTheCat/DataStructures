using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Interfaces.Tree
{
    public interface IBinaryTree<T> : IEnumerable<T>, ICollection<T>
        where T: IComparable<T>
    {
        /// <summary>
        /// Perform the provided action on each binary
        /// tree val in preorder order.
        /// </summary>
        /// <param name="action"></param>
        void PreOrderTraversal(Action<T> action);

        /// <summary>
        /// Perform the provided action on each binary
        /// tree val in post order.
        /// </summary>
        /// <param name="action"></param>
        void PostOrderTraversal(Action<T> action);

        /// <summary>
        /// Perform the provided action on each binary
        /// tree val in order.
        /// </summary>
        /// <param name="action"></param>
        void InOrderTraversal(Action<T> action);

        /// <summary>
        /// Enumerate val in tree in order
        /// </summary>
        /// <returns></returns>
        IEnumerator<T> InOrderTraversal();


    }
}
