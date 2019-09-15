namespace DataStructures.Interfaces.Node
{
    public interface IBaseNode<T>
    {
        /// <summary>
        /// Some data
        /// </summary>
        T Data { set; get; }

        /// <summary>
        /// Ref to next node
        /// </summary>
        IBaseNode<T> Next { set; get; }
    }
}