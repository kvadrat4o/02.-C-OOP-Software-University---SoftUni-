using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Dough
{
    private double weigth;
    private string flour;
    private string technique;
    private Dictionary<string,double> techniqueDict = new Dictionary<string, double>() { { "chewy", 1.1 }, { "crispy", 0.9 }, { "homemade", 1.0 } };
    private Dictionary<string,double> flourDict = new Dictionary<string, double>() { { "white", 1.5 }, { "wholegrain", 1.0 } };

    public Dough()
    {

    }

    public Dough(double weight, string flour, string technique)
    {
        this.Weight = weight;
        this.Flour = flour;
        this.Technique = technique;
    }



    public string Technique 
    {
        get { return technique; }
        set
        {
            if (!techniqueDict.Any(a => a.Key == value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            technique = value;
        }
    }

    public string Flour
    {
        get { return flour; }
        set
        {
            if (!flourDict.Any(a => a.Key == value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            flour = value;
        }
    }

    public double Weight
    {
        get { return weigth; }
        set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            weigth = value;
        }
    }

    
    public double CalculateDoughCalories => (2 * this.Weight) * flourDict[this.Flour.ToLower()] * techniqueDict[this.Technique.ToLower()];

    public override string ToString()
    {
        return $"{this.CalculateDoughCalories:F2}";
    }
}
