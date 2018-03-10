using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Greedy_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            var capacityBag = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
            var bag = new Dictionary<string, Dictionary<string, long>>();

            long currentCapacity = capacityBag;
            long currentGold = 0;
            bool isGold = false;

            long currentGem = 0;
            bool isGem = false;

            long currentCash = 0;
            bool isCash = false;

            var currentItem = "";

            for (int i = 0; i < input.Length; i+=2)
            {
                var item = input[i];
                var quantity = long.Parse(input[i + 1]);
                if (item.ToLower() == "gold")
                {
                    currentItem = "Gold";
                    if ((currentGold +quantity)<= currentCapacity && !isGold)
                    {
                        currentGold += quantity;
                        currentCapacity -= quantity;
                        isGold = true;
                        if (!bag.ContainsKey(currentItem))
                        {
                            bag[currentItem] = new Dictionary<string, long>();
                        }
                        if (!bag[currentItem].ContainsKey(item))
                        {
                            bag[currentItem][item] = 0;
                        }
                        bag[currentItem][item] += quantity;
                    }
                    else
                    {
                        break;
                    }
                }
                if (item.ToLower().EndsWith("gem"))
                {
                    currentItem = "Gem";
                    if ((currentGem + quantity <= currentCapacity) && isGold && currentGold > currentGem + quantity)
                    {
                        currentGem += quantity;
                        currentCapacity -= quantity; 
                        isGem = true;
                        //isGold = false;
                        if (!bag.ContainsKey(currentItem))
                        {
                            bag[currentItem] = new Dictionary<string, long>();
                        }
                        if (!bag[currentItem].ContainsKey(item))
                        {
                            bag[currentItem][item] = 0;
                        }
                        bag[currentItem][item] += quantity;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (item.Length == 3)
                {
                    currentItem = "Cash";
                    if ((currentCash + quantity <= currentCapacity) && isGem && currentGem > currentCash + quantity)
                    {
                        currentCash += quantity;
                        currentCapacity -= quantity;
                        isCash = true;                      

                        if (!bag.ContainsKey(currentItem))
                        {
                            bag[currentItem] = new Dictionary<string, long>();
                        }
                        if (!bag[currentItem].ContainsKey(item))
                        {
                            bag[currentItem][item] = 0;
                        }
                        bag[currentItem][item] += quantity;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            foreach (var item in bag)
            {
                var currentSum = item.Value.Values.Sum();
                Console.WriteLine("<{0}> ${1}", item.Key, currentSum);
                foreach (var p in item.Value)
                {
                    Console.WriteLine($"##{p.Key} - {p.Value}");
                }
            }
        }
    }
}
