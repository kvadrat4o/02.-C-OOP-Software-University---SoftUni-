using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //Team wabamama = new Team("WabaMama");
        var team = new Team("WabaMama");
        List<Person> people = new List<Person>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Person person = new Person(input[0], input[1], int.Parse(input[2]), decimal.Parse(input[3]));
            people.Add(person);
        }
        foreach (var person in people)
        {
            team.AddPlayer(person);
        }
        Console.WriteLine(team.ToString());
    }
}
