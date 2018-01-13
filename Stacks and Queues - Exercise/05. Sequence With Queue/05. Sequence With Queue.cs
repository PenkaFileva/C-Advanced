using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Sequence_With_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            Queue<long> elementInSequence = new Queue<long>();
            elementInSequence.Enqueue(n);
            List<long> result = new List<long>();
            result.Add(n);

            while (result.Count < 50)
            {
                long currentElement = elementInSequence.Dequeue();
                long firstNumber = currentElement + 1;
                long secondNumber = currentElement * 2 + 1;
                long thirdNumber = currentElement + 2;

                elementInSequence.Enqueue(firstNumber);
                elementInSequence.Enqueue(secondNumber);
                elementInSequence.Enqueue(thirdNumber);

                result.Add(firstNumber);
                result.Add(secondNumber);
                result.Add(thirdNumber);
            }
            for (int i = 0; i < 50; i++)
            {
                Console.Write(result[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
