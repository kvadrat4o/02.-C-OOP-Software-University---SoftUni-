namespace _14.Cat_Lady
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            List<Cat> cats = new List<Cat>();
            var input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[1];
                string breed = tokens[0];
                double prop = double.Parse(tokens[2]);
                
                if (!cats.Any(a => a.Name == name))
                {
                    Cat cat = new Cat() { Name = name, Breed = breed, Prop = prop };
                    cats.Add(cat);
                }
                else
                {
                    cats.First(p => p.Name == name).Prop = prop;
                }
            }
            var command = Console.ReadLine();
            if (cats.Any(a => a.Name == command))
            {
                var currCat = cats.Where(a => a.Name == command).FirstOrDefault();
                Console.WriteLine(currCat.ToString());
            }
        }
    }
}
