using System;

namespace _01.Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            var carArgs = Console.ReadLine().Split();
            var truckArgs = Console.ReadLine().Split();
            var busArgs = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            Vehicle car = new Car(double.Parse(carArgs[1]), double.Parse(carArgs[2]), double.Parse(carArgs[3]));
            Vehicle truck = new Truck(double.Parse(truckArgs[1]), double.Parse(truckArgs[2]), double.Parse(truckArgs[3]));
            Bus bus = new Bus(double.Parse(busArgs[1]), double.Parse(busArgs[2]), double.Parse(busArgs[3]));
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                switch (input[0])
                {
                    case "Drive":
                        if (input[1] == "Car")
                        {
                            car.Drive(double.Parse(input[2]));
                        }
                        else if (input[1] == "Truck")
                        {
                            truck.Drive(double.Parse(input[2]));
                        }
                        else if (input[1] == "Bus")
                        {
                            bus.Drive(double.Parse(input[2]));
                        }
                        break;
                    case "Refuel":
                        if (input[1] == "Car")
                        {
                            car.Refuel(double.Parse(input[2]));
                        }
                        else if (input[1] == "Truck")
                        {
                            truck.Refuel(double.Parse(input[2]));
                        }
                        else if (input[1] == "Bus")
                        {
                            bus.Refuel(double.Parse(input[2]));
                        }
                        break;
                    case "DriveEmpty":
                        bus.DriveEmpty(double.Parse(input[2]));
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
