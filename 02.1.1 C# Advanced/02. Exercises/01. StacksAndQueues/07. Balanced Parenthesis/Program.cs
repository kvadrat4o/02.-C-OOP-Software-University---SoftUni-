using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();
            var stack = new Stack<char>();
            char[] opening = new [] { '(', '[', '{' };
            char[] closing = new [] { ')', ']', '}' };
            if (input.Length % 2 == 1)
            {
                Console.WriteLine("NO");
                Environment.Exit(0);
            }

            foreach (var el in input)
            {
                if (opening.Contains(el))
                {
                    stack.Push(el);
                }
                else if (closing.Contains(el))
                {
                    var lastEl = stack.Pop();
                    var openingIndex = Array.IndexOf(opening, lastEl);
                    var clsoingIndex = Array.IndexOf(closing, el);
                    if (openingIndex != clsoingIndex)
                    {
                        Console.WriteLine("NO");
                        Environment.Exit(0);
                    }
                }
            }

            if (stack.Any())
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
