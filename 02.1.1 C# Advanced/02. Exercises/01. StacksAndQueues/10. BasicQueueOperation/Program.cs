using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.BasicQueueOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> nums = new Queue<int>();
            var input = Console.ReadLine().Split().Select(a => int.Parse(a)).ToArray();
            int n = input[0];
            int x = input[1];
            int s = input[2];
            if (n == x)
            {
                Console.WriteLine("0");
            }
            else
            {
                var numbers = Console.ReadLine().Split().Select(a => int.Parse(a)).ToList();
                for (int i = 0; i < n; i++)
                {
                    nums.Enqueue(numbers[i]);
                }
                for (int i = 0; i < x; i++)
                {
                    nums.Dequeue();
                }
                if (nums.Contains(s))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    //var small = 0;
                    //while (nums.Count > 0)
                    //{
                    //    var popped = nums.Dequeue();
                    //    if (small < popped)
                    //    {
                    //        small = popped;
                    //    }
                    //}
                    //Console.WriteLine(small);
                    Console.WriteLine(nums.Min());
                }
            }
        }
    }
}
