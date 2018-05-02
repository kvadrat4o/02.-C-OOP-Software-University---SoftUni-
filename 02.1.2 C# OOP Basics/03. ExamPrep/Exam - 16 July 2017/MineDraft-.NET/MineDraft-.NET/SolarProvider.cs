using System;
using System.Collections.Generic;
using System.Text;

public class SolarProvider : Provider
{
    public SolarProvider(string iD, double energyOutput) : base(iD, energyOutput)
    {
    }

    public override string ToString()
    {
        return "Solar" + base.ToString();
    }
}
