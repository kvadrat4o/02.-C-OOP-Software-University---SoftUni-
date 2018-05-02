using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Radioactive_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] lair = new char[sizes[0], sizes[1]];
            int pRowIndex = 0;
            int pColIndex = 0;
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                var input = Console.ReadLine();
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    lair[row, col] = input[col];
                    if (lair[row, col] == 'P')
                    {
                        pRowIndex = row;
                        pColIndex = col;
                    }
                }
            }
            var directions = Console.ReadLine();
            MovePlayer(pRowIndex, pColIndex, lair, directions);
            
        }

        private static void MovePlayer(int pRowIndex, int pColIndex, char[,] lair, string directions)
        {
            for (int i = 0; i < directions.Length; i++)
            {
                switch (directions[i])
                {
                    case 'U':
                        if (CheckIfPlayerDiesMovingUp(lair, pRowIndex, pColIndex))
                        {
                            lair[pRowIndex, pColIndex] = 'B';
                            MultiplyBunnies(lair);
                            PrintLair(lair);
                            Console.WriteLine($"dead: {pRowIndex-1} {pColIndex}");
                            Environment.Exit(0);
                        }
                        else
                        {
                            if (CheckIfPlayerHasWonMovingUp(lair, pRowIndex))
                            {
                                lair[pRowIndex, pColIndex] = '.';
                                MultiplyBunnies(lair);
                                PrintLair(lair);
                                Console.WriteLine($"won: {pRowIndex} {pColIndex}");
                                Environment.Exit(0);
                            }

                            lair[pRowIndex - 1, pColIndex] = 'P';
                            lair[pRowIndex, pColIndex] = '.';
                            pRowIndex -= 1;
                            MultiplyBunnies(lair);
                        }
                        break;
                    case 'D':
                        if (CheckIfPlayerDiesMovingDown(lair, pRowIndex, pColIndex))
                        {
                            lair[pRowIndex, pColIndex] = 'B';
                            MultiplyBunnies(lair);
                            PrintLair(lair);
                            Console.WriteLine($"dead: {pRowIndex+1} {pColIndex}");
                            Environment.Exit(0);
                        }
                        else
                        {
                            if (CheckIfPlayerHasWonMovingDown(lair, pRowIndex))
                            {
                                lair[pRowIndex, pColIndex] = '.';
                                MultiplyBunnies(lair);
                                PrintLair(lair);
                                Console.WriteLine($"won: {pRowIndex} {pColIndex}");
                                Environment.Exit(0);
                            }
                            lair[pRowIndex + 1, pColIndex] = 'P';
                            lair[pRowIndex, pColIndex] = '.';
                            pRowIndex += 1;
                            MultiplyBunnies(lair);
                        }
                        break;
                    case 'L':
                        if (CheckIfPlayerDiesMovingLeft(lair, pRowIndex, pColIndex))
                        {
                            lair[pRowIndex, pColIndex] = 'B';
                            MultiplyBunnies(lair);
                            PrintLair(lair);
                            Console.WriteLine($"dead: {pRowIndex} {pColIndex-1}");
                            Environment.Exit(0);
                        }
                        else
                        {
                            if (CheckIfPlayerHasWonMovingLeft(lair, pColIndex))
                            {
                                lair[pRowIndex, pColIndex] = '.';
                                MultiplyBunnies(lair);
                                PrintLair(lair);
                                Console.WriteLine($"won: {pRowIndex} {pColIndex}");
                                Environment.Exit(0);
                            }
                            lair[pRowIndex, pColIndex - 1] = 'P';
                            lair[pRowIndex, pColIndex] = '.';
                            pColIndex -= 1;
                            MultiplyBunnies(lair);
                        }
                        break;
                    case 'R':
                        if (CheckIfPlayerDiesMovingRight(lair, pRowIndex, pColIndex))
                        {
                            lair[pRowIndex, pColIndex] = 'B';
                            MultiplyBunnies(lair);
                            PrintLair(lair);
                            Console.WriteLine($"dead: {pRowIndex} {pColIndex+1}");
                            Environment.Exit(0);
                        }
                        else
                        {
                            if (CheckIfPlayerHasWonMovingRight(lair, pColIndex))
                            {
                                lair[pRowIndex, pColIndex] = '.';
                                MultiplyBunnies(lair);
                                PrintLair(lair);
                                Console.WriteLine($"won: {pRowIndex} {pColIndex}");
                                Environment.Exit(0);
                            }
                            lair[pRowIndex, pColIndex + 1] = 'P';
                            lair[pRowIndex, pColIndex] = '.';
                            pColIndex += 1;
                            MultiplyBunnies(lair);
                        }
                        break;
                    default:
                        break;
                }               
            }
        }

        private static void PrintLair(char[,] lair)
        {
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    Console.Write(lair[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void MultiplyBunnies(char[,] lair)
        {
            var queue = new Queue<int[]>();
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (lair[row, col] == 'B')
                    {
                        var indices = new int[2];
                        indices[0] = row;
                        indices[1] = col;
                        queue.Enqueue(indices);
                    }
                }
            }
            while (queue.Count>0)
            {
                var indexes = queue.Dequeue();
                var row = indexes[0];
                var col = indexes[1];
                if (row != 0)
                {
                    lair[row - 1, col] = 'B';
                }
                if (row + 1 > lair.GetLength(0) -1)
                {
                    continue;
                }
                else
                {
                    lair[row + 1, col] = 'B';
                }
                if (col != 0)
                {
                    lair[row, col - 1] = 'B';
                }
                if (col + 1 > lair.GetLength(1) - 1)
                {
                    continue;
                }
                else
                {
                    lair[row, col + 1] = 'B';
                }
            }
        }



        private static bool CheckIfPlayerHasWonMovingRight(char[,] lair, int pColIndex)
        {
            bool hasWon = false;
            if (pColIndex + 1 > lair.GetLength(1) -1)
            {
                hasWon = true;
            }
            return hasWon;
        }

        private static bool CheckIfPlayerDiesMovingRight(char[,] lair, int pRowIndex, int pColIndex)
        {
            bool isDead = false;
            if (pColIndex == lair.GetLength(1))
            {
                return isDead;
            }
            if (lair[pRowIndex, pColIndex + 1] == 'B')
            {
                isDead = true;
            }
            return isDead;
        }

        private static bool CheckIfPlayerHasWonMovingLeft(char[,] lair, int pColIndex)
        {
            bool hasWon = false;
            if (pColIndex - 1 < 0)
            {
                hasWon = true;
            }
            return hasWon;
        }

        private static bool CheckIfPlayerDiesMovingLeft(char[,] lair, int pRowIndex, int pColIndex)
        {
            bool isDead = false;
            if (pColIndex == 0)
            {
                return isDead;
            }
            if (lair[pRowIndex, pColIndex - 1] == 'B')
            {
                isDead = true;
            }
            return isDead;
        }

        private static bool CheckIfPlayerHasWonMovingDown(char[,] lair, int pRowIndex)
        {
            bool hasWon = false;
            if (pRowIndex + 1 > lair.GetLength(0) - 1)
            {
                hasWon = true;
            }
            return hasWon;
        }

        private static bool CheckIfPlayerHasWonMovingUp(char[,] lair, int pRowIndex)
        {
            bool hasWon = false;
            if (pRowIndex - 1 < 0)
            {
                hasWon = true;
            }
            return hasWon;
        }

        private static bool CheckIfPlayerDiesMovingUp(char[,] lair, int pRowIndex, int pColIndex)
        {
            bool isDead = false;
            if (pRowIndex == 0)
            {
                return isDead;
            }
            if (lair[pRowIndex - 1, pColIndex] == 'B')
            {
                isDead = true;
            }
            return isDead;
        }

        private static bool CheckIfPlayerDiesMovingDown(char[,] lair, int pRowIndex, int pColIndex)
        {
            bool isDead = false;
            if (pRowIndex == lair.GetLength(0))
            {
                return isDead;
            }
            if (lair[pRowIndex + 1, pColIndex] == 'B')
            {
                isDead = true;
            }
            return isDead;
        }
    }
}
