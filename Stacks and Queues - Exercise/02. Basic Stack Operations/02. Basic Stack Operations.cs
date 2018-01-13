using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var operation = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var stack = new Stack<int>();
            for (int i = 0; i < operation[0]; i++)
            {
                stack.Push(input[i]);
            }
            for (int i = 0; i < operation[1]; i++)
            {
                stack.Pop();
            }
            var targetNum = operation[2];
            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(targetNum))
            {
                Console.WriteLine("true");
            }
            else
            {
                int minNumber = int.MaxValue;
                while (stack.Count > 0)
                {
                    if (stack.Peek() < minNumber)
                    {
                        minNumber = stack.Peek();
                    }
                    stack.Pop();
                }
                Console.WriteLine(minNumber);
            }
        }
    }
}
