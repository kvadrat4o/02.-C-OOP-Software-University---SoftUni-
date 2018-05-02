using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Google
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            var input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
                switch (tokens[1])
                {
                    case "company":
                        var cName = tokens[2];
                        var dept = tokens[3];
                        var salary = double.Parse(tokens[4]);
                        Company comp = new Company() { Name = cName, Department = dept, Salary = salary };
                        if (!people.Any(a => a.Name == tokens[0]))
                        {
                            people.Add(new Person() { Name = tokens[0], Company = comp });
                        }
                        else
                        {
                            people.Where(a => a.Name == tokens[0]).First().Company = comp;
                        }
                        break;
                    case "pokemon":
                        var pName = tokens[2];
                        var pType = tokens[3];
                        Pokemon pokemon = new Pokemon() { Name = pName, Type = pType };
                        if (!people.Any(a => a.Name == tokens[0]))
                        {
                            people.Add(new Person() { Name = tokens[0], Pokemons = new List<Pokemon>() { pokemon} });
                        }
                        else
                        {
                            people.Where(a => a.Name == tokens[0]).First().Pokemons.Add(pokemon);
                        }
                        break;
                    case "parents":
                        var parentName = tokens[2];
                        var parentBday = tokens[3];
                        Parent parent = new Parent() { Name = parentName, Birthday = parentBday};
                        if (!people.Any(a => a.Name == tokens[0]))
                        {
                            people.Add(new Person() { Name = tokens[0], Parents = new List<Parent>() { parent } });
                        }
                        else
                        {
                            people.Where(a => a.Name == tokens[0]).First().Parents.Add(parent);
                        }
                        break;
                    case "children":
                        var childName = tokens[2];
                        var childBday = tokens[3];
                        Child child = new Child() { Name = childName, Birthday = childBday };
                        if (!people.Any(a => a.Name == tokens[0]))
                        {
                            people.Add(new Person() { Name = tokens[0], Children = new List<Child>() { child } });
                        }
                        else
                        {
                            people.Where(a => a.Name == tokens[0]).First().Children.Add(child);
                        }
                        break;
                    case "car":
                        var model = tokens[2];
                        var speed = tokens[3];
                        Car car = new Car() { Model = model, Speed = speed };
                        if (!people.Any(a => a.Name == tokens[0]))
                        {
                            people.Add(new Person() { Name = tokens[0], Car = car });
                        }
                        else
                        {
                            people.Where(a => a.Name == tokens[0]).First().Car = car;
                        }
                        break;
                    default:
                        break;
                }
                
            }
            var command = Console.ReadLine();
            Person p = people.Where(x => x.Name == command).FirstOrDefault();
            Console.WriteLine(p.ToString());
        }
    }
}
