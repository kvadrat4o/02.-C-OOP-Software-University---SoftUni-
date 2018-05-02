using System;
using System.Collections.Generic;

namespace _05._HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<String>(Console.ReadLine().Split());
            int num = int.Parse(Console.ReadLine());
            while (queue.Count >1)
            {
                for (int i = 0; i < num - 1; i++)
                {
                    var first = queue.Dequeue();
                    queue.Enqueue(first);
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
