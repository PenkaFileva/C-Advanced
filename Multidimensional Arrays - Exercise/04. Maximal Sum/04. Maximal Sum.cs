using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = dimensions[0];
            var cols = dimensions[1];
            var matrix = new int[rows][];

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                matrix[rowIndex] = new int[cols];
                matrix[rowIndex] = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();              
            }
            var maxSum = int.MinValue;
            var row = 0;
            var col = 0;
            for (int rowIndex = 0; rowIndex < matrix.Length - 2; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length - 2; colIndex++)
                {
                    var currentSum = matrix[rowIndex][colIndex] + matrix[rowIndex][colIndex + 1] +
                                     matrix[rowIndex][colIndex + 2]
                                     + matrix[rowIndex + 1][colIndex] + matrix[rowIndex + 1][colIndex + 1] +
                                     matrix[rowIndex + 1][colIndex + 2]
                                     + matrix[rowIndex + 2][colIndex] + matrix[rowIndex + 2][colIndex + 1] +
                                     matrix[rowIndex + 2][colIndex + 2];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        row = rowIndex;
                        col = colIndex;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int rowIndex = row; rowIndex <= row+2; rowIndex++)
            {
                var currentRow = matrix[rowIndex].Skip(col).Take(3).ToArray();
                Console.WriteLine(string.Join(" ", currentRow));
            }
        }
    }
}
