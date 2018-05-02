using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            var guests = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string line;
            while ((line = Console.ReadLine()) != "Party!")
            {
                var tokens = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];
                var condition = tokens[1];
                var element = tokens[2];
                Func<string, bool> IfEndsWith = n => n.EndsWith(element);
                Func<string, bool> IfStartsWith = n => n.StartsWith(element);
                Func<string, bool> IfLengthIsEqual = n => n.Length == int.Parse(element);
                switch (command)
                {
                    case "Remove":
                        for(int i = guests.Count - 1; i >= 0; i--)
                        {
                            if (condition == "StartsWith")
                            {
                                if (IfStartsWith(guests[i]))
                                {
                                    guests.Remove(guests[i]);
                                }
                            }
                            else if (condition == "EndsWith")
                            {
                                if (IfEndsWith(guests[i]))
                                {
                                    guests.Remove(guests[i]);
                                }
                            }
                            else if ( condition == "Length")
                            {                                
                                if (IfLengthIsEqual(guests[i]))
                                {
                                    guests.Remove(guests[i]);
                                }
                            }
                        }                        
                        break;
                    case "Double":
                        for (int i = guests.Count-1; i >= 0; i--)
                        {
                            if (condition == "StartsWith")
                            {
                                if (IfStartsWith(guests[i]))
                                {
                                    guests.Insert(i+1, guests[i]);
                                }
                            }
                            else if (condition == "EndsWith")
                            {
                                if (IfEndsWith(guests[i]))
                                {
                                    guests.Insert(i+1, guests[i]);
                                }
                            }
                            else
                            {
                                if (IfLengthIsEqual(guests[i]))
                                {
                                    guests.Insert(i+1, guests[i]);
                                }            
                            }
                        }
                        
                        break;
                    default:
                        break;
                }          
            }
            if (guests.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
            }
        }
    }
}
