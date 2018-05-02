using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[sizes[0], sizes[1]];
            var sum = int.MinValue;
            for (int row = 0; row < sizes[0]; row++)
            {
                var input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < sizes[1]; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int bestRowIndex = 0;
            int bestColIndex = 0;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    var currectSum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];
                    if (currectSum > sum)
                    {
                        sum = currectSum;
                        bestRowIndex = i;
                        bestColIndex = j;
                    }
                }
            }

            Console.WriteLine($"{matrix[bestRowIndex, bestColIndex]} {matrix[bestRowIndex, bestColIndex + 1]}");
            Console.WriteLine($"{matrix[bestRowIndex+1, bestColIndex]} {matrix[bestRowIndex+1, bestColIndex+1]}");
            Console.WriteLine(sum);
        }
    }
}
