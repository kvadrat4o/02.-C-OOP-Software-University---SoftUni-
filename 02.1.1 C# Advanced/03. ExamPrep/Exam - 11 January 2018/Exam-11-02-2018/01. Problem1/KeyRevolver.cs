using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            var bullets = new Stack<int>(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            var locks = new Queue<int>(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            int valueOfIntelligence = int.Parse(Console.ReadLine());
            int count = 0;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                count++;

                var @lock = locks.Peek();
                var bullet = bullets.Peek();
                if (bullet <= @lock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                    bullets.Pop();
                    valueOfIntelligence -= bulletPrice;
                }
                else
                {
                    Console.WriteLine("Ping!");
                    bullets.Pop();
                    valueOfIntelligence -= bulletPrice;
                }
                if (count == gunBarrelSize && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    count = 0;
                }
            }
            if (bullets.Count == 0 && locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${valueOfIntelligence}");
            }
            else if (bullets.Count == 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${valueOfIntelligence}");
            }

        }
    }
}