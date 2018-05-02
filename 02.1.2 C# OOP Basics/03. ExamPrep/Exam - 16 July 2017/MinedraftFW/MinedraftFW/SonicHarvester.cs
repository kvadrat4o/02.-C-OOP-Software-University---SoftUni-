using System;
using System.Collections.Generic;
using System.Text;

public class SonicHarvester : Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyReq, int sonicFactor) : base(id, oreOutput, energyReq)
    {
        this.SonicFactor = sonicFactor;
        this.EnergyRequirement /= this.SonicFactor;
    }

    private int SonicFactor
    {
        get { return sonicFactor; }
        set
        {
            if (value < 1 || value > 10)
            {
                throw new ArgumentException("Harvester is not registered, because of it's SonicFactor");
            }
            sonicFactor = value;
        }
    }

    public override string ToString()
    {
        return "Sonic " + base.ToString();
    }
}

