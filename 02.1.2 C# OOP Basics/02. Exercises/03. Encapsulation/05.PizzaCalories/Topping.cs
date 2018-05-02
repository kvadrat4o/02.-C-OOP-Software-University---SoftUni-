using System;
using System.Collections.Generic;
using System.Text;

public class Topping
{
    private string type;
    private double weight;

    public double Weight
    {
        get { return weight; }
        private set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
            }
            weight = value;
        }
    }

    public string Type
    {
        get { return type; }
        private set
        {
            if (value != "Cheese" && value != "Meat" && value != "Sauce" && value != "Veggies")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            type = value;
        }
    }

    public Topping()
    {

    }

    public Topping(string name, double weight)
    {
        this.Type = name;
        this.Weight = weight;
    }

    public double CalculateToppingcalories()
    {
        double modifierT = 0.00D;
        double calories = 0.00D;
        switch (this.Type)
        {
            case "Meat":
                modifierT = 1.2;
                calories = modifierT * this.Weight;
                break;
            case "Veggies":
                modifierT = 0.8;
                calories = modifierT * this.Weight;
                break;
            case "Cheese":
                modifierT = 1.1;
                calories = modifierT * this.Weight;
                break;
            case "Sauce":
                modifierT = 0.9;
                calories = modifierT * this.Weight;
                break;
            default:
                break;
        }
        return calories * 2;
    }
}
