using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Rhombus_of_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int stars = 1; stars <= n; stars++)
            {
                PrintRow(n, stars);
            }
            for (int starCount = n - 1; starCount >= 1; starCount--)
            {
                PrintRow(n, starCount);
            }

        }

        static void PrintRow(int n, int starCount)
        {
            for (int i = 0; i < n - starCount; i++)
            {
                Console.Write(" ");
            }
            for (int col = 1; col < starCount; col++)
            {
                Console.Write("* ");
            }
            Console.WriteLine("*");
        }
    }
}
