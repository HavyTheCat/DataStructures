using DataStructures.Interfaces.Node;

namespace DataStructures.Node
{
    public class DoublyLinkedNode<T> : IDoublyLinkedNode<T>
    {
        public DoublyLinkedNode(T data)
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
        public IDoublyLinkedNode<T> Next { set; get; }

        /// <summary>
        /// Ref to previous node
        /// </summary>
        public IDoublyLinkedNode<T> Previous { set; get; }
    }
}