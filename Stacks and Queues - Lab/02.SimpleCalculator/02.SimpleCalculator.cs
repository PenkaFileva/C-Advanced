using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var stack = new Stack<string>(input.Reverse());
            while (stack.Count > 1)
            {
                var firstNum = int.Parse(stack.Pop());
                var op = stack.Pop();
                var secondnum = int.Parse(stack.Pop());
                if (op == "+")
                {
                    stack.Push((firstNum + secondnum).ToString());
                }
                else
                {
                    stack.Push((firstNum-secondnum).ToString());
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
