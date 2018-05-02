using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.MathPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray();
            var n = int.Parse(Console.ReadLine());
            var cycleCount = 1;
            var queue = new Queue<string>(input);

            while (queue.Count > 1)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    string name = queue.Dequeue();
                    queue.Enqueue(name);
                }
                if (IsPrime(cycleCount))
                {
                    Console.WriteLine($"Prime {queue.Peek()}");
                }
                else
                {
                    Console.WriteLine($"Removed {queue.Dequeue()}");

                }
                cycleCount++;
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
        public static bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}
