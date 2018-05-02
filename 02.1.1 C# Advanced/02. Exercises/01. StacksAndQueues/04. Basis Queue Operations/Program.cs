using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        var input = Console.ReadLine().Split().Select(a => int.Parse(a)).ToArray();
        var nums = Console.ReadLine().Split().Select(a => int.Parse(a)).ToArray();

        int n = input[0];
        int s = input[1];
        int x = input[2];

        var q = new Queue<int>();

        for (int i = 0; i < n; i++)
        {
            q.Enqueue(nums[i]);
        }
        for (int i = 0; i < s; i++)
        {
            q.Dequeue();
        }
        if (q.Count == 0)
        {
            Console.WriteLine(0);
        }
        else
        {
            if (q.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(q.Min());
            }
        }
    }
}