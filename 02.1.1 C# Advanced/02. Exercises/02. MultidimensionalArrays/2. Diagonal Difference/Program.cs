using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[][] matrix = new int[size][];
            for (int row = 0; row < size; row++)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                matrix[row] = input;
            }
            double primaryDSum = 0;
            double secondaryDSum = 0;
            primaryDSum = matrix[0][0] + matrix[size-1][size-1];
            secondaryDSum = matrix[0][size-1] + matrix[size-1][0];

            for (int row = 1; row < matrix.Length - 1; row++)
            {
                for (int col = 1; col < matrix[0].Length - 1; col++)
                {
                    if (row == col)
                    {
                        primaryDSum += matrix[row][col];
                    }
                    if (row + col == matrix.Length - 1)
                    {
                        secondaryDSum += matrix[row][col];
                    }
                }
            }
            Console.WriteLine(Math.Abs(secondaryDSum- primaryDSum));
        }
    }
}
