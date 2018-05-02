using System;
using System.Collections.Generic;
using System.Text;

public class SonicHarvester : Harvester
{
    private int sonicFactor { get; set; }

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) :base(id,oreOutput,energyRequirement)
    {
        this.sonicFactor = sonicFactor;
        this.EnergyRequirement /= sonicFactor;
        this.Type = "Sonic";
    }
}