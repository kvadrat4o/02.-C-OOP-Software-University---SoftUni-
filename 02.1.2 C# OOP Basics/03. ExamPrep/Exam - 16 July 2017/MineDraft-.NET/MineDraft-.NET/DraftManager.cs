using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class DraftManager
{
    private string mode;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private List<Harvester> harvesters;
    private List<Provider> providers;

    public DraftManager()
    {
        this.mode = "Full";
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
    }

    public string RegisterHarvester(List<string> arguments)
    {
        //RegisterHarvester {type} {id} {oreOutput} {energyRequirement}
        var sb = new StringBuilder();

        try
        {
            if (arguments[0] == "Sonic")
            {
                harvesters.Add(new SonicHarvester(arguments[1], double.Parse(arguments[2]), double.Parse(arguments[3]), int.Parse(arguments[4])));

                sb.AppendLine($"Successfully registered Sonic Harvester - {arguments[1]}");
            }
            else if (arguments[0] == "Hammer")
            {
                harvesters.Add(new HammerHarvester(arguments[1], double.Parse(arguments[2]), double.Parse(arguments[3])));
                sb.AppendLine($"Successfully registered Hammer Harvester - {arguments[1]}");
            }
        }
        catch (ArgumentException ae)
        {
            sb.AppendLine(ae.Message);
        }
        return sb.ToString().TrimEnd();
    }

    public string RegisterProvider(List<string> arguments)
    {
        //RegisterProvider {type} {id} {energyOutput}
        var sb = new StringBuilder();

        try
        {
            if (arguments[0] == "Pressure")
            {
                providers.Add(new PressureProvider(arguments[1], double.Parse(arguments[2])));
                sb.AppendLine($"Successfully registered Pressure Provider - {arguments[1]}");
            }
            else if (arguments[0] == "Solar")
            {
                providers.Add(new SolarProvider(arguments[1], double.Parse(arguments[2])));
                sb.AppendLine($"Successfully registered Solar Provider - {arguments[1]}");
            }
        }
        catch (ArgumentException ae)
        {
            sb.AppendLine(ae.Message);
        }
        return sb.ToString().TrimEnd();
    }

    public string Day()
    {
        var energyOutputForTheDay = providers.Sum(a => a.EnergyOutput);
        this.totalStoredEnergy += energyOutputForTheDay;

        double oreOutputForTheDay = 0.00;

        var energyRequired = harvesters.Sum(a => a.EnergyRequirement);

        if (this.mode == "Full" && this.totalStoredEnergy >= energyRequired)
        {
            oreOutputForTheDay = harvesters.Sum(a => a.OreOutput);
            this.totalMinedOre += oreOutputForTheDay;
            this.totalStoredEnergy -= energyRequired;
        }
        else if (this.mode == "Half" && this.totalStoredEnergy >= energyRequired * 0.6)
        {
            oreOutputForTheDay = harvesters.Sum(a => a.OreOutput) * 0.5;
            this.totalMinedOre += oreOutputForTheDay;
            this.totalStoredEnergy -= energyRequired * 0.6;
        }

        var sb = new StringBuilder();

        sb.AppendLine("A day has passed.")
            .AppendLine($"Energy Provided: {energyOutputForTheDay}")
            .AppendLine($"Plumbus Ore Mined: {oreOutputForTheDay}");

        return sb.ToString().TrimEnd();
    }

    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];
        return $"Successfully changed working mode to {this.mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        var sb = new StringBuilder();

        if (this.providers.Any(a => a.ID == arguments[0]))
        {
            var provider = providers.First(a => a.ID == arguments[0]);
            sb.AppendLine(provider.ToString());
        }
        else if (this.harvesters.Any(a => a.ID == arguments[0]))
        {
            var harvester = harvesters.First(a => a.ID == arguments[0]);
            sb.AppendLine(harvester.ToString());
        }
        else
        {
            return $"No element found with id - {arguments[0]}";
        }

        return sb.ToString().TrimEnd();

    }
    public string ShutDown()
    {
        var sb = new StringBuilder();

        sb.AppendLine("System Shutdown")
            .AppendLine($"Total Energy Stored: {this.totalStoredEnergy}")
            .AppendLine($"Total Mined Plumbus Ore: {this.totalMinedOre}");
        return sb.ToString().TrimEnd();
    }
}
