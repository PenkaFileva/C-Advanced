using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            var numbers = new Stack<int>();
            var maxNumbers = new Stack<int>();
            var maxValue = int.MinValue;
            for (int i = 0; i < input; i++)
            {
                var query = Console.ReadLine().Split(' ')
                    .Select(int.Parse).ToArray();
                if (query[0] == 1)
                {
                    numbers.Push(query[1]);
                    if (maxValue < query[1])
                    {
                        maxValue = query[1];
                        maxNumbers.Push(maxValue);
                    }
                }
                else if (query[0] == 2)
                {
                    if (numbers.Pop() == maxValue)
                    {
                        maxNumbers.Pop();
                        if (maxNumbers.Count() != 0)
                        {
                            maxValue = maxNumbers.Peek();
                        }
                        else
                        {
                            maxValue = int.MinValue;
                        }
                    }
                }
                else if (query[0] == 3)
                {
                    Console.WriteLine(maxValue);
                }
            }
        }
    }
}
