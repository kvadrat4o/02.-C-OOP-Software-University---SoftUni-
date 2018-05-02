using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Target_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string snake = Console.ReadLine();
            var shotDetails = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int iRow = shotDetails[0];
            int iCol= shotDetails[1];
            int iRad = shotDetails[2];
            char[,] matrix = new char[sizes[0], sizes[1]];
            FillMatrix(matrix,snake);
            ShootMatrix(matrix, iRow, iCol, iRad);
            FallDown(matrix);




            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void FallDown(char[,] matrix)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                {
                    if (matrix[row + 1, col] !=' ')
                    {
                        continue;
                    }
                    else
                    {
                        var elements = new Queue<char>();
                        var rowCount = row;

                        for (int i = 0; i < row+1; i++)
                        {
                            elements.Enqueue(matrix[row-i, col]);
                            matrix[row - i, col] = ' ';
                        }
                        while (elements.Count > 0)
                        {
                            matrix[row+1, col] = elements.Dequeue();
                            row--;
                        }
                        row = rowCount;
                    }
                }
            }
        }

        private static void ShootMatrix(char[,] matrix, int iRow, int iCol, int iRad)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int deltaRow = row - iRow;
                    int deltaCol = col - iCol;

                    bool isInRadius = deltaRow * deltaRow + deltaCol * deltaCol <= iRad * iRad;

                    if (isInRadius)
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
        }
        private static void FillMatrix(char[,] matrix, string snake)
        {
            var rowsCount = matrix.GetLength(0);
            var index = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row % 2 == 0)
                    {
                        if (index == snake.Length)
                        {
                            index = 0;
                        }
                        matrix[matrix.GetLength(0) - 1 - row, matrix.GetLength(1) - 1 - col] = snake[index];
                        
                    }
                    else
                    {
                        if (index == snake.Length)
                        {
                            index = 0;
                        }
                        matrix[matrix.GetLength(0) - 1 - row, col] = snake[index];
                    }
                    index++;
                }
            }
        }
    }
}
