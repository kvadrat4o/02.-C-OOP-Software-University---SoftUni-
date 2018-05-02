using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.String_Matrix_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            var rotation = Console.ReadLine();
            var matrix = new List<List<char>>();
            string line;
            var bestRowLength = 0;
            while ((line = Console.ReadLine()) != "END")
            {
                if (bestRowLength < line.Length)
                {
                    bestRowLength = line.Length;
                }
                matrix.Add(line.ToList());
            }
            var realMatrix = new char[matrix.Count, bestRowLength];
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < bestRowLength; j++)
                {
                    if (j > matrix[i].Count - 1)
                    {
                        continue;
                    }
                    realMatrix[i, j] = matrix[i][j];
                }
            }
            for (int i = 0; i < realMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < realMatrix.GetLength(1); j++)
                {
                    if (realMatrix[i,j] == '\0')
                    {
                        realMatrix[i, j] = ' ';
                    }
                }
            }
            var tokens = rotation.Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            var degrees = int.Parse(tokens[1]) % 360;

            switch (degrees)
            {
                case 0:
                    PrintMatrix(realMatrix);
                    break;
                case 90:
                    PrintRotatedMatrix90(realMatrix);
                    break;
                case 180:
                    PrintRotatedMatrix180(realMatrix);
                    break;
                case 270:
                    PrintRotatedMatrix270(realMatrix);
                    break;
                default:
                    break;
            }
        }

        private static void PrintMatrix(char [,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }

        private static void PrintRotatedMatrix90(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = matrix.GetLength(0) - 1; j >= 0; j--)
                {
                    Console.Write(matrix[j, i]);
                }
                Console.WriteLine();
            }
        }

        private static void PrintRotatedMatrix180(char[,] matrix)
        {
            for (int i = matrix.GetLength(0) - 1; i >= 0 ; i--)
            {
                for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void PrintRotatedMatrix270(char[,] matrix)
        {
            for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
