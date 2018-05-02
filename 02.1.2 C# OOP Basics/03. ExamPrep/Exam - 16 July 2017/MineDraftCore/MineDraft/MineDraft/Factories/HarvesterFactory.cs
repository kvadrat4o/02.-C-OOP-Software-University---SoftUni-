using System;
using System.Collections.Generic;
using System.Text;

public class HarvesterFactory
{
    public HarvesterFactory()
    {

    }

    public Harvester GetHarvester(List<string> args)
    {
        var id = args[1];
        var ore = double.Parse(args[2]);
        var energy = double.Parse(args[3]);
        Harvester sc;
        if (args[0] == "Sonic")
        {
            sc = new SonicHarvester(id,ore,energy,int.Parse(args[4]));
        }
        else
        {
            sc = new HammerHarvester(id, ore, energy);
        }

        return sc;
    }
}