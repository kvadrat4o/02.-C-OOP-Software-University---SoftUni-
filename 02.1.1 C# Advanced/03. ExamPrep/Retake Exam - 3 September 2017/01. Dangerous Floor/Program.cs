//Rextester.Program.Main is the entry point for your code. Don't change it.
//Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            char[][] board = new char[8][];
            for (int i = 0; i < 8; i++)
            {
                var input = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                board[i] = input;
            }
            string move;
            while ((move = Console.ReadLine()) != "END")
            {
                var figure = move[0];
                var startRow = int.Parse(move[1].ToString());
                var startCol = int.Parse(move[2].ToString());
                var endRow = int.Parse(move[4].ToString());
                var endCol = int.Parse(move[5].ToString());

                if (!CheckIfFigureExists(board, figure, ref startRow, ref startCol))
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }
                else if (!isValidMove(board, figure, ref startRow, ref startCol, ref endRow, ref endCol))
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }
                else if (getsOutOfBoard(board, figure, ref startRow, ref startCol, ref endRow, ref endCol))
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }
                MoveFigure(board, figure, ref startRow, ref startCol, ref endRow, ref endCol);

            }
        }
        private static bool CheckIfFigureExists(char[][] board, char figure, ref int startRow, ref int startCol)
        {
            if (board[startRow][startCol] != figure)
            {
                return false;
            }
            return true;
        }
        private static bool isValidMove(char[][] board, char figure, ref int startRow, ref int startCol, ref int endRow, ref int endCol)
        {
            if (figure == 'K')
            {
                if ((startRow - 1 == endRow || startRow + 1 == endRow || startRow == endRow) && (startCol - 1 == endCol || startCol + 1 == endCol || startCol == endCol))
                {
                    return true;
                }
            }
            else if (figure == 'R')
            {
                if (startRow == endRow || startCol == endCol)
                {
                    return true;
                }
            }
            else if (figure == 'B')
            {
                if (Math.Abs(endRow - startRow) == Math.Abs(endCol - startCol))
                {
                    return true;
                }
            }
            else if (figure == 'Q')
            {
                if ((Math.Abs(endRow - startRow) == Math.Abs(endCol - startCol) || startRow == endRow || startCol == endCol))
                {
                    return true;
                }
            }
            else if (figure == 'P')
            {
                if (startRow - 1 == endRow && startCol == endCol)
                {
                    return true;
                }
            }
            return false;
        }
        private static bool getsOutOfBoard(char[][] board, char figure, ref int startRow, ref int startCol, ref int endRow, ref int endCol)
        {
            if (endRow < 0 || endRow > board.Length - 1 || endCol < 0 || endCol > board.Length - 1)
            {
                return true;
            }
            return false;
        }
        private static void MoveFigure(char[][] board, char figure, ref int startRow, ref int startCol, ref int endRow, ref int endCol)
        {
            if (board[endRow][endCol] == 'x')
            {
                board[endRow][endCol] = figure;
                board[startRow][startCol] = 'x';
            }
        }
    }
}