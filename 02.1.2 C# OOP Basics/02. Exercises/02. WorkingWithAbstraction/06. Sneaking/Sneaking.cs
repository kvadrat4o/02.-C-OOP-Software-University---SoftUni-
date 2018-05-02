using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            int rowNikoladze = 0;
            var room = new char[numberOfRows][];
            FillRoom(room, numberOfRows, ref rowNikoladze);
            var directions = Console.ReadLine();


            foreach (var direction in directions)
            {
                MoveEnemies(room);
                switch (direction)
                {
                    case 'U':
                        MoveUp(direction, room, rowNikoladze);
                        break;
                    case 'D':
                        MoveDown(direction, room, rowNikoladze);
                        break;
                    case 'R':
                        MoveRight(direction, room);
                        break;
                    case 'L':
                        MoveLeft(direction, room);
                        break;
                    case 'W':
                        continue;
                    default:
                        break;
                }
            }
        }

        private static void MoveLeft(char direction, char[][] room)
        {
            bool samMoved = false;
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        if (room[row][col - 1] == 'd' || room[row][col - 1] == 'b' || room[row][col - 1] == '.')
                        {
                            room[row][col - 1] = 'S';
                            room[row][col] = '.';
                            samMoved = true;
                            if (CheckIfEnemySeesSam(room))
                            {
                                int[] position = FindSamPosition(room);
                                Console.WriteLine($"Sam died at {position[0]}, {position[1]}");
                                room[position[0]][position[1]] = 'X';
                                PrintRoom(room);
                                Environment.Exit(0);
                            }
                        }
                    }
                }
                if (samMoved)
                {
                    break;
                }
            }
        }

        private static void MoveRight(char direction, char[][] room)
        {
            bool samMoved = false;
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        if (room[row][col + 1] == 'd' || room[row][col + 1] == 'b' || room[row][col + 1] == '.')
                        {
                            room[row][col + 1] = 'S';
                            room[row][col] = '.';
                            samMoved = true;
                            if (CheckIfEnemySeesSam(room))
                            {
                                int[] position = FindSamPosition(room);
                                Console.WriteLine($"Sam died at {position[0]}, {position[1]}");
                                room[position[0]][position[1]] = 'X';
                                PrintRoom(room);
                                Environment.Exit(0);
                            }
                        }
                    }
                    if (samMoved)
                    {
                        break;
                    }
                }
            }
        }

        private static void MoveDown(char direction, char[][] room, int rowNikoladze)
        {
            bool samMoved = false;
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        if (room[row + 1][col] == 'd' || room[row + 1][col] == 'b' || room[row + 1][col] == '.')
                        {
                            room[row + 1][col] = 'S';
                            room[row][col] = '.';
                            samMoved = true;
                            if (row + 1 == rowNikoladze)
                            {
                                Console.WriteLine("Nikoladze killed!");
                                FindAndPrintNikoladzeLocation(room);
                                Environment.Exit(0);
                            }
                            if (CheckIfEnemySeesSam(room))
                            {
                                int[] position = FindSamPosition(room);
                                Console.WriteLine($"Sam died at {position[0]}, {position[1]}");
                                room[position[0]][position[1]] = 'X';
                                PrintRoom(room);
                                Environment.Exit(0);
                            }
                        }
                        break;
                    }
                }
                if (samMoved)
                {
                    break;
                }
            }
        }

        private static bool CheckIfEnemySeesSam(char[][] room)
        {
            int[] position = FindSamPosition(room);
            for (int rowIndex = 0; rowIndex < room.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < room[rowIndex].Length; colIndex++)
                {
                    if (room[rowIndex][colIndex] == 'b' && colIndex < position[1] && rowIndex == position[0])
                    {
                        return true;
                    }
                    else if (room[rowIndex][colIndex] == 'd' && colIndex > position[1] && rowIndex == position[0])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static int[] FindSamPosition(char[][] room)
        {
            int[] position = new int[2];
            for (int i = 0; i < room.Length; i++)
            {
                for (int j = 0; j < room[i].Length; j++)
                {
                    if (room[i][j] == 'S')
                    {
                        position[0] = i;
                        position[1] = j;
                        return position;
                    }
                }
            }
            return position;
        }

        private static void MoveUp(char direction, char[][] room, int rowNikoladze)
        {
            bool samMoved = false;
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        if (room[row - 1][col] == 'd' || room[row - 1][col] == 'b' || room[row - 1][col] == '.')
                        {
                            room[row - 1][col] = 'S';
                            room[row][col] = '.';
                            samMoved = true;
                            if (row - 1 == rowNikoladze)
                            {
                                Console.WriteLine("Nikoladze killed!");
                                FindAndPrintNikoladzeLocation(room);
                                Environment.Exit(0);
                            }
                            if (CheckIfEnemySeesSam(room))
                            {
                                int[] position = FindSamPosition(room);
                                Console.WriteLine($"Sam died at {position[0]}, {position[1]}");
                                room[position[0]][position[1]] = 'X';
                                PrintRoom(room);
                                Environment.Exit(0);
                            }
                        }
                        break;
                    }
                }
                if (samMoved)
                {
                    break;
                }
            }
        }

        private static void FindAndPrintNikoladzeLocation(char[][] room)
        {
            bool nikoladzeFound = false;
            for (int row = 0; row < room.Length; row++)
            {
                if (nikoladzeFound)
                {
                    break;
                }
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'N')
                    {
                        room[row][col] = 'X';
                    }
                }
            }
            PrintRoom(room);
            Environment.Exit(0);
        }

        private static void PrintRoom(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                Console.WriteLine(string.Join("", room[row]));
            }
            Environment.Exit(0);
        }

        private static void MoveEnemies(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (col == room[row].Length - 1)
                        {
                            room[row][col] = 'd';
                            if (CheckIfEnemySeesSam(room))
                            {
                                int[] position = FindSamPosition(room);
                                Console.WriteLine($"Sam died at {position[0]}, {position[1]}");
                                room[position[0]][position[1]] = 'X';
                                PrintRoom(room);
                                Environment.Exit(0);
                            }
                            break;
                        }
                        else
                        {

                            room[row][col + 1] = 'b';
                            room[row][col] = '.';
                            if (CheckIfEnemySeesSam(room))
                            {
                                int[] position = FindSamPosition(room);
                                Console.WriteLine($"Sam died at {position[0]}, {position[1]}");
                                room[position[0]][position[1]] = 'X';
                                PrintRoom(room);
                                Environment.Exit(0);
                            }
                            break;
                        }
                    }
                    else if (room[row][col] == 'd')
                    {
                        if (col == 0)
                        {
                            room[row][col] = 'b';
                            if (CheckIfEnemySeesSam(room))
                            {
                                int[] position = FindSamPosition(room);
                                Console.WriteLine($"Sam died at {position[0]}, {position[1]}");
                                room[position[0]][position[1]] = 'X';
                                PrintRoom(room);
                                Environment.Exit(0);
                            }
                            break;
                        }
                        else
                        {
                            room[row][col - 1] = 'd';
                            room[row][col] = '.';
                            if (CheckIfEnemySeesSam(room))
                            {
                                int[] position = FindSamPosition(room);
                                Console.WriteLine($"Sam died at {position[0]}, {position[1]}");
                                room[position[0]][position[1]] = 'X';
                                PrintRoom(room);
                                Environment.Exit(0);
                            }
                            break;
                        }
                    }
                }
            }
        }

        private static void FillRoom(char[][] room, int numberOfRows, ref int rowNikoladze)
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                room[i] = Console.ReadLine().ToCharArray();
                if (room[i].Contains('N'))
                {
                    rowNikoladze = i;
                }
            }
        }
    }
}
