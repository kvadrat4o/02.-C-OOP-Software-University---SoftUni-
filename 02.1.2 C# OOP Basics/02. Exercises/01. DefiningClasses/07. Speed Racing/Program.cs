using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Speed_Racing
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<String, Car> cars = new Dictionary<string, Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var model = input[0];
                var amount = double.Parse(input[1]);
                var consumption = double.Parse(input[2]);
                Car car = new Car();
                car.Model = model;
                car.FuelAmount = amount;
                car.DistanceTravelled = 0;
                car.Consumption = consumption;
                if (!cars.ContainsKey(model))
                {
                    cars[model] = new Car();
                }
                cars[model] = car;
            }
            var secondImput = Console.ReadLine();
            while (secondImput != "End")
            {
                var tokens = secondImput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var model = tokens[1];
                var distance = int.Parse(tokens[2]);
                if (cars.ContainsKey(model))
                {
                    cars[model].Drive(model, distance);
                }
                secondImput = Console.ReadLine();
            }
            foreach (var car in cars.Values)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
