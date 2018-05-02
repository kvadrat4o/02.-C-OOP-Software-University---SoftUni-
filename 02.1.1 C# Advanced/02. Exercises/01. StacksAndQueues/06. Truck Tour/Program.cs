using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var q = new Queue<int[]>();



            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                q.Enqueue(input);
            }
            for (int i = 0; i < n - 1; i++)
            {
                int fuel = 0;
                bool isSolution = true;
                for (int j = 0; j < n; j++)
                {
                    var currPump = q.Dequeue();
                    var fuelPump = currPump[0];
                    var nextPumpDist = currPump[1];
                    fuel += fuelPump - nextPumpDist;
                    q.Enqueue(currPump);
                    if (fuel < 0)
                    {
                        i += j;
                        isSolution = false;
                        break;
                    }
                }
                if (isSolution)
                {
                    Console.WriteLine(i);
                    Environment.Exit(0);
                }
            }   
        }
    }
}
