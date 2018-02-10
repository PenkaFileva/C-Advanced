using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Number_Wars
{
    class Program
    {
        public static readonly string letters = "#abcdefghijklmnopqrstuvwxyz";

        static void Main(string[] args)
        {
            var firstPlayer = new Queue<string>(Console.ReadLine().Split(' '));
            var secondPlayer = new Queue<string>(Console.ReadLine().Split(' '));
            var turnsCount = 0;
            var gameOver = false;

            while (turnsCount < 1000000 && firstPlayer.Count != 0 && secondPlayer.Count != 0)
            {
                turnsCount++;

                var firstPlayerCar = firstPlayer.Dequeue();
                var secondPlayerCar = secondPlayer.Dequeue();
                var firstCarValue = GetNumberValue(firstPlayerCar);
                var secondCarValue = GetNumberValue(secondPlayerCar);

                if (firstCarValue > secondCarValue)
                {
                    firstPlayer.Enqueue(firstPlayerCar);
                    firstPlayer.Enqueue(secondPlayerCar);

                }
                else if (firstCarValue < secondCarValue)
                {
                    secondPlayer.Enqueue(secondPlayerCar);
                    secondPlayer.Enqueue(firstPlayerCar);
                }
                else
                {
                    var listCar = new List<string>();
                    listCar.Add(firstPlayerCar);
                    listCar.Add(secondPlayerCar);
                    while (!gameOver)
                    {
                        if (firstPlayer.Count <3 || secondPlayer.Count <3)
                        {
                            gameOver = true;
                            break;
                        }
                        var firstCarSum = 0;
                        var secondCarSum = 0;
                        for (int i = 0; i < 3; i++)
                        {
                            var first = firstPlayer.Dequeue();
                            var second = secondPlayer.Dequeue();

                            //firstCarSum += (char)GetCharValue(first);
                            //secondCarSum += (char)GetCharValue(second);

                            firstCarSum += letters.IndexOf(GetCharValue(first));
                            secondCarSum += letters.IndexOf(GetCharValue(second));

                            listCar.Add(first);
                            listCar.Add(second);
                        }
                        if (firstCarSum > secondCarSum)
                        {
                            foreach (var car in listCar.OrderByDescending(x => GetNumberValue(x)).ThenByDescending(x => GetCharValue(x)))
                            {
                                firstPlayer.Enqueue(car);
                            }
                            break;
                        } 
                        else if (firstCarSum < secondCarSum)
                        {
                            foreach (var car in listCar.OrderByDescending(x => GetNumberValue(x)).ThenByDescending(x => GetCharValue(x)))
                            {
                                secondPlayer.Enqueue(car);
                            }
                            break;
                        }
                    }
                }
            }
            string winner = GetWinner(firstPlayer, secondPlayer);
            Console.WriteLine($"{winner} after {turnsCount} turns");
        }

        private static string GetWinner(Queue<string> firstPlayer, Queue<string> secondPlayer)
        {
            if (firstPlayer.Count > secondPlayer.Count)
                return "First player wins";
            if (secondPlayer.Count > firstPlayer.Count)
                return "Second player wins";
            else
                return "Draw";
        }

        private static char GetCharValue(string s)
        {
            return s.Last();
        }

        private static int GetNumberValue(string str)
        {
            return int.Parse(str.Substring(0, str.Length - 1));
        }
    }
}
