using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var queue = new Queue<string>(input);
            var num = int.Parse(Console.ReadLine());
            while (queue.Count > 1)
            {
                for (int i = 0; i < num -1; i++)
                {
                    string reminder = queue.Dequeue();
                    queue.Enqueue(reminder);
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
