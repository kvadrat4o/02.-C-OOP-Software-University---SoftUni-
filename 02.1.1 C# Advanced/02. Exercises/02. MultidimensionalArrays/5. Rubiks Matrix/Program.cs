using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Rubiks_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[sizes[0], sizes[1]];
            var counter = 1;
            for (int row = 0; row < sizes[0]; row++)
            {
                for (int col = 0; col < sizes[1]; col++)
                {
                    matrix[row, col] = counter;
                    counter++;
                }
            }

            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var colOrRow = int.Parse(input[0]);
                var direction = input[1];
                var moves = int.Parse(input[2]);

                switch (direction)
                {
                    case "up":
                        var rowBecomingFirst = moves % matrix.GetLength(0);
                        if (rowBecomingFirst != 0)
                        {
                            MoveColumn(matrix, colOrRow, rowBecomingFirst);
                        }           
                        break;
                    case "down":                     
                        rowBecomingFirst = matrix.GetLength(0) - (moves % matrix.GetLength(0));
                        MoveColumn(matrix, colOrRow, rowBecomingFirst);
                        break;
                    case "left":

                        var columnBecomingFirst = moves % matrix.GetLength(1);
                        if (columnBecomingFirst != 0)
                        {
                            MoveRow(matrix, colOrRow, columnBecomingFirst);
                        }
                        break;
                    case "right":
                        columnBecomingFirst = matrix.GetLength(1) - (moves % matrix.GetLength(1));
                        MoveRow(matrix, colOrRow, columnBecomingFirst);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(SwapMatrix(matrix));

        }

        private static void MoveRow(int[,] matrix, int row, int col)
        {
            var Values = new Queue<int>();

            while (Values.Count < matrix.GetLength(1))
            {
                if (col == matrix.GetLength(1))
                {
                    col = 0;
                }
                Values.Enqueue(matrix[row, col]);
                col++;
            }
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[row, i] = Values.Dequeue();
            }
        }

        private static void MoveColumn(int[,]matrix, int col, int row)
        {
            var Values = new Queue<int>();

            while (Values.Count < matrix.GetLength(0))
            {
                if (row == matrix.GetLength(0))
                {
                    row = 0;
                }
                Values.Enqueue(matrix[row, col]);
                row++;                
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, col] = Values.Dequeue();
            }
        }
        private static string SwapMatrix(int[,] matrix)
        {
            var sb = new StringBuilder();
            var expectedValue = 1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] != expectedValue)
                    {
                        sb.Append(Swap(matrix, i, j, expectedValue));
                    }
                    else
                    {
                        sb.Append($"No swap required{Environment.NewLine}");
                    }

                    expectedValue++;
                }
            }

            return sb.ToString().Trim();
        }

        private static string Swap(int[,] matrix, int row, int col, int expectedValue)
        {
            for (int i = row; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == expectedValue)
                    {
                        var temp = matrix[i,j];
                        matrix[i,j] = matrix[row,col];
                        matrix[row,col] = temp;

                        return $"Swap ({row}, {col}) with ({i}, {j}){Environment.NewLine}";
                    }
                }
            }

            return string.Empty;
        }
    }
}
