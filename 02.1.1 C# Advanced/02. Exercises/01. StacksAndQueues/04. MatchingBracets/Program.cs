using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace _04._MatchingBracets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Stack<int> indexes = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    indexes.Push(i);
                }
                else if (input[i] == ')')
                {
                    var start = indexes.Pop();
                    Console.WriteLine(input.Substring(start,i - start + 1));
                }
            }
        }
    }
}
