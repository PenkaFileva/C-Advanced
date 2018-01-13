using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Reverse_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new char[] { ' ' }, 
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Stack<int> num = new Stack<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                num.Push(numbers[i]);
            }
            Console.WriteLine(string.Join(" ", num ));
        }
    }
}
