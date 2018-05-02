using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            var input = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < input.Length; j++)
            {
                var wabamama = input[j].Split(new char[] { '=' },StringSplitOptions.RemoveEmptyEntries);
                string name = wabamama[0];
                decimal money = decimal.Parse(wabamama[1]);
                try
                {
                    Person person = new Person(name, money);
                    people.Add(person);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

            }
            var tokens = Console.ReadLine().Split(new char[] { ';' },StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tokens.Length; i++)
            {
                var wabama = tokens[i].Split(new char[] { '=' },StringSplitOptions.RemoveEmptyEntries);
                string name = wabama[0];
                decimal cost = decimal.Parse(wabama[1]);
                try
                {
                    Product prod = new Product(name, cost);
                    products.Add(prod);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
            }
            string command = "";
            while ((command = Console.ReadLine()) != "END")
            {
                var commandArgs = command.Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
                string name = commandArgs[0];
                string product = commandArgs[1];
                Person person = people.First(a => a.Name == name);
                Product prod = products.First(b => b.Name == product);
                if (person.Money >= prod.Cost)
                {
                    person.Products.Add(prod);
                    person.Money -= prod.Cost;
                    Console.WriteLine($"{person.Name} bought {prod.Name}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} can't afford {prod.Name}");
                }
            }
            foreach (var person in people)
            {
                if (person.Products.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - {String.Join(", ", person.Products.Select(p => p.Name))}");
                }
            }
        }
    }
}
