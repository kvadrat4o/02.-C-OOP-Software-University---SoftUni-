using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<Person> persons = new List<Person>();
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(new char[] { ' '},StringSplitOptions.RemoveEmptyEntries);
            string name = input[0];
            int age = int.Parse(input[1]);
            Person curr = new Person(name, age);
            persons.Add(curr);
        }
        foreach (var person in persons.Where(a => a.Age > 30).OrderBy(a => a.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}
