using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<long> fib = new Stack<long>();
            fib.Push(0);
            fib.Push(1);
            for (int i = 1; i < n; i++)
            {
                long lastNum = fib.Pop();
                long previousNum = fib.Peek();
                fib.Push(lastNum);
                fib.Push(lastNum + previousNum);
            }
            Console.WriteLine(fib.Peek());
        }
    }
}
