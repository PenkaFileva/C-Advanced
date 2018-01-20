using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputTokens = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse);
            var dict = new SortedDictionary<double, int>();
            foreach (var token in inputTokens)
            {
                if (! dict.ContainsKey(token))
                {
                    dict.Add(token, 1);
                }
                else
                {
                    dict[token]++;
                }
            }
            foreach (var pair in dict)
            {
                //if (pair.Key.ToString().Contains("."))
                //{
                //    var reminder = pair.Key.ToString().Replace(".", ",");
                //    Console.WriteLine($"{reminder} – {pair.Value} times");
                //}
                //else
                //{
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
                //}
            }
        }
    }
}
