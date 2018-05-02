using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Sneaking
{
    class Sneaking
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            char[][] board = new char[rows][];
            int Nrow = 0;
            int Ncol = 0;
            int Srow = 0;
            int Scol = 0;
            for (int i = 0; i < rows; i++)
            {
                board[i] = Console.ReadLine().ToCharArray();
            }
            var directions = Console.ReadLine();
            bool isNKilled = false;
            bool isSkilled = false;
            for (int j = 0; j < board.Length; j++)
            {
                for (int k = 0; k < board[j].Length; k++)
                {
                    if (board[j][k] == 'N')
                    {
                        Nrow = j;
                        Ncol = k;
                    }
                    if (board[j][k] == 'S')
                    {
                        Srow = j;
                        Scol = k;
                    }
                }
            }
            while (directions.Length > 0 || isSkilled == false || isNKilled == false)
            {
                MoveEnemy(board, isSkilled);
                MoveSam(board, directions, isSkilled, isNKilled, Nrow, Ncol, Scol, Srow);
            }

            if (isSkilled)
            {
                Console.WriteLine($"Sam died at {Srow}, {Scol}");
            }
            if (isNKilled)
            {
                Console.WriteLine($"Nikoladze killed!");
            }
            foreach (var row in board)
            {
                Console.WriteLine(String.Join(" ", row));
            }
        }

        private static void MoveSam(char[][] board, string directions, bool isSkilled, bool isNKilled, int Nrow, int Ncol, int Scol, int Srow)
        {
            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[row].Length; col++)
                {
                    if (board[row][col] == 'S')
                    {
                        switch (directions[0])
                        {
                            case 'U':
                                if (board[row - 1][col] == 'b' || board[row - 1][col] == 'd')
                                {
                                    board[row - 1][col] = 'S';
                                    //isSkilled = true;
                                    Srow = row - 1;
                                    Scol = col;
                                    directions.Remove(0);
                                    break;
                                }
                                else
                                {
                                    if (row == Nrow)
                                    {
                                        board[Nrow][Ncol] = 'X';
                                        isNKilled = true;
                                        directions.Remove(0);
                                        break;
                                    }
                                    else
                                    {
                                        board[row - 1][col] = 'S';
                                        Srow = row - 1;
                                        Scol = col;
                                        directions.Remove(0);
                                        break;
                                    }
                                }
                            case 'D':
                                if (board[row + 1][col] == 'b' || board[row + 1][col] == 'd')
                                {
                                    board[row + 1][col] = 'S';
                                    //isSkilled = true;
                                    Srow = row + 1;
                                    Scol = col;
                                    directions.Remove(0);
                                    break;
                                }
                                else
                                {
                                    if (row == Nrow)
                                    {
                                        board[Nrow][Ncol] = 'X';
                                        isNKilled = true;
                                        directions.Remove(0);
                                        break;
                                    }
                                    else
                                    {
                                        board[row + 1][col] = 'S';
                                        Srow = row + 1;
                                        Scol = col;
                                        directions.Remove(0);
                                        break;
                                    }
                                }
                            case 'R':
                                if (board[row][col + 1] == 'b' || board[row][col + 1] == 'd')
                                {
                                    board[row][col + 1] = 'S';
                                    Srow = row;
                                    Scol = col + 1;
                                    directions.Remove(0);
                                    break;
                                }
                                else
                                {
                                    if (row == Nrow)
                                    {
                                        board[Nrow][Ncol] = 'X';
                                        isNKilled = true;
                                        directions.Remove(0);
                                        break;
                                    }
                                    else
                                    {
                                        board[row][col + 1] = 'S';
                                        Srow = row;
                                        Scol = col + 1;
                                        directions.Remove(0);
                                        break;
                                    }
                                }
                            case 'L':
                                if (board[row][col - 1] == 'b' || board[row][col - 1] == 'd')
                                {
                                    board[row][col - 1] = 'S';
                                    Srow = row;
                                    Scol = col - 1;
                                    directions.Remove(0);
                                    break;
                                }
                                else
                                {
                                    if (row == Nrow)
                                    {
                                        board[Nrow][Ncol] = 'X';
                                        isNKilled = true;
                                        directions.Remove(0);
                                        break;
                                    }
                                    else
                                    {
                                        board[row][col - 1] = 'S';
                                        Srow = row;
                                        Scol = col - 1;
                                        directions.Remove(0);
                                        break;
                                    }
                                }
                            case 'W':
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        private static void MoveEnemy(char[][] board, bool isSkilled)
        {
            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[row].Length; col++)
                {
                    if (board[row][col] == 'b' || board[row][col] == 'd')
                    {
                        if (board[row][col] == 'b')
                        {

                            if (col + 1 == board[row].Length - 1)
                            {
                                board[row][col + 1] = 'd';
                                board[row][col] = '.';
                            }
                            else
                            {
                                if (board[row][col + 1] == 'S')
                                {
                                    board[row][col + 1] = 'X';
                                    isSkilled = true;
                                    break;
                                }
                                else
                                {
                                    board[row][col + 1] = 'b';
                                    board[row][col] = '.';
                                    break;
                                }
                            }
                        }
                        if (board[row][col] == 'd')
                        {

                            if (col - 1 == 0)
                            {
                                board[row][col - 1] = 'b';
                                break;
                            }
                            else
                            {
                                if (board[row][col - 1] == 'S')
                                {
                                    board[row][col - 1] = 'X';
                                    isSkilled = true;
                                    break;
                                }
                                else
                                {
                                    board[row][col - 1] = 'd';
                                    board[row][col] = '.';
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
