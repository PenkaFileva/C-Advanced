using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Crypto_Master
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int maxSiquen = 0;

            for (int step = 1; step < numbers.Length; step++)
            {
                for (int index = 0; index < numbers.Length; index++)
                {
                    var currentIndex = index;
                    var nextIndex = (index + step) % numbers.Length;
                    var currentSiquens = 1;

                    while (numbers[currentIndex] < numbers[nextIndex])
                    {
                        currentIndex = nextIndex;
                        nextIndex = (nextIndex + step) % numbers.Length;
                        currentSiquens++;
                        if (currentSiquens > maxSiquen)
                        {
                            maxSiquen = currentSiquens;
                        }
                    }
                }   
            }
            Console.WriteLine(maxSiquen);
        }
    }
}
