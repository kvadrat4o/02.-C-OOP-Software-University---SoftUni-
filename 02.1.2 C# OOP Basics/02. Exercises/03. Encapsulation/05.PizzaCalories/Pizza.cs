using System;
using System.Collections.Generic;
using System.Text;

public class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;
    private int numToppings;

    public int NumToppings
    {
        get { return numToppings; }
        private set
        {
            if (value < 0 || value > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            numToppings = value;
        }
    }


    public List<Topping> Toppings
    {
        get { return toppings; }
        private set
        {
            if (toppings.Count > 10 && toppings.Count < 0)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings = value;
        }
    }

    public Dough Dough
    {
        get { return dough; }
        set
        {
            dough = value;
        }
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (value == String.Empty || value == "" || value == "  " || value == null || value == " " || value.Length < 1 && value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            name = value;
        }
    }

    public Pizza()
    {
        this.Toppings = new List<Topping>();
    }

    public Pizza(string name)
    {
        this.Name = name;
    }

    public Pizza(string name, Dough dough)
        :this()
    {
        this.Dough = dough;
        this.Name = name;
    }

    public Pizza(string name, Dough dough, List<Topping> toppings)
    {
        this.Dough = dough;
        this.Name = name;
        this.Toppings = toppings;
    }

    public double CalculateCalories()
    {

        double calories = this.Dough.CalculateDoughCalories();
        foreach (var top in this.Toppings)
        {
            calories += top.CalculateToppingcalories();
        }
        return calories;
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.CalculateCalories():F2} Calories.";
    }
}
