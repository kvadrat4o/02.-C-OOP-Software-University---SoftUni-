using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.EqualityLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Person> sortedPeople = new SortedSet<Person>();
            HashSet<Person> hashedPeople = new HashSet<Person>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();
                Person person = new Person(tokens[0], int.Parse(tokens[1]));
                if (!sortedPeople.Any(sp => sp.Equals(person))  && !sortedPeople.Any(sp => sp.GetHashCode() == person.GetHashCode()))
                {
                    sortedPeople.Add(person);
                }
                hashedPeople.Add(person);
            }
            Console.WriteLine($"{sortedPeople.Count}" + Environment.NewLine + $"{hashedPeople.Count}");
        }
    }
}
