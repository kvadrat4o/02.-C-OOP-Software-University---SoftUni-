using System;

public abstract class Provider : IProvider, IEntity
{
    public int ID { get; protected set; }

    public double Durability { get; protected set; }

    public double EnergyOutput { get; protected set; }

    protected Provider(int iD, double durability, double energy)
    {
        this.ID = iD;
        this.Durability = durability;
        this.EnergyOutput = energy;
    }

    public void Broke()
    {
        this.Durability -= 100;
        if (this.Durability < 0)
        {
            throw new Exception("Provider broken!");
        }
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }

    public override string ToString()
    {
        return $"{this.GetType().FullName}" + Environment.NewLine + $"Durability: { this.Durability}";
    }
}