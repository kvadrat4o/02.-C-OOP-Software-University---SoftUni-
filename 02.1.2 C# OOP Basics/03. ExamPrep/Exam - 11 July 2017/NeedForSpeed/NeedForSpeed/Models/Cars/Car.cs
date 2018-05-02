using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Car
{
    private string brand;
    private string model;
    private int yearOfProduction;
    private int horsepower;
    private int acceleration;
    private int suspension;
    private int durability;

    public Car(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.HorsePower = horsePower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
    }

    public double power { get; set; }

    public int Durability
    {
        get { return durability; }
        set { durability = value; }
    }

    public int Suspension
    {
        get { return suspension; }
        set { suspension = value; }
    }

    public int Acceleration
    {
        get { return acceleration; }
        set { acceleration = value; }
    }

    public int HorsePower
    {
        get { return horsepower; }
        set { horsepower = value; }
    }

    public int YearOfProduction
    {
        get { return yearOfProduction; }
        protected set { yearOfProduction = value; }
    }

    public string Model
    {
        get { return model; }
        protected set { model = value; }
    }

    public string Brand
    {
        get { return brand; }
        protected set { brand = value; }
    }

    public override string ToString()
    {
        return $"{this.Brand} {this.Model} {this.YearOfProduction}\n{ this.HorsePower} HP, 100 m / h in { this.Acceleration} s\n{ this.Suspension} Suspension force, { this.Durability} Durability";
    }
}