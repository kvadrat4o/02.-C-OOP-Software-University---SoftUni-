using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            var length = int.Parse(Console.ReadLine());
            var strings = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Predicate<string> condition = n => n.Length <= length;
            foreach (var word in strings)
            {
                if (condition(word))
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
