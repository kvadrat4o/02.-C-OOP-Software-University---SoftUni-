using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>(input.Reverse());
            for (int i = 0; i < stack.Count; i++)
            {

            }
            while (stack.Count > 1)
            {
                var one = int.Parse(stack.Pop());
                var @operator = stack.Pop();
                var two = int.Parse(stack.Pop());
                if (@operator == "+")
                {
                    stack.Push((one + two).ToString());
                }
                else
                {
                    stack.Push((one - two).ToString());

                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
