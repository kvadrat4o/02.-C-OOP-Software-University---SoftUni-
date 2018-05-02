using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Harvester
{
    private string id;
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyReq)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyReq;
    }

    public string Id
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

    public double OreOutput
    {
        get { return oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Harvester is not registered, because of it's OreOutput");
            }
            oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException("Harvester is not registered, because of it's EnergyRequirement");
            }
            energyRequirement = value;
        }
    }

    public double Mine()
    {
        return this.OreOutput;
    }

    public override string ToString()
    {
        return $"Harvester - {this.Id}\nOre Output: {this.OreOutput}\nEnergy Requirement: {this.EnergyRequirement}";
    }
}

