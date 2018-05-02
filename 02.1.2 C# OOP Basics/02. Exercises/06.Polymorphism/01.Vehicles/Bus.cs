using System;
using System.Collections.Generic;
using System.Text;

public class Bus : Vehicle
{
    public Bus(double fuelQuantity, double fuelConsumption, double tank) : base(fuelQuantity, fuelConsumption, tank)
    {
        
    }

    public override void Drive(double distance)
    {
        this.fuelConsumption += 1.4;
        if (this.fuelQuantity < this.fuelConsumption * distance)
        {
            Console.WriteLine($"{this.GetType()} needs refueling");
        }
        else
        {
            this.fuelQuantity -= this.fuelConsumption * distance;
            Console.WriteLine($"{this.GetType()} travelled {distance} km");
        }
    }

    public override void Refuel(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
        }
        else if (this.TankCapacity < amount + this.fuelQuantity)
        {
            Console.WriteLine($"Cannot fit {amount} fuel in the tank");
        }
        else
        {
            this.fuelQuantity += amount;
        }
        
    }

    public void DriveEmpty(double distance)
    {
        if (this.fuelQuantity < this.fuelConsumption * distance)
        {
            Console.WriteLine($"{this.GetType()} needs refueling");
        }
        else
        {
            this.fuelQuantity -= this.fuelConsumption * distance;
            Console.WriteLine($"{this.GetType()} travelled {distance} km");
        }
    }
}