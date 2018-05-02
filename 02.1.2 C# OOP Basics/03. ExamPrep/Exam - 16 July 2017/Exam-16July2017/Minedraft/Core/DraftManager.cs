using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private List<Harvester> harvesters = new List<Harvester>();
    private List<Provider> providers = new List<Provider>();
    private double TotalEnergyStored;
    private double TotalMinedOre;
    private string Modeparam;

    public DraftManager()
    {
        this.Modeparam = "Full";
    }

    public string RegisterHarvester(List<string> arguments)
    {
        //RegisterHarvester {type} {id} {oreOutput} {energyRequirement}
        //RegisterHarvester Sonic {id} {oreOutput} {energyRequirement} {sonicFactor}
        try
        {
            string id = arguments[1];
            double ore = double.Parse(arguments[2]);
            double energy = double.Parse(arguments[3]);
            if (arguments[0] == "Sonic")
            {
                int sonic = int.Parse(arguments[4]);
                SonicHarvester sonicH = new SonicHarvester(id, ore, energy,sonic);
                harvesters.Add(sonicH);
                return $"Successfully registered Sonic Harvester – {sonicH.ID}";
            }
            else
            {
                HammerHarvester hammer = new HammerHarvester(id, ore, energy);
                harvesters.Add(hammer);
                return $"Successfully registered Hammer Harvester – {hammer.ID}";
            }
        }
        catch (ArgumentException ar)
        {
            return ar.Message;
        }
        
    }
    public string RegisterProvider(List<string> arguments)
    {
        //RegisterProvider {type} {id} {energyOutput}
        try
        {
            string id = arguments[1];
            double energy = double.Parse(arguments[2]);
            if (arguments[0] == "Solar")
            {
                Provider solar = new SolarProvider(id, energy);
                providers.Add(solar);
                return $"Successfully registered Solar Provider – {solar.ID}";
            }
            else
            {
                Provider pressure = new PressureProvider(id, energy);
                providers.Add(pressure);
                return $"Successfully registered Pressure Provider – {pressure.ID}";

            }
        }
        catch (ArgumentException ar)
        {
            return ar.Message;
        }
    }
    public string Day()
    {
        //Day
        StringBuilder sb = new StringBuilder();
        double EnergyProduced = providers.Sum(y => y.EnergyOutput);
        this.TotalEnergyStored += EnergyProduced;
        double MinedOre = 0;  
        double RequiredEnergy = harvesters.Sum(x => x.EnergyRequirement);
        if (this.Modeparam == "Full" && this.TotalEnergyStored >= RequiredEnergy)
        {
            MinedOre = harvesters.Sum(x => x.OreOutput);
            this.TotalMinedOre += MinedOre;
            this.TotalEnergyStored -= RequiredEnergy;
            //sb.AppendLine($"A day has passed.\nEnergy Provided: {EnergyProduced}.\nPlumbus Ore Mined: {MinedOre}.");

        }
        else if (this.Modeparam == "Half" && this.TotalEnergyStored >= RequiredEnergy * 0.60)
        {
            MinedOre = harvesters.Sum(x => x.OreOutput) * 0.50;
            this.TotalMinedOre += MinedOre * 0.50;
            this.TotalEnergyStored -= RequiredEnergy * 0.60;
            //sb.AppendLine($"A day has passed.\nEnergy Provided: {EnergyProduced}.\nPlumbus Ore Mined: {MinedOre}.");

        }
        sb.AppendLine($"A day has passed.\nEnergy Provided: {EnergyProduced}.\nPlumbus Ore Mined: {MinedOre}.");
        return sb.ToString().TrimEnd();
        //return $"A day has passed.\nEnergy Provided: {EnergyProduced}.\nPlumbus Ore Mined: {MinedOre}.";
    }
    public string Mode(List<string> arguments)
    {
        //Mode {mode}
        this.Modeparam = arguments[0];
        return $"Successfully changed working mode to {arguments[0]} Mode";
    }
    public string Check(List<string> arguments)
    {
        //Check {id}
        string id = arguments[0];
        if (providers.Any(a => a.ID == id))
        {
            Provider provider = providers.FirstOrDefault(a => a.ID == id);
            return provider.ToString();
        }
        else if (harvesters.Any(h => h.ID == id))
        {
            Harvester harvester = harvesters.FirstOrDefault(a => a.ID == id);
            return harvester.ToString();
        }
        else
        {
            return $"No element found with id – {id}.";
        }
    }
    public string ShutDown()
    {
        //Shutdown

        return $"System Shutdown\nTotal Energy Stored: {this.TotalEnergyStored}\nTotal Mined Plumbus Ore: {this.TotalMinedOre}";

    }
}