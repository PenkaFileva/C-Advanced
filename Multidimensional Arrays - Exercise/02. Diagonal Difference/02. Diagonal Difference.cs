using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _02.Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new int[n][];
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }
            int firstDiagonal = 0;
            int secondDiagonal = 0;
            for (int i = 0; i < n; i++)
            {
                firstDiagonal += (matrix[i][i]);
                secondDiagonal += (matrix[i][matrix[i].Length - 1 - i]);
            }
            //for (int i = 0; i < n; i++)
            //{
            //    secondDiagonal += (matrix[i][matrix[i].Length - 1 - i]);
            //}
            Console.WriteLine(Math.Abs(firstDiagonal - secondDiagonal));
        }
    }
}
