using System;
using System.Collections.Generic;
using System.Text;

public abstract class Harvester : MagicalCreature
{
    private const int maxEnergyRequirement = 20_000;

    private double oreOutput;
    private double energyRequirement;
    private string type;

    public string Type
    {
        get { return type; }
        protected set { type = value; }
    }


    protected Harvester(string id, double oreOutput, double energyRequirement) :base(id)
    {
       this.EnergyRequirement = energyRequirement;
       this.OreOutput = oreOutput;
    }

    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            if (value < 0 || value > maxEnergyRequirement)
            {
                throw new ArgumentException(Exceptions.maxEnergyRequirement);
            }
            energyRequirement = value;
        }
    }

    public double OreOutput
    {
        get { return oreOutput; }
        protected set
        {
            if (value < 0 )
            {
                throw new ArgumentException(Exceptions.minOreOutput);
            }
            oreOutput = value;
        }
    }

    public override string ToString()
    {
        return $"{this.Type} Harvester - {this.Id}" + Environment.NewLine
               + $"Ore Output: {this.OreOutput}" + Environment.NewLine
                 +$"Energy Requirement: {this.EnergyRequirement}";
    }
}