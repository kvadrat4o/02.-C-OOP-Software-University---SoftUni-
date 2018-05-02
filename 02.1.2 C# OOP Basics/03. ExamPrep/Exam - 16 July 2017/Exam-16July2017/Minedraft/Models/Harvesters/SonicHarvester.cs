using System;
using System.Collections.Generic;
using System.Text;

public class SonicHarvester : Harvester
{
    private int sonicfactor;
    public int SonicFactor
    {
        get { return sonicfactor; }
        protected set
        {
            if (value < 1 || value > 10)
            {
                throw new ArgumentException("Harvester is not registered, because of it's SonicFactor");
            }
            sonicfactor = value;
        }
    }

    public SonicHarvester(string iD, double oreOutput, double energyRequirement, int sonicfactor) : base(iD, oreOutput, energyRequirement)
    {
        this.SonicFactor = sonicfactor;
        this.EnergyRequirement /= this.SonicFactor;
    }

    public override string ToString()
    {
        return "Sonic" + base.ToString();
    }
}
