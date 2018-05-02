using System;
using System.Collections.Generic;
using System.Text;

public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOuput, double energyReq) : base(id, oreOuput, energyReq)
    {
        this.OreOutput *= 3;
        this.EnergyRequirement *= 2;
    }

    public override string ToString()
    {
        return "Hammer " + base.ToString();
    }
}

