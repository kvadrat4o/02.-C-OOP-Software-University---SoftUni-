using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Raw_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                var cargoType = input[4];
                double tier1Pressure = double.Parse(input[5]);
                int tier1Age = int.Parse(input[6]);
                double tier2Pressure = double.Parse(input[5]);
                int tier2Age = int.Parse(input[6]);
                double tier3Pressure = double.Parse(input[5]);
                int tier3Age = int.Parse(input[6]);
                double tier4Pressure = double.Parse(input[5]);
                int tier4Age = int.Parse(input[6]);
                Engine currEngine = new Engine() { Speed = engineSpeed, Power = enginePower };
                Cargo currCargo = new Cargo() { Weight = cargoWeight, CargoType = cargoType };
                Tire one = new Tire() { Age = tier1Age, Pressure = tier1Pressure };
                Tire two = new Tire() { Age = tier2Age, Pressure = tier2Pressure };
                Tire three = new Tire() { Age = tier3Age, Pressure = tier3Pressure };
                Tire four = new Tire() { Age = tier4Age, Pressure = tier4Pressure };
                Car currcar = new Car() { Model = model, Cargo = currCargo, Engine = currEngine, Tires = new List<Tire>() { one, two, three, four } };
                cars.Add(currcar);
            }
            var instruction = Console.ReadLine();
            if (instruction == "fragile")
            {
                foreach (var car in cars.Where(a => a.Cargo.CargoType == "fragile" && a.Tires.All(b => b.Pressure < 1)))
                {
                    Console.WriteLine(car.ToString());
                }
            }
            else
            {
                foreach (var car in cars.Where(a => a.Cargo.CargoType == "flamable" && a.Engine.Power > 250))
                {
                    Console.WriteLine(car.ToString());
                }
            }
        }
    }
}
