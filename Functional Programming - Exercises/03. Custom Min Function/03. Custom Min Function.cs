using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Func<int[], int> minFunk = GetMin;
            var minNum = minFunk(numbers);
            Console.WriteLine(minNum);

        }

        private static int GetMin(int[] numbers)
        {
            var minNum = int.MaxValue;
            foreach (var num in numbers)
            {
                if (num < minNum)
                {
                    minNum = num;
                }
            }
            return minNum;
        }
    }
}
