using System;
using System.Linq;

namespace Minedraft
{
    class Program
    {
        static void Main(string[] args)
        {
            var minedraft = new DraftManager();

            ReadCommands(minedraft);
        }

        private static void ReadCommands(DraftManager minedraft)
        {
            string line;
            while ((line = Console.ReadLine()) != "Shutdown")
            {
                var tokens = line.Split().ToList();

                switch (tokens[0])
                {
                    case "RegisterHarvester":
                        Console.WriteLine(minedraft.RegisterHarvester(tokens.Skip(1).ToList()));
                        break;

                    case "RegisterProvider":
                        Console.WriteLine(minedraft.RegisterProvider(tokens.Skip(1).ToList()));
                        break;

                    case "Day":
                        Console.WriteLine(minedraft.Day());
                        break;

                    case "Mode":
                        Console.WriteLine(minedraft.Mode(tokens.Skip(1).ToList()));
                        break;

                    case "Check":
                        Console.WriteLine(minedraft.Check(tokens.Skip(1).ToList()));
                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine(minedraft.ShutDown());
            Environment.Exit(0);
        }
    }
}
