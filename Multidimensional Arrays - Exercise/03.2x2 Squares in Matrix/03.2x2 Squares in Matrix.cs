using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._2x2_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = dimensions[0];
            var cols = dimensions[1];
            var matrix = new String[rows][];

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                matrix[rowIndex] = new String[cols];
                var line = Console.ReadLine().Split(new [] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                {
                    matrix[rowIndex][colIndex] = line[colIndex];
                }

            }
            var counter = 0;
            for (int rowIndex = 0; rowIndex < matrix.Length-1; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length-1; colIndex++)
                {
                    if (matrix[rowIndex][colIndex] == matrix[rowIndex][colIndex+1] 
                        && matrix[rowIndex][colIndex] == matrix[rowIndex+1][colIndex] 
                        && matrix[rowIndex][colIndex] == matrix[rowIndex+1][colIndex + 1])
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
