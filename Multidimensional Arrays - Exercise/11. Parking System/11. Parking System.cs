using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Parking_System
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = dimensions[0];
            var cols = dimensions[1];
            var parking = new int[rows][];
            var line = Console.ReadLine();

            while (line != "stop")
            {
                var parameters = line.Split().Select(int.Parse).ToArray();
                var entryRow = parameters[0];
                var parkingRow = parameters[1];
                var parkingCol = parameters[2];

                var steps = Math.Abs(entryRow - parkingRow) + 1;
                if (parking[parkingRow] == null)
                {
                    parking[parkingRow] = new int[cols];
                }
                if (parking[parkingRow][parkingCol] == 0)
                {
                    parking[parkingRow][parkingCol] = 1;
                    steps += parkingCol;
                    Console.WriteLine(steps);
                }
                else
                {
                    int count = 1;
                    while (true)
                    {
                        int beforeCol = parkingCol - count;
                        int afterCol = parkingCol + count;

                        if (beforeCol < 1 && afterCol > cols - 1)
                        {
                            Console.WriteLine($"Row {parkingRow} full");
                            break;
                        }
                        if (beforeCol > 0 && parking[parkingRow][beforeCol] == 0)
                        {
                            parking[parkingRow][beforeCol] = 1;
                            steps += beforeCol;
                            Console.WriteLine(steps);
                            break;
                        }
                        if (afterCol < cols && parking[parkingRow][afterCol] == 0)
                        {
                            parking[parkingRow][afterCol] = 1;
                            steps += afterCol;
                            Console.WriteLine(steps);
                            break;
                        }
                        count++;
                    }
                }

                line = Console.ReadLine();
            }
        }
    }
}
