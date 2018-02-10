using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var pattern = @"\[[a-zA-Z]+<(\d+)REGEH(\d+)>[a-zA-Z]+\]";
            MatchCollection matches = Regex.Matches(input, pattern);
            var numbers = new List<int>();
            foreach (Match match in matches)
            {
                numbers.Add(int.Parse(match.Groups[1].Value));
                numbers.Add(int.Parse(match.Groups[2].Value));
            }
            StringBuilder st = new StringBuilder();
            var step = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                step += numbers[i];
                var currentIndex = 0;
                if (step > input.Length-1)
                {
                    currentIndex = step % input.Length - 1;
                }
                else
                {
                    currentIndex = step;
                }
                st.Append(input[currentIndex]);
            }
            Console.WriteLine(st.ToString());
        }
    }
}
