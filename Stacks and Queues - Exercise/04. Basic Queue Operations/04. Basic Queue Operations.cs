using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> numbers = new Queue<int>();
            for (int i = 0; i < commands[0]; i++)
            {
                numbers.Enqueue(nums[i]);
            }
            for (int i = 0; i < commands[1]; i++)
            {
                numbers.Dequeue();
            }
            if (numbers.Count > 0)
            {
                bool flack = false;
                int minNum = int.MaxValue;
                while (numbers.Count > 0)
                {
                    int currentNum = numbers.Dequeue();
                    if (minNum > currentNum)
                    {
                        minNum = currentNum;
                    }
                    if (currentNum == commands[2])
                    {
                        flack = true;
                    }
                }
                if (flack)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(minNum);
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
