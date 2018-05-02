using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int num = int.Parse(Console.ReadLine());
            Func<int, bool> isDevisibleByN = n => n % num == 0;
            List<int> wabamama = FindNums(input, isDevisibleByN);
            wabamama.Reverse();
            Console.WriteLine(String.Join(" ",wabamama));
        }

        private static List<int> FindNums(List<int> input, Func<int, bool> isDevisibleByN)
        {
            List<int> newList = new List<int>();
            foreach (var num in input)
            {
                if (isDevisibleByN(num) == false)
                {
                    newList.Add(num);
                }
            }
            return newList;
        }
    }
}
