using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            var board = new char[size][];
            for (int i = 0; i < size; i++)
            {
                board[i] = Console.ReadLine().ToCharArray();
            }
            int counter = 0;
            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[row].Length; col++)
                {
                    if (board[row][col] == 'K')
                    {
                        CheckMoves(board, row, col, ref counter);
                    }
                }
            }
            Console.WriteLine(counter);
        }

        private static void CheckMoves(char[][] board, int row, int col, ref int counter)
        {
            if (row - 1 >= 0 && col + 2 <= board.Length - 1 && board[row - 1][col + 2] != '0')
            {
                board[row - 1][col + 2] = '0';
                counter++;
            }
            else if (row - 1 >= 0 && col - 2 >= 0 && board[row - 1][col - 2] != '0')
            {

                board[row - 1][col - 2] = '0';
                counter++;
            }
            else if (row + 1 <= board.Length - 1 && col + 2 <= board.Length - 1 && board[row + 1][col + 2] != '0')
            {
                board[row + 1][col + 2] = '0';
                counter++;
            }
            else if (row + 1 <= board.Length - 1 && col - 2 >= 0 && board[row + 1][col - 2] != '0')
            {
                board[row + 1][col - 2] = '0';
                counter++;
            }
            else if (row - 2 >= 0 && col + 1 <= board.Length - 1 && board[row - 2][col + 1] != '0')
            {
                board[row - 2][col + 1] = '0';
                counter++;
            }
            else if (row - 2 >= 0 && col - 1 >= 0 && board[row - 2][col - 1] != '0')
            {
                board[row - 2][col - 1] = '0';
                counter++;
            }
            else if (row + 2 <= board.Length - 1 && col + 1 <= board.Length - 1 && board[row + 2][col + 1] != '0')
            {

                board[row + 2][col + 1] = '0';
                counter++;
            }
            else if (row + 2 <= board.Length - 1 && col - 1 >= 0 && board[row + 2][col - 1] != '0')
            {
                board[row + 2][col - 1] = '0';
                counter++;
            }

        }
    }
}

