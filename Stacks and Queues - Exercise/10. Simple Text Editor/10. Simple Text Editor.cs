using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> lastString = new Stack<string>();
            string currentString = String.Empty;
            lastString.Push(currentString);

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split(' ').ToArray();
                switch (commands[0])
                {
                    case "1":
                        currentString += commands[1];
                        lastString.Push(currentString);
                        break;
                    case "2":
                        int countLastElem = int.Parse(commands[1]);
                        currentString = currentString.Substring(0, currentString.Length - countLastElem);
                        lastString.Push(currentString);
                        break;
                    case "3":
                        int indexForPrint = int.Parse(commands[1]);
                        Console.WriteLine(currentString[indexForPrint-1]);
                        break;
                    case "4":
                        lastString.Pop();
                        currentString = lastString.Peek();
                        break;
                }
            }
        }
    }
}
