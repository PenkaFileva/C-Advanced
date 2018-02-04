using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        private static int playerRow = 0;
        private static int playerCol = 0;
        private static bool hasEscaped = false;
        private static bool isDead = false;

        static void Main(string[] args)
        {
            var rowColMatrix = Console.ReadLine().Split();
            var rows = int.Parse(rowColMatrix[0]);
            var cols = int.Parse(rowColMatrix[1]);

            var lair = new char[rows][];
            for (int rowIndex = 0; rowIndex < lair.Length; rowIndex++)
            {
                string line = Console.ReadLine();
                lair[rowIndex] = line.ToCharArray();
                if (lair[rowIndex].Contains('P'))
                {
                    playerRow = rowIndex;
                    playerCol = line.IndexOf('P');
                }
            }
            PlayerMoves(lair);
            PrintLair(lair);
            if (isDead || !hasEscaped)
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
            else
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }

        }

        private static void PrintLair(char[][] lair)
        {
            foreach (var row in lair)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void PlayerMoves(char[][] lair)
        {
            string moves = Console.ReadLine();
            
            for (int i = 0; i < moves.Length; i++)
            {
                if (isDead || (hasEscaped && !isDead))
                {
                    break;
                }
                switch (moves[i])
                {
                    case 'U':MoveUP(lair);break;

                    case 'D': MoveDown(lair);break;

                    case 'L':MoveLeft(lair); break;

                    case 'R': MoveRight(lair);break;
                }
                MultiplyBunnies(lair);
            }            
        }

        private static void MultiplyBunnies(char[][] lair)
        {
            List<int[]> bunnies = new List<int[]>();
            for (int row = 0; row < lair.Length; row++)
            {
                for (int col = 0; col < lair[0].Length; col++)
                {
                    if (lair[row][col] == 'B')
                    {
                        bunnies.Add(new int[] { row, col });
                    }
                }
            }
            foreach (var bunny in bunnies)
            {
                SpreadBunny(lair, bunny[0], bunny[1]);
            }
        }

        private static void SpreadBunny(char[][] lair, int row, int col)
        {
            if (row > 0)//Upper
            {
                if (lair[row - 1][col] == 'P')
                {
                    isDead = true;
                    hasEscaped = false;
                }
                lair[row - 1][col] = 'B';
            }
            if (row < lair.Length - 1)//Doun
            {
                if (lair[row + 1][col] == 'P')
                {
                    isDead = true;
                    hasEscaped = false;
                }
                lair[row + 1][col] = 'B';
            }
            if (col > 0)//Left
            {
                if (lair[row][col - 1] == 'P')
                {
                    isDead = true;
                    hasEscaped = false;
                }
                lair[row][col - 1] = 'B';
            }
            if (col < lair[0].Length - 1)//Right
            {
                if (lair[row][col + 1] == 'P')
                {
                    isDead = true;
                    hasEscaped = false;
                }
                lair[row][col + 1] = 'B';
            }
        }

        private static void MoveRight(char[][] lair)
        {
            if (playerCol == lair[0].Length -1)
            {
                lair[playerRow][playerCol] = '.';
                hasEscaped = true;
            }
            else if (lair[playerRow][playerCol + 1] == 'B')
            {
                isDead = true;
                lair[playerRow][playerCol] = '.';
                playerCol += 1;
            }
            else
            {
                lair[playerRow][playerCol] = '.';
                lair[playerRow][playerCol + 1] = 'P';
                playerCol += 1;
            }
        }

        private static void MoveLeft(char[][] lair)
        {
            if (playerCol == 0)
            {
                lair[playerRow][playerCol] = '.';
                hasEscaped = true;
            }
            else if (lair[playerRow][playerCol - 1] == 'B')
            {
                isDead = true;
                lair[playerRow][playerCol] = '.';
                playerCol -= 1;
            }
            else
            {
                lair[playerRow][playerCol] = '.';
                lair[playerRow][playerCol - 1] = 'P';
                playerCol -= 1;
            }
        }

        private static void MoveDown(char[][] lair)
        {
            if (playerRow == lair.Length - 1)
            {
                lair[playerRow][playerCol] = '.';
                hasEscaped = true;
            }
            else if (lair[playerRow + 1][playerCol] == 'B')
            {
                isDead = true;
                lair[playerRow][playerCol] = '.';
                playerRow += 1;
            }
            else
            {
                lair[playerRow][playerCol] = '.';
                lair[playerRow + 1][playerCol] = 'P';
                playerRow += 1;
            }
        }

        private static void MoveUP(char[][] lair)
        {
            if (playerRow == 0)
            {
                lair[playerRow][playerCol] = '.';
                hasEscaped = true;
            }
            else if (lair[playerRow - 1][playerCol] == 'B')
            {
                isDead = true;
                lair[playerRow][playerCol] = '.';
                playerRow -= 1;
            }
            else
            {
                lair[playerRow][playerCol] = '.';
                lair[playerRow - 1][playerCol] = 'P';
                playerRow -= 1;
            }
        }
    }
}
