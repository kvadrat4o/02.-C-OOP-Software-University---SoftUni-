using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        CarManager cm = new CarManager();

        var input = "";
        while ((input = Console.ReadLine()) != "Cops Are Here")
        {
            var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            switch (tokens[0])
            {
                case "register":
                    cm.Register(int.Parse(tokens[1]), tokens[2], tokens[3], tokens[4], int.Parse(tokens[5]), int.Parse(tokens[6]), int.Parse(tokens[7]), int.Parse(tokens[8]),int.Parse(tokens[9]));
                    break;
                case "open":
                    cm.Open(int.Parse(tokens[1]), tokens[2], int.Parse(tokens[3]), tokens[4], int.Parse(tokens[5]));
                    break;
                case "check":
                    Console.WriteLine(cm.Check(int.Parse(tokens[1])));
                    break;
                case "start":
                    Console.WriteLine(cm.Start(int.Parse(tokens[1])));
                    break;
                case "participate":
                    cm.Participate(int.Parse(tokens[1]), int.Parse(tokens[2]));
                    break;
                case "park":
                    cm.Park(int.Parse(tokens[1]));
                    break;
                case "unpark":
                    cm.Unpark(int.Parse(tokens[1]));
                    break;
                case "tune":
                    cm.Tune(int.Parse(tokens[1]), tokens[2]);
                    break;
                default:
                    break;
            }

        }
    }
}
