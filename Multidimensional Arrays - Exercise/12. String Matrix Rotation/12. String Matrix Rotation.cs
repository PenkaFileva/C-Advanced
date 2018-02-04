using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.String_Matrix_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            var rotate = Console.ReadLine().Split(new[] {" ", "(", ")"}, StringSplitOptions.RemoveEmptyEntries);
            var degrees = int.Parse(rotate[1]) % 360;
            var matrix = new List<List<char>>();
            var line = Console.ReadLine();
            var maxcount = 0;
            while (line != "END")
            {
                matrix.Add(new List<char>(line.ToCharArray()));
                if (maxcount<line.Length)
                {
                    maxcount = line.Length;
                }
                line = Console.ReadLine();
            }
            for (int i = 0; i < matrix.Count; i++)
            {
                if (matrix[i].Count < maxcount)
                {
                    matrix[i].AddRange(new string(' ', maxcount - matrix[i].Count));
                }
            }
            if (degrees == 0)
            {
                foreach (var m in matrix)
                {
                    Console.WriteLine(string.Join("", m));
                }
            }
            else if (degrees == 90)
            {
                for (int i = 0; i < matrix[0].Count; i++)
                {
                    for (int j = matrix.Count -1; j >= 0; j--)
                    {
                        Console.Write(matrix[j][i]);
                    }
                    Console.WriteLine();
                }   
               
            }
            else if (degrees == 270)
            {
                for (int i = matrix[0].Count - 1; i >= 0; i--)
                {
                    for (int j = 0; j < matrix.Count ; j++)
                    {
                        Console.Write(matrix[j][i]);
                    }
                    Console.WriteLine();
                }
            }
            else if (degrees == 180)
            {
                for (int i = matrix.Count - 1; i >= 0; i--)
                {
                    for (int j = matrix[0].Count - 1; j >= 0; j--)
                    {
                        Console.Write(matrix[i][j]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
