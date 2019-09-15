namespace DataStructures.Interfaces.Node
{
    public interface IDoublyLinkedNode<T>
    {
        /// <summary>
        /// Some data
        /// </summary>
        T Data { set; get; }

        /// <summary>
        /// Ref to next node
        /// </summary>
        IDoublyLinkedNode<T> Next { set; get; }

        /// <summary>
        /// The previous node
        /// </summary>
        IDoublyLinkedNode<T> Previous { get; set; }
    }
}