using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03GroupNumbers
{
    class GroupNumbers
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var zero = numbers.Where(x => Math.Abs(x) % 3 == 0).ToArray();
            var one = numbers.Where(x => Math.Abs(x) % 3 == 1).ToArray();
            var two = numbers.Where(x => Math.Abs(x) % 3 == 2).ToArray();

            Console.WriteLine(string.Join(" ", zero));
            Console.WriteLine(string.Join(" ", one));
            Console.WriteLine(string.Join(" ", two));
        }
    }
}
