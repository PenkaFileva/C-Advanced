using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Dangerous_Floor
{
    class Program
    {
        static void Main(string[] args)
        {
            var param = 8;
            var matrix = new char[param][];
            for (int i = 0; i < param; i++)
            {               
                var line = Console.ReadLine().Split(',')
                    .Select(char.Parse).ToArray();
                matrix[i] = line;
            }
            var input = Console.ReadLine();
            while (input != "END")
            {
                var symbol = input[0];
                var startRow = int.Parse(input[1].ToString());
                var startCol = int.Parse(input[2].ToString());
                var endRow = int.Parse(input[4].ToString());
                var endCol = int.Parse(input[5].ToString());

                if (matrix[startRow][startCol] != symbol)
                {
                    Console.WriteLine("There is no such a piece!");
                    input = Console.ReadLine();
                    continue;
                }
                if (!OutOfBoard(endRow, endCol))
                {
                    Console.WriteLine("Move go out of board!");
                    input = Console.ReadLine();
                    continue;
                }
                else
                {
                    switch (symbol)
                    {
                        case 'K':
                            IsSymbolInAreaK(matrix,startRow, startCol, endRow, endCol, symbol);
                            break;
                        case 'R':
                            IsSymbolInAreaR(matrix, startRow, startCol, endRow, endCol, symbol);
                            break;
                        case 'B':
                            IsSymbolInAreaB(matrix, startRow, startCol, endRow, endCol, symbol);
                            break;
                        case 'Q':
                            IsSymbolInAreaQ(matrix, startRow, startCol, endRow, endCol, symbol);
                            break;
                        case 'P':
                            IsSymbolInAreaP(matrix, startRow, startCol, endRow, endCol, symbol);
                            break;
                        default:
                            break;
                    }
                    input = Console.ReadLine();
                    continue;
                }
            }
        }

        private static bool OutOfBoard(int endRow, int endCol)
        {
            bool validRow = endRow >= 0 && endRow <= 7;
            bool validCol = endCol >= 0 && endCol <= 7;

            return validRow && validCol;
        }

        private static void IsSymbolInAreaP(char[][] matrix, int startRow, int startCol, int endRow, int endCol, char symbol)
        {
            if (startCol == endCol && startRow - 1 == endRow)
            {
                matrix[endRow][endCol] = symbol;
                matrix[startRow][startCol] = 'x';
            }
            else
            {
                Console.WriteLine("Invalid move!");
            }
        }

        private static void IsSymbolInAreaB(char[][] matrix, int startRow, int startCol, int endRow, int endCol, char symbol)
        {
            if ( Math.Abs(startRow - endRow) == Math.Abs(startCol - endCol))
            {
                matrix[endRow][endCol] = symbol;
                matrix[startRow][startCol] = 'x';
            }
            else
            {
                Console.WriteLine("Invalid move!");
            }
        }

        private static void IsSymbolInAreaQ(char[][] matrix, int startRow, int startCol, int endRow, int endCol, char symbol)
        {
            if ((startRow == endRow || startCol == endCol) ||
                Math.Abs(startRow - endRow) == Math.Abs(startCol - endCol))
            {
                matrix[endRow][endCol] = symbol;
                matrix[startRow][startCol] = 'x';
            }
            else
            {
                Console.WriteLine("Invalid move!");
            }
        }

        private static void IsSymbolInAreaR(char[][] matrix, int startRow, int startCol, int endRow, int endCol, char symbol)
        {
            if (startRow == endRow || startCol == endCol)
            {
                matrix[endRow][endCol] = symbol;
                matrix[startRow][startCol] = 'x';
            }
            else
            {
                Console.WriteLine("Invalid move!");
            }
        }

        private static void IsSymbolInAreaK(char[][] matrix,int startRow, int startCol, int endRow, int endCol, char symbol)
        {
            if ((Math.Abs(startRow - endRow) == 1 || Math.Abs(startRow - endRow) == 0)
                && (Math.Abs(startCol - endCol) == 1 || Math.Abs(startCol - endCol) == 0))
            {
                matrix[endRow][endCol] = symbol;
                matrix[startRow][startCol] = 'x';
            }
            else
            {
                Console.WriteLine("Invalid move!");
            }
        }
    }
}
