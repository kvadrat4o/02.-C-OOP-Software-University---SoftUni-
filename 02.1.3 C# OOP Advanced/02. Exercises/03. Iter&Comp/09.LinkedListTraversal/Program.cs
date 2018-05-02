using System;

namespace _09.LinkedListTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            LinkedList<int> nums = new LinkedList<int>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "Add")
                {
                    nums.Add(int.Parse(input[1]));
                }
                else
                {
                    nums.Remove(int.Parse(input[1]));
                }
            }
            Console.WriteLine($"{nums.Count}" + Environment.NewLine + $"{string.Join(" ",nums)}");
        }
    }
}
