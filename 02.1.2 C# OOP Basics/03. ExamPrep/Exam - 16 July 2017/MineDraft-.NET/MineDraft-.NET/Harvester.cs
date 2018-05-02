using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Harvester
{
    private string id;
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string iD, double oreOutput, double energyRequirement)
    {
        ID = iD;
        OreOutput = oreOutput;
        EnergyRequirement = energyRequirement;
    }

    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            if (value < 0 || value > 20_000)
            {
                throw new ArgumentException("Harvester is not registered, because of it's EnergyRequirement");
            }
            energyRequirement = value;
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
        return $"Harvester - {this.ID}\nOre Output: {this.OreOutput}\nEnergy Requirement: {this.EnergyRequirement}";

        //return $"{this.GetType()} Harvester - {this.ID}\nOre Output: {this.OreOutput}\nEnergy Requirement: {this.EnergyRequirement}";
    }

    public void CheckMode(string mode)
    {
        if (mode == "Full")
        {
            this.EnergyRequirement = EnergyRequirement;
        }
        else if (mode == "Half")
        {
            this.EnergyRequirement *= 0.60;
            this.OreOutput *= 0.50;
        }
    }
}
