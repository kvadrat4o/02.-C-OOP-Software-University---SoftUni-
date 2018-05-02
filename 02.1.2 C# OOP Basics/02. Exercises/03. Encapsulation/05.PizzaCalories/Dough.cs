using System;
using System.Collections.Generic;
using System.Text;

public class Dough
{
    private double weight;
    private DoughType type;
    private BakingTechnique technique;

    public BakingTechnique Technique
    {
        get { return technique; }
        private set
        {
            if (value != BakingTechnique.Chewy && value != BakingTechnique.Crispy && value != BakingTechnique.Homemade)
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            technique = value;
        }
    }

    public DoughType Type
    {
        get { return type; }
        private set
        {
            if (value != DoughType.White && value != DoughType.Wholegrain)
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            type = value;
        }
    }

    public double Weight
    {
        get { return weight; }
        private set
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

    public Dough(double weight, BakingTechnique ba, DoughType ty)
    {
        this.Weight = weight;
        this.Technique = ba;
        this.Type = ty;
    }

    public double CalculateDoughCalories()
    {
        double modifierB = 0.00D;
        double modifierD = 0.00D;

        double calories = 0.00D;
        switch (this.Technique)
        {
            case BakingTechnique.Crispy:
                modifierB = 0.9;
                if (type == DoughType.White)
                {
                    modifierD = 1.5;
                }
                else
                {
                    modifierD = 1.0;
                }
                calories = (2 * this.weight) *modifierD * modifierB;
                break;
            case BakingTechnique.Chewy:
                modifierB = 1.1;
                if (type == DoughType.White)
                {
                    modifierD = 1.5;
                }
                else
                {
                    modifierD = 1.0;
                }
                calories = (2 * this.weight) * modifierD * modifierB;
                break;
            case BakingTechnique.Homemade:
                modifierB = 1.0;
                if (type == DoughType.White)
                {
                    modifierD = 1.5;
                }
                else
                {
                    modifierD = 1.0;
                }
                calories = (2 * this.weight) * modifierD * modifierB;
                break;
            default:
                break;
        }
        return calories;
    }
}
