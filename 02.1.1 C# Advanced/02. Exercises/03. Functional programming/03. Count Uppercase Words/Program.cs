using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
            Func<string, bool> isUppercaseWord = n => char.IsUpper(n[0]);
            foreach (var word in input)
            {
                if (isUppercaseWord(word))
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
