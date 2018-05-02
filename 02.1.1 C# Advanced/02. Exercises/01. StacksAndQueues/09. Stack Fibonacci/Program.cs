using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            var stack = new Stack<long>();

            stack.Push(0);
            stack.Push(1);
            
            for (long i = 0; i < n-1; i++)
            {
                long n1 = stack.Pop();
                long n2 = stack.Pop();
                long sum = n1 + n2;
                stack.Push(n1);
                stack.Push(sum);
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
