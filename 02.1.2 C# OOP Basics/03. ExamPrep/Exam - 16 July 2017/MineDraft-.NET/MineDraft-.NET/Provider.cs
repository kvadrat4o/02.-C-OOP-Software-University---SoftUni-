using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Provider
{
    private string id;
    private double energyOutput;

    protected Provider(string iD, double energyOutput)
    {
        ID = iD;
        EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            if (value <= 0 || value > 10000)
            {
                throw new ArgumentException("Provider is not registered, because of it's EnergyOutput");
            }
            energyOutput = value;
        }
    }

    public string ID
    {
        get { return id; }
        protected set
        {
            if (value.Contains(' '))
            {
                throw new ArgumentException("Harvester is not registered, because of it's Id");
            }
            id = value;
        }
    }

    public override string ToString()
    {
        return $" Provider - {this.ID}\nEnergy Output: {this.EnergyOutput}";
        // return $"{this.GetType()} Provider - {this.ID}\nEnergy Output: {this.EnergyOutput}";
    }
}
