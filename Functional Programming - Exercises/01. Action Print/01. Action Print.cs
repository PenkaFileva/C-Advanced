using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(' ');
            Action<string> print = str => Console.WriteLine(str);
            PrintAllName(print, names);
        }

        private static void PrintAllName(Action<string> print, string[] names)
        {
            foreach (var name in names)
            {
                print(name);
            }
        }
    }
}
