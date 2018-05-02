using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Lego_Blocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] firstJaggedArray = new int[rows][];
            int[][] secondJaggedArray = new int[rows][];
            var secondArrayIndex = 0;
            for (int i = 0; i < rows*2; i++)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                if (i < rows)
                {
                    firstJaggedArray[i] = input;
                }
                else
                {
                    secondJaggedArray[secondArrayIndex] = input;
                    secondArrayIndex++;
                }
            }
            int[][] resultMatrice = new int[rows][];
            ReverseSecondArray(secondJaggedArray);
            CombineMatrices(firstJaggedArray, secondJaggedArray, resultMatrice);
            if (CheckIfMatrix(resultMatrice))
            {
                foreach (var row in resultMatrice)
                {
                    Console.WriteLine($"[{string.Join(", ",row)}]");
                }
            }
            else
            {
                int cellsCount = 0;
                for (int row = 0; row < resultMatrice.Length; row++)
                {
                    for (int col = 0; col < resultMatrice[row].Length; col++)
                    {
                        cellsCount++;
                    }
                }
                Console.WriteLine($"The total number of cells is: {cellsCount}");
            }
        }

        private static bool CheckIfMatrix(int[][] resultMatrice)
        {
            var firstRowLength = resultMatrice[0].Length;
            bool isMatrix = false;
            for (int row = 1; row < resultMatrice.Length; row++)
            {
                if (resultMatrice[row].Length != firstRowLength)
                {
                    isMatrix = false;
                }
                else
                {
                    isMatrix = true;
                }
            }
            return isMatrix;
        }

        private static void CombineMatrices(int[][] firstJaggedArray, int[][] secondJaggedArray, int[][] resultMatrice)
        {
            for (int row = 0; row < firstJaggedArray.Length; row++)
            {
                resultMatrice[row] = new int[firstJaggedArray[row].Length + secondJaggedArray[row].Length];
                var secondMatriceColIndex = 0;
                for (int col = 0; col < resultMatrice[row].Length; col++)
                {
                    
                    if (col >= firstJaggedArray[row].Length)
                    {
                        
                        resultMatrice[row][col] = secondJaggedArray[row][secondMatriceColIndex];
                        secondMatriceColIndex++;
                    }
                    else
                    {
                        resultMatrice[row][col] = firstJaggedArray[row][col];
                    }
                }
            }
        }

        private static void ReverseSecondArray(int[][] secondJaggedArray)
        {
            for (int row = 0; row < secondJaggedArray.Length; row++)
            {
                Stack<int> currRow = new Stack<int>();

                for (int col = 0; col < secondJaggedArray[row].Length; col++)
                {
                    currRow.Push(secondJaggedArray[row][col]);
                }
                for (int i = 0; i < secondJaggedArray[row].Length; i++)
                {
                    secondJaggedArray[row][i] = currRow.Pop();
                }
            }
        }
    }
}
