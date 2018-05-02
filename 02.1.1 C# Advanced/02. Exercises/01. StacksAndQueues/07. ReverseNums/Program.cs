using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._ReverseNums
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(a => int.Parse(a)).ToList();
            Stack<int> result = new Stack<int>(input);
            if (input.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                for (int i = 0; i < input.Count; i++)
                {
                    Console.Write($"{result.Pop()} ");
                }
            }
            
            //Console.WriteLine(string.Join(" ",result));
        }
    }
}
