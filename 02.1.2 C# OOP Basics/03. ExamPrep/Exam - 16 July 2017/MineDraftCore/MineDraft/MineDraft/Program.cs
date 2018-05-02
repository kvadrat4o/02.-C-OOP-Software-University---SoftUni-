using System;
using System.Linq;

namespace MineDraft
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "";
            DraftManager df = new DraftManager();
            while ((input = Console.ReadLine()) != "Shutdown")
            {
                var tokens = input.Split().ToList();
                switch (tokens[0])
                {
                    case "RegisterHarvester":
                        Console.WriteLine(df.RegisterHarvester(tokens.Skip(1).ToList()));
                        break;
                    case "RegisterProvider":
                        Console.WriteLine(df.RegisterProvider(tokens.Skip(1).ToList()));
                        break;
                    case "Day":
                        Console.WriteLine(df.Day());
                        break;
                    case "Mode":
                        Console.WriteLine(df.Mode(tokens.Skip(1).ToList()));
                        break;
                    case "Check":
                        Console.WriteLine(df.Check(tokens.Skip(1).ToList()));
                        break;
                    default:
                        throw new ArgumentException("Invalid command");
                }
            }
            Console.WriteLine(df.ShutDown());
        }
    }
}
