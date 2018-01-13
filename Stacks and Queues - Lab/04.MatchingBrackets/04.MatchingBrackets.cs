using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stack = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                if (input[i] == ')')
                {
                    var startInd = stack.Pop();
                    string reminder = input.Substring(startInd, i - startInd + 1);
                    Console.WriteLine(reminder);
                }
            }
        }
    }
}
