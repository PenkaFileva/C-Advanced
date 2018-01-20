using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Matrix_of_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            var param = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = param[0];
            var cols = param[1];
            string[][] palindrom =  new string[rows][];

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int rowIndex = 0; rowIndex < palindrom.Length; rowIndex++)
            {
                palindrom[rowIndex] = new string[cols];
                for (int colIndex = 0; colIndex < palindrom[0].Length; colIndex++)
                {
                    string word = string.Empty;
                    for (int i = 0; i < 3; i++)
                    {
                        if (i == 1)
                        {
                            word += alphabet[colIndex+rowIndex ];
                        }
                        else
                        {
                            word += alphabet[rowIndex];
                        }                       
                    }
                    palindrom[rowIndex][colIndex] = word;
                }
            }
            for (int i = 0; i < palindrom.Length; i++)
            {
                Console.WriteLine(string.Join(" ", palindrom[i]));
            }
        }
    }
}
