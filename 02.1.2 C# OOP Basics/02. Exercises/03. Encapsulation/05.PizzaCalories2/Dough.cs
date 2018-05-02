using System;
using System.Collections.Generic;
using System.Text;

public class Dough
{
    private double weight;
    private FlourType flourType;
    private BakingTechnique bakingTech;

    public BakingTechnique BakingTech
    {
        get { return bakingTech; }
        set
        {
            if (value != BakingTechnique.Chewy && value != BakingTechnique.Crispy && value != BakingTechnique.Homemade)
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            bakingTech = value;
        }
    }

    public FlourType FlourType
    {
        get { return flourType; }
        set
        {
            if (value != FlourType.White && value != FlourType.Wholegrain)
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            flourType = value;
        }
    }

    public double Weight
    {
        get { return weight; }
        set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            weight = value;
        }
    }

    public Dough()
    {

    }

    public Dough(double weight, BakingTechnique ba, FlourType fl)
    {
        this.BakingTech = ba;
        this.Weight = weight;
        this.FlourType = fl;
    }

    public double CalculateDoughCalories()
    {
        double calories = 0.00D;
        double modifierD = 0.00D;
        double modifierT = 0.00D;
        switch (this.BakingTech)
        {
            case BakingTechnique.Crispy:
                modifierT = 0.9;
                if (this.FlourType == FlourType.White)
                {
                    modifierD = 1.5;
                }
                else if (this.FlourType == FlourType.Wholegrain)
                {
                    modifierD = 1.0;
                }
                calories = (2 * this.Weight) * modifierD * modifierT;
                break;
            case BakingTechnique.Chewy:
                modifierT = 1.1;
                if (this.FlourType == FlourType.White)
                {
                    modifierD = 1.5;
                }
                else if (this.FlourType == FlourType.Wholegrain)
                {
                    modifierD = 1.0;
                }
                calories = (2 * this.Weight) * modifierD * modifierT;
                break;
            case BakingTechnique.Homemade:
                modifierT = 1.0;
                if (this.FlourType == FlourType.White)
                {
                    modifierD = 1.5;
                }
                else if (this.FlourType == FlourType.Wholegrain)
                {
                    modifierD = 1.0;
                }
                calories = (2 * this.Weight) * modifierD * modifierT;
                break;
            default:
                break;
        }
        return calories;
    }
}
