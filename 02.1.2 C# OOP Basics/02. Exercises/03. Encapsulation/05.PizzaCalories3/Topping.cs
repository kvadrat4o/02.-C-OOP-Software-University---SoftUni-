using System;
using System.Collections.Generic;
using System.Text;

public class Topping
{
    private double weight;
    private string type;
    private Dictionary<string, double> toppingTypes = new Dictionary<string, double>() { { "meat", 1.2 }, { "veggies", 0.8 }, { "cheese", 1.1 }, { "sauce", 0.9 } };

    public string Type
    {
        get { return type; }
        set
        {
            if (!toppingTypes.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            type = value;
        }
    }

    public double Weight
    {
        get { return weight; }
        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
            }
            weight = value;
        }
    }

    public Topping()
    {

    }

    public Topping(string type, double weight)
    {
        this.Type = type;
        this.Weight = weight;
    }

    public override string ToString()
    {
        return $"{this.CalculateToppingCalories:F2}";
    }

    public double CalculateToppingCalories => 2 * this.Weight * toppingTypes[this.Type.ToLower()];
}
