using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _02.Cubic_s_Rube
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());
            BigInteger sum = 0;;
            double cellsCount = Math.Pow(dimensions, 3);
            
            string line;
            while ((line=Console.ReadLine()) != "Analyze")
            {
                var tokens = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                var row = tokens[0];
                var col = tokens[1];
                var height = tokens[2];
                long value = tokens[3];
                if (row < 0 || row > dimensions -1 || col > dimensions - 1|| col < 0 || height < 0 || height > dimensions - 1 || value == 0)
                {
                    continue;
                }
                
                sum += value;
                cellsCount -= 1;
                
            }
            Console.WriteLine(sum);
            Console.WriteLine(cellsCount);
        }
    }
}
