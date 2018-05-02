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
            int counter = 1;
            while (queue.Count > 1)
            {
                for (int i = 0; i < num - 1; i++)
                {
                    var first = queue.Dequeue();
                    queue.Enqueue(first);
                }
                if (IsPrime(counter))
                {
                    Console.WriteLine($"Prime {queue.Peek()}");
                }
                else
                {
                    var removed = queue.Dequeue();
                    Console.WriteLine($"Removed {removed}");
                }
                counter++;
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }

        private static bool IsPrime(int counter)
        {
            if (counter == 1) return false;
            if (counter == 2) return true;
            if (counter % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(counter));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (counter % i == 0) return false;
            }

            return true;
        }
    }
}

