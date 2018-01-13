using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Truck_Tour
{
    public class GasPump
    {
        public int distanceToNext;
        public int amountOfGas;
        public int indexOfPump;

        public GasPump(int distanceToNext, int amountOfGas, int indexOfPump)
        {
            this.distanceToNext = distanceToNext;
            this.amountOfGas = amountOfGas;
            this.indexOfPump = indexOfPump;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<GasPump> pumps = new Queue<GasPump>();

            for (int i = 0; i < n; i++)
            {
                var pumpInfo = Console.ReadLine().Split(' ')
                    .Select(int.Parse).ToArray();
                int distanceToNext = pumpInfo[1];
                int amountOfGas = pumpInfo[0];
                GasPump pump = new GasPump(distanceToNext, amountOfGas, i);
                pumps.Enqueue(pump);
            }

            GasPump startPump = null;
            bool completeJourney = false;

            while (true)
            {
                GasPump currentPump = pumps.Dequeue();
                pumps.Enqueue(currentPump);
                startPump = currentPump;
                int gasInTank = currentPump.amountOfGas;

                while (gasInTank >= currentPump.distanceToNext)
                {
                    gasInTank -= currentPump.distanceToNext;
                    currentPump = pumps.Dequeue();
                    pumps.Enqueue(currentPump);
                    if (currentPump == startPump)
                    {
                        completeJourney = true;
                        break;
                    }
                    gasInTank += currentPump.amountOfGas;
                }
                if (completeJourney)
                {
                    Console.WriteLine(startPump.indexOfPump);
                    break;
                }
            }
        }
    }
}
