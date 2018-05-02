using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._BasicStackOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(a => int.Parse(a)).ToList();
            int n = input[0];
            int x = input[1];
            int s = input[2];
            if (n == x)
            {
                Console.WriteLine("0");
            }
            else
            {
                Stack<int> nums = new Stack<int>();
                var numbers = Console.ReadLine().Split().Select(a => int.Parse(a)).ToList();
                for (int i = 0; i < n; i++)
                {
                    nums.Push(numbers[i]);
                }
                for (int i = 0; i < x; i++)
                {
                    nums.Pop();
                }
                if (nums.Contains(s))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(nums.Min());
                }
            }
        }
    }
}
