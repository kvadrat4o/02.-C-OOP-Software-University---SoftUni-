using System;

namespace _10.ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "";
            while ((input=  Console.ReadLine()) != "End")
            {
                var tokens = input.Split();
                Citizen cit = new Citizen(tokens[0], int.Parse(tokens[2]), tokens[1]);
                IResident ires = cit;
                IPerson ips = cit;
                Console.WriteLine($"{cit.Name}\n{ires.GetName()}{ips.GetName()}");
            }
        }
    }
}
