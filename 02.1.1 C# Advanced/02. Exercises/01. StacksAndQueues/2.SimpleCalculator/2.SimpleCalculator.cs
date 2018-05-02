using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>(input.Reverse());


            while (stack.Count > 1)
            {
                var firstN = int.Parse(stack.Pop());
                var op = stack.Pop();
                var secondN = int.Parse(stack.Pop());

                if (op == "+")
                {
                    stack.Push((firstN + secondN).ToString());
                }
                else
                {
                    stack.Push((firstN - secondN).ToString());
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
