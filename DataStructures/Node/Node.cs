using DataStructures.Interfaces.Node;

namespace DataStructures.Node
{
    public class Node<T> : IBaseNode<T>
    {
        public Node(T data)
        {
            Data = data;
        }

        /// <summary>
        /// Some data
        /// </summary>
        public T Data { set; get; }

        /// <summary>
        /// Ref to next node
        /// </summary>
        public IBaseNode<T> Next { set; get; }
    }
}