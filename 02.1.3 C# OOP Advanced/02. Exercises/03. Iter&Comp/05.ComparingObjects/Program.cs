using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            var input = "";
            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split();
                people.Add(new Person(tokens[0], int.Parse(tokens[1]), tokens[2]));
            }
            int n = int.Parse(Console.ReadLine());
            if (n + 1 > people.Count)
            {
                Console.WriteLine("No matches");
                return;
            }
            Person nth = people[n - 1];
            int equals = 0;
            int notEquals = 0;
            foreach (var person in people)
            {
                if (person.CompareTo(nth) == 0)
                {
                    equals++;
                }
                else
                {
                    notEquals++;
                }
            }
            Console.WriteLine($"{equals} {notEquals} {people.Count}");
        }
    }
}
