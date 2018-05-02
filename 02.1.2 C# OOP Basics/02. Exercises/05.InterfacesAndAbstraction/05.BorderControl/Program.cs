using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' });
                if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];
                    buyers.Add(new Rebel(name, age, group));
                }
                else
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthday = input[3];
                    buyers.Add(new Citizen(id, name, age, birthday));

                }
            }
            var tokens = "";
            while ((tokens = Console.ReadLine()) != "End")
            {
                if (buyers.Any(a => a.Name == tokens))
                {
                    buyers.FirstOrDefault(a => a.Name == tokens).BuyFood();
                }
            }
            Console.WriteLine(buyers.Sum(a => a.Food));





            //var input = "";
            //List<IIdentifiable> things = new List<IIdentifiable>();
            //List<IBirthdatable> birhtdays = new List<IBirthdatable>();
            //while ((input = Console.ReadLine()) != "End")
            //{
            //    var tokens = input.Split(new char[] { ' ' });
            //    if (tokens[0].StartsWith("Pet"))
            //    {
            //        string name = tokens[1];
            //        string birthdate = tokens[2];
            //        birhtdays.Add(new Pet(name, birthdate));
            //    }
            //    else
            //    {
            //        if (tokens.Length == 3)
            //        {
            //            string model = tokens[1];
            //            string id = tokens[2];
            //            things.Add(new Robot(model, id));
            //        }
            //        else if (tokens.Length == 5)
            //        {
            //            string name = tokens[1];
            //            string id = tokens[3];
            //            string birthday = tokens[4];
            //            int age = int.Parse(tokens[2]);
            //            birhtdays.Add(new Citizen(id, name, age, birthday));
            //        }
            //    }
            //}
            //int n = int.Parse(Console.ReadLine());
            //foreach (var thing in birhtdays)
            //{
            //    if (thing.Birthday.EndsWith(n.ToString()))
            //    {
            //        Console.WriteLine(thing.Birthday); ;
            //    }
            //}
        }
    }
}
