using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Lego_Blocks
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var firstMatrix = new int[n][];
            var secondMatrix = new int[n][];

            for (int row = 0; row < n; row++)
            {
                firstMatrix[row] = Console.ReadLine()
                    .Trim()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
            for (int row = 0; row < n; row++)
            {
                secondMatrix[row] = Console.ReadLine()
                    .Trim()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            var firstRowCount = firstMatrix[0].Length + secondMatrix[0].Length;
            var totalCount = firstRowCount;
            bool isLegoMatrix = true;
            for (int i = 1; i < firstMatrix.Length; i++)
            {
                var currentRowCount = firstMatrix[i].Length + secondMatrix[i].Length;
                totalCount += currentRowCount;
                if (currentRowCount != firstRowCount)
                {
                    isLegoMatrix = false;
                }
            }

            if (!isLegoMatrix)
            {
                Console.WriteLine($"The total number of cells is: {totalCount}");
            }
            else
            {
                var legoMatrix = new int[n][];
                for (int row = 0; row < firstMatrix.Length; row++)
                {
                    var secondMatReverse = secondMatrix[row].Reverse();
                    legoMatrix[row] = firstMatrix[row].Concat(secondMatReverse).ToArray();
                }
                foreach (var row in legoMatrix)
                {
                    Console.WriteLine("["+string.Join(", ", row)+"]");
                }
            }
        }
    }
}
