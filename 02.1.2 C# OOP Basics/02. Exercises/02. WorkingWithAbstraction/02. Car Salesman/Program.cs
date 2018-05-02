using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Car_Salesman
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            int val;
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
                Engine currEngine = new Engine();
                currEngine.Model = input[0];
                currEngine.Power = input[1];
                if (input.Length == 4)
                {
                    currEngine.Displacement = input[2];
                    currEngine.Efficiency = input[3];
                }
                else if(input.Length == 3)
                {
                    if (int.TryParse(input[2], out val))
                    {
                        currEngine.Displacement = input[2];
                    }
                    else
                    {
                        currEngine.Efficiency = input[2];
                    }
                }
                engines.Add(currEngine);
            }
            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                var tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Car currCar = new Car();
                currCar.Model = tokens[0];
                if (engines.Any(a => a.Model == tokens[1]))
                {
                    var engine = engines.Where(b => b.Model == tokens[1]).First();
                    currCar.Engine = engine;
                }
                if (tokens.Length == 4)
                {
                    currCar.Weight = tokens[2];
                    currCar.Color = tokens[3];
                }
                else if (tokens.Length == 3)
                {
                    if (int.TryParse(tokens[2], out val))
                    {
                        currCar.Weight = tokens[2];
                    }
                    else
                    {
                        currCar.Color = tokens[2];
                    }
                }
                cars.Add(currCar);
            }
            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
