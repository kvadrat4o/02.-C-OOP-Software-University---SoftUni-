using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;

    public List<Topping> Toppings
    {
        get { return toppings; }
        set { toppings = value; }
    }

    public Dough Dough
    {
        get { return dough; }
        set { dough = value; }
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (value == String.Empty || value == "" || value == "  " || value == null || value == " " || value.Length < 1 || value.Length > 15)
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
        :this()
    {
        this.Name = name;
    }

    public Pizza(string name, Dough dough, List<Topping> toppings)
    {
        this.Dough = dough;
        this.Toppings = toppings;
        this.Name = name;
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.GetTotalCalories:F2} Calories.";
    }

    public double GetTotalCalories => this.Dough.CalculateDoughCalories + this.Toppings.Sum(a => a.CalculateToppingCalories);

    public void AddTopping (Topping top)
    {
        this.Toppings.Add(top);

        if (this.Toppings.Count > 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
    }
}
