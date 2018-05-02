using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._MaxElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> nums = new Stack<int>();
            int number = int.Parse(Console.ReadLine());
            MaxNumber(number, nums);
        }

        private static void MaxNumber(int number, Stack<int> nums)
        {
            for (int i = 0; i < number; i++)
            {
                var instruction = Console.ReadLine().Split().Select(a => int.Parse(a)).ToArray();
                if (instruction[0] == 1)
                {
                    nums.Push(instruction[1]);
                }
                else if (instruction[0] == 2)
                {
                    nums.Pop();
                }
                else
                {
                    Console.WriteLine(nums.Max());
                }
            }
        }
    }
}
