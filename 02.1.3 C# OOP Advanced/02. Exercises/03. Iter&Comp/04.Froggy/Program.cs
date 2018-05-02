using System;
using System.Linq;

namespace _04.Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ',',' ' },StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Lake lake = new Lake();
            for (int i = 0; i < input.Count; i++)
            {
                lake.stones.Add(input[i]);
            }
            Console.WriteLine(string.Join(", ",lake));
        }
    }
}
