using System;
using System.Collections.Generic;
using System.Text;

public class HammerHarvester : Harvester
{
    public HammerHarvester(string iD, double oreOutput, double energyRequirement) : base(iD, oreOutput, energyRequirement)
    {
        this.OreOutput *= 3;
        this.EnergyRequirement *= 2;
    }

    public override string ToString()
    {
        return "Hammer " + base.ToString();
    }
}