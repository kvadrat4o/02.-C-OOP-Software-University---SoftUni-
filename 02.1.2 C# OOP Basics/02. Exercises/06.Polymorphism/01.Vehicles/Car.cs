using System;
using System.Collections.Generic;
using System.Text;

public class Car : Vehicle
{
    public Car(double fuelQuantity, double fuelConsumption, double tank):base(fuelQuantity,fuelConsumption, tank)
    {
        this.fuelConsumption += 0.9;
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
}