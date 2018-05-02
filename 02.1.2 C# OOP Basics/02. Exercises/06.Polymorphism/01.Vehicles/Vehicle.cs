using System;
using System.Collections.Generic;
using System.Text;

public abstract class Vehicle
{
    public double fuelQuantity { get; protected set; }

    public double fuelConsumption { get; protected set; }

    public double distance { get; protected set; }

    public double refuledFuel { get; protected set; }

    private double tankCapacity;

    public double TankCapacity
    {
        get { return tankCapacity; }
        protected set
        {
            if (value < this.fuelQuantity)
            {
                //Console.WriteLine($"Cannot fit {value} fuel in the tank");
                this.fuelQuantity = 0;
            }
            tankCapacity = value;
        }
    }



    protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        this.fuelQuantity = fuelQuantity;
        this.fuelConsumption = fuelConsumption;
        this.TankCapacity = tankCapacity;
    }

    public virtual void Drive(double distance)
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

    public virtual void Refuel(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
        }
    }

    public override string ToString()
    {
        return $"{this.GetType()}: {this.fuelQuantity :F2}";
    }
}