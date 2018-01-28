using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Target_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var rows = dimensions[0];
            var cols = dimensions[1];
            var matrix = new char[rows][];

            var letters = Console.ReadLine();
            var parametersShot = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var impactRow = parametersShot[0];
            var impactCol = parametersShot[1];
            var radius = parametersShot[2];

            FullMatrixSnake(matrix, cols, letters);
            ShotMatrix(matrix, impactRow, impactCol, radius);
            GravityMatrix(matrix);

            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }

        private static void GravityMatrix(char[][] matrix)
        {
            for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
            {
                Stack<char> currentCol = new Stack<char>();
                for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
                {
                    var currentChar = matrix[rowIndex][colIndex];
                    if (currentChar != ' ')
                    {
                        currentCol.Push(currentChar);
                        matrix[rowIndex][colIndex] = ' ';
                    }
                }
                for (int rowIndex = matrix.Length - 1; rowIndex >= 0; rowIndex--)
                {
                    if (currentCol.Count > 0)
                    {
                        matrix[rowIndex][colIndex] = currentCol.Pop();
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private static void ShotMatrix(char[][] matrix, int impactRow, int impactCol, int radius)
        {
            if (radius == 0)
            {
                matrix[impactRow][impactCol] = ' ';
                return;
            }
            else
            {
                for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
                    {
                        if (((rowIndex - impactRow) * (rowIndex - impactRow) 
                            + (colIndex - impactCol) * (colIndex - impactCol))
                            <= radius * radius)
                        {
                            matrix[rowIndex][colIndex] = ' ';
                        }
                    }
                }
            }
        }

        private static void FullMatrixSnake(char[][] matrix, int cols, string letters)
        {
            Queue<char> snake = new Queue<char>();
            for (int i = 0; i < letters.Length; i++)
            {
                snake.Enqueue(letters[i]);
            }

            var step = 1;
            for (int rowIndex = matrix.Length - 1; rowIndex >= 0; rowIndex--)
            {
                matrix[rowIndex] = new char[cols];
                if (step % 2 != 0)
                {
                    for (int colIndex = matrix[rowIndex].Length - 1; colIndex >= 0; colIndex--)
                    {
                        var currentElem = snake.Dequeue();
                        matrix[rowIndex][colIndex] = currentElem;
                        snake.Enqueue(currentElem);
                    }
                }
                else
                {
                    for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                    {
                        var currentElem = snake.Dequeue();
                        matrix[rowIndex][colIndex] = currentElem;
                        snake.Enqueue(currentElem);
                    }
                }
                step++;
            }
        }
    }
}
