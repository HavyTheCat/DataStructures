using DataStructures.Interfaces.Tree;
using DataStructures.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    /// <summary>
    /// Demonstration of binaryTree
    /// </summary>
    public static class WordReaderWriter
    {
        public static void Read()
        {
            IBinaryTree<string> tree = new Tree.BinaryTree<string>();
            string input = string.Empty;

            while (!input.Equals("quit", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.Write("> ");
                input = Console.ReadLine();

                string[] words = input.Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                    tree.Add(word);

                Console.WriteLine($"words {tree.Count}");

                foreach (var word in tree)
                    Console.WriteLine($"{word}");

                Console.WriteLine();

                tree.Clear();

            }
        }
    }
}
