using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SumOfAllElementsOfMatrix
{
    class SumOfAllElementsOfMatrix
    {
        static void Main(string[] args)
        {
            var matrixSizes = Console.ReadLine().Split(new string[]{", "}, StringSplitOptions.RemoveEmptyEntries);
            int [][]matrix = new int[int.Parse(matrixSizes[0])][];
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

            }
            int maxSum = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    maxSum += matrix[row][col];
                }
            }
            Console.WriteLine(matrixSizes[0]);
            Console.WriteLine(matrixSizes[1]);
            Console.WriteLine(maxSum);
        }
    }
}
