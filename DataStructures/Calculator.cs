using DataStructures.Interfaces;
using DataStructures.Interfaces.Stack;
using System;

namespace DataStructures
{
    public class Calculator<T> : ICalculator<T>
        where T : IStack<int>
    {
        private T _stack = (T)Activator.CreateInstance(typeof(T));

        public int Calc(string[] args)
        {
            foreach (var token in args)
            {
                int val;
                if (int.TryParse(token, out val))
                {
                    _stack.Push(val);
                }
                else
                {
                    int rhs = _stack.Pop();
                    int lhs = _stack.Pop();

                    switch (token)
                    {
                        case "+":
                            _stack.Push(lhs + rhs);
                            break;

                        case "-":
                            _stack.Push(lhs - rhs);
                            break;

                        case "*":
                            _stack.Push(lhs * rhs);
                            break;

                        case "/":
                            _stack.Push(lhs / rhs);
                            break;

                        case "%":
                            _stack.Push(lhs % rhs);
                            break;

                        default:
                            throw new ArgumentException($"Unrecognized token:{token}");
                    }
                }
            }
            return _stack.Pop();
        }
    }
}