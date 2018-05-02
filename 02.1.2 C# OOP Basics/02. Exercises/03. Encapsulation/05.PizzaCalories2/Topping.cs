using System;
using System.Collections.Generic;
using System.Text;

public class Topping
{
    private double weight;
    private Toppingtype toppingtype;

    public Toppingtype ToppingType
    {
        get { return toppingtype; }
        set
        {
            if (value != Toppingtype.Cheese || value != Toppingtype.Meat || value != Toppingtype.Sauce || value != Toppingtype.Veggies)
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            toppingtype = value;
        }
    }

    public double Weight
    {
        get { return weight; }
        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
            }
            weight = value;
        }
    }

    public Topping()
    {

    }

    public Topping(double weight, Toppingtype top)
    {
        this.Weight = weight;
        this.ToppingType = top;
    }

    public double CalculateToppingCalories()
    {
        double modifierT = 0.00D;
        double calories = 0.00D;
        switch (this.ToppingType)
        {
            case Toppingtype.Meat:
                modifierT = 1.2;
                calories = this.Weight * 2 * modifierT;
                break;
            case Toppingtype.Veggies:
                modifierT = 0.8;
                calories = this.Weight * 2 * modifierT;
                break;
            case Toppingtype.Cheese:
                modifierT = 1.1;
                calories = this.Weight * 2 * modifierT;
                break;
            case Toppingtype.Sauce:
                modifierT = 0.9;
                calories = this.Weight * 2 * modifierT;
                break;
            default:
                break;
        }
        return calories;
    }
}
