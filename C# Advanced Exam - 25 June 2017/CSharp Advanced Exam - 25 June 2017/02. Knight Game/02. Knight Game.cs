using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var param = int.Parse(Console.ReadLine());
            var matrix = new char[param][];
            for (int i = 0; i < param; i++)
            {
                matrix[i] = new char[param];
                matrix[i] = Console.ReadLine().ToCharArray();
            }
            var count = 0;
            var maxKnight = -1;
            var currentKnight = 0;
            var knightRow = 0;
            var knightCol = 0;

            while (true)
            {
                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] == 'K')
                        {
                            if (IsCellInMatrix(row +1, col-2,matrix)) // Left-Down
                            {
                                if (matrix[row + 1][col - 2] == 'K')
                                {
                                    currentKnight++;
                                }
                            }
                            if (IsCellInMatrix(row - 1, col - 2, matrix))//Left-Up
                            {
                                if (matrix[row - 1][col - 2] == 'K')
                                {
                                    currentKnight++;
                                }                                
                            }
                            if (IsCellInMatrix(row + 1, col + 2, matrix)) // Right-Down
                            {
                                if (matrix[row + 1][col + 2] == 'K')
                                {
                                    currentKnight++;
                                }
                            }
                            if (IsCellInMatrix(row - 1, col + 2, matrix)) // Right-Up
                            {
                                if (matrix[row - 1][col + 2] == 'K')
                                {
                                    currentKnight++;
                                }   
                            }
                            if (IsCellInMatrix(row - 2, col + 1, matrix)) // Up-Right
                            {
                                if (matrix[row - 2][col + 1] == 'K')
                                {
                                    currentKnight++;
                                }
                            }
                            if (IsCellInMatrix(row - 2, col - 1, matrix)) //Up-Left
                            {
                                if (matrix[row - 2][col - 1] == 'K')
                                {
                                    currentKnight++;
                                }
                            }
                            if (IsCellInMatrix(row + 2, col - 1, matrix)) // Down-Left
                            {
                                if (matrix[row + 2][col - 1] == 'K')
                                {
                                    currentKnight++;
                                }
                            }
                            if (IsCellInMatrix(row + 2, col + 1, matrix)) //Down-Right
                            {
                                if (matrix[row + 2][col + 1] == 'K')
                                {
                                    currentKnight++;
                                }
                            }
                        }
                        if (currentKnight > maxKnight)
                        {
                            maxKnight = currentKnight;
                            
                            knightRow = row;
                            knightCol = col;
                        }
                        currentKnight = 0;
                    }   
                }
                if (maxKnight != 0)
                {
                    matrix[knightRow][knightCol] = '0';
                    count++;
                    maxKnight = 0;
                }
                else
                {
                    Console.WriteLine(count);
                    return;
                }
            }
        }

        private static bool IsCellInMatrix(int row, int col, char[][] matrix)
        {
            if (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length)
            {
                return true;
            }
            return false;
        }
    }
}
