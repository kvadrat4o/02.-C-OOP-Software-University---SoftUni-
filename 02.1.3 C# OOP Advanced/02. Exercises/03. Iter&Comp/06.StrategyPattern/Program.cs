using System;
using System.Collections.Generic;

namespace _06.StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Person> peopleSortedByName = new SortedSet<Person>(new PersonNameComparer());
            SortedSet<Person> peopleSortedByAge = new SortedSet<Person>(new PersonAgeComparer());
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();
                peopleSortedByAge.Add(new Person(tokens[0], int.Parse(tokens[1])));
                peopleSortedByName.Add(new Person(tokens[0], int.Parse(tokens[1])));
            }
            Console.WriteLine(string.Join(Environment.NewLine, peopleSortedByName));
            Console.WriteLine(string.Join(Environment.NewLine, peopleSortedByAge));
        }
    }
}
