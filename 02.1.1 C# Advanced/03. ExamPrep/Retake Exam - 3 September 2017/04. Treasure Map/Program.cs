using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _04.Treasure_Map
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> strings = new Queue<string>();
            int n = int.Parse(Console.ReadLine());
            string pattern = @"![^#!]*?(?<![a-zA-z0-9])(?<streetName>[a-zA-Z]{4})(?![a-zA-Z0-9])[^#!]*(?<!\d)(?<streetNumber>\d{3})-(?<password>\d{4}|\d{6})(?!\d)[^#!]*?#|#[^#!]*?(?<![a-zA-z0-9])(?<streetName>[a-zA-Z]{4})(?![a-zA-Z0-9])[^#!]*(?<!\d)(?<streetNumber>\d{3})-(?<password>\d{4}|\d{6})(?!\d)[^#!]*?!";

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var matches = Regex.Matches(input, pattern);
                if (matches.Count == 1)
                {
                    var match = matches[0];
                    string streetName = match.Groups["streetName"].Value;
                    string streetNumber = match.Groups["streetNumber"].Value;
                    string password = match.Groups["password"].Value;
                    Console.WriteLine($"Go to str. {streetName} {streetNumber}. Secret pass: {password}.");
                }
                else
                {
                    if (matches.Count % 2 == 0)
                    {
                        var match = matches[matches.Count / 2];
                        string streetName = match.Groups["streetName"].Value;
                        string streetNumber = match.Groups["streetNumber"].Value;
                        string password = match.Groups["password"].Value;
                        Console.WriteLine($"Go to str. {streetName} {streetNumber}. Secret pass: {password}.");
                    }
                    else
                    {
                        var match = matches[matches.Count / 2];
                        string streetName = match.Groups["streetName"].Value;
                        string streetNumber = match.Groups["streetNumber"].Value;
                        string password = match.Groups["password"].Value;
                        Console.WriteLine($"Go to str. {streetName} {streetNumber}. Secret pass: {password}.");
                    }
                }
            }
        }
    }
}
