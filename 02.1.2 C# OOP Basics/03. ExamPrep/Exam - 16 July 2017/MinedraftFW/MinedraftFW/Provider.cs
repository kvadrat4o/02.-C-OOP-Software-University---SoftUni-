using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Provider
{
    private string id;
    private double energyOutput;

    protected Provider(string id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
    }

    public string Id
    {
        get { return id; }
        protected set
        {
            if (value.Contains(' '))
            {
                throw new ArgumentException("Provider is not registered, because of it's Id");
            }
            id = value;
        }
    }

    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            if (value < 0 || value >= 10000)
            {
                throw new ArgumentException("Provider is not registered, because of it's EnergyOutput");
            }
            energyOutput = value;
        }
    }

    public override string ToString()
    {
        return $" Provider - {this.Id}\nEnergy Output: {this.EnergyOutput}";
    }
}

