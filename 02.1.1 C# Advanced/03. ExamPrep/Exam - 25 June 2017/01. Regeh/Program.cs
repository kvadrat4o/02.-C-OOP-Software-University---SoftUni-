using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _01.Regeh
{
    class Regeh
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            int startIndex = 0;
            int endIndex = 0;
            var indexes = new List<int>();
            var stringMatches = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '[')
                {
                    startIndex = i;
                }
                if (input[i] == ']')
                {
                    endIndex = i;
                }
                if (endIndex != 0 && startIndex != 0 && startIndex < endIndex)
                {
                    indexes.Add(startIndex);
                    indexes.Add(endIndex);
                    startIndex = 0; endIndex = 0;
                }
            }

            var pattern = @"\[.+\<(\d+)REGEH(\d+)\>.+\]";
            var sumIndexes = 0;
            var firstIndex = 0;
            var secondIndex = 0;

            //for (int i = 0; i < input.Length; i++)
            //{
            //    Console.WriteLine($"{i} - {input[i]}");
            //}

            for (int i = 0; i < indexes.Count; i += 2)
            {
                var substr = input.Substring(indexes[i], indexes[i + 1] - indexes[i] + 1);
                var regex = Regex.Match(substr, pattern);

                if (regex.Success)
                {
                    firstIndex += int.Parse(regex.Groups[1].Value) % input.Length;
                    secondIndex = (int.Parse(regex.Groups[2].Value) + firstIndex) % input.Length;
                    Console.Write($"{input[firstIndex]}{input[secondIndex]}");

                    firstIndex = secondIndex;
                }

            }
        }
    }
}
