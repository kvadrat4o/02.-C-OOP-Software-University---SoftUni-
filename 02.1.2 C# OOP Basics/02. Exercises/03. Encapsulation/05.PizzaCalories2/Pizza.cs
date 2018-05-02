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
            if (value == String.Empty || value == "" || value == "  " || value == null || value == " " || value.Length > 15 || value.Length < 1)
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

    public Pizza(string name, List<Topping> toppings)
    {
        this.Name = name;
        this.Toppings = toppings;
    }

    public double CalculatePizzaCalories ()
    {
        double totalCalories = 0.00D;
        double doughCalories = this.Dough.CalculateDoughCalories();
        double toppingCalories = this.Toppings.Sum(b => b.CalculateToppingCalories());
        totalCalories = doughCalories + toppingCalories;
        return totalCalories;
    }

    public void AddTopping(Topping top)
    {
        this.Toppings.Add(top);

        if (this.Toppings.Count > 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
            //Environment.Exit(0);
        }
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.CalculatePizzaCalories():F2} Calories.";
    }
}
