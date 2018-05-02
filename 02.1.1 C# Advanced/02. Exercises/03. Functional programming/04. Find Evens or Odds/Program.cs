using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            var bounds = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var condition = Console.ReadLine().Trim().ToLower();
            Predicate<int> predicate;
            switch (condition)
            {
                case "odd": predicate = x => x % 2 != 0;
                    break;
                case "even": predicate = x => x % 2 == 0;
                    break;
                default:
                    predicate = null;
                    break;
            }
            var answer = PrintNums(predicate, bounds[0], bounds[1]);
            Console.WriteLine(String.Join(" ",answer));
        }

        private static Queue<int> PrintNums(Predicate<int> predicate, int v1, int v2)
        {
            Queue<int> nums = new Queue<int>();
            for (int i = v1; i <= v2; i++)
            {
                if (predicate(i))
                {
                    nums.Enqueue(i);
                }
            }
            return nums;
        }
    }
}
