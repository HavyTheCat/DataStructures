using DataStructures.Interfaces.Stack;

namespace DataStructures.Interfaces
{
    public interface ICalculator<T> where T : IStack<int>
    {
        /// <summary>
        /// read string for calc
        /// </summary>
        /// <param name="val"></param>
        int Calc(string[] args);
    }
}