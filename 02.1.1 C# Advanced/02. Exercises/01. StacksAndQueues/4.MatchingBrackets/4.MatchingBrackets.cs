using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var indices = new Stack<int>();
            var expressions = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    indices.Push(i);
                }
                else if (input[i] == ')')
                {
                    var startIndex = indices.Pop();
                    var expression = input.Substring(startIndex, i - startIndex + 1);
                    expressions.Add(expression);
                }
            }
            Console.WriteLine(string.Join("\n", expressions));
        }
    }
}
