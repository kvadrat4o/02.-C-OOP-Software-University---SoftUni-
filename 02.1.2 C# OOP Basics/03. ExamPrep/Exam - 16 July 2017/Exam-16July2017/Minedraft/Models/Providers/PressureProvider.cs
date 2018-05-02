using System;
using System.Collections.Generic;
using System.Text;

public class PressureProvider : Provider
{
    public  PressureProvider(string iD, double energyOutput) : base(iD, energyOutput)
    {
        this.EnergyOutput += 0.50* this.EnergyOutput;
    }

    public override string ToString()
    {
        return "Pressure" + base.ToString();
    }
}
