using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    public DraftManager()
    {
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.hf = new HarvesterFactory();
        this.pf = new ProviderFactory();
        this.mode = "Full";
    }

    private string mode;

    public HarvesterFactory hf { get; set; }

    public ProviderFactory pf { get; set; }

    private List<Provider> providers { get; set; }

    private List<Harvester> harvesters { get; set; }

    private double totalEnergyStored { get; set; }

    private double totalMinedOre { get; set; }

    public string RegisterHarvester(List<string> arguments)
    {
        //Sonic {id} {oreOutput} {energyRequirement} {sonicFactor} || {type} {id} {oreOutput} {energyRequirement}
        try
        {
            this.harvesters.Add(this.hf.GetHarvester(arguments));
            return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }
    public string RegisterProvider(List<string> arguments)
    {
        //{type} {id} {energyOutput}
        try
        {
            this.providers.Add(this.pf.GetProvider(arguments));
            return $"Successfully registered {arguments[0]} Provider - {arguments[1]}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }
    public string Day()
    {
        //
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("A day has passed.");
        double energyRequired = 0.00;
        double summedOreOutput = 0.00;
        double energyProvided = this.providers.Sum(p => p.EnergyOutput);
        this.totalEnergyStored += energyProvided;
        energyRequired = this.harvesters.Sum(h => h.EnergyRequirement);
        if (this.totalEnergyStored >= energyRequired)
        {
            if (this.mode == "Half")
            {
                summedOreOutput = this.harvesters.Sum(h => h.OreOutput) * 0.50;
                this.totalEnergyStored -= energyRequired * 0.60;
                this.totalMinedOre += summedOreOutput;
            }
            else if (this.mode == "Full")
            {
                summedOreOutput = this.harvesters.Sum(h => h.OreOutput);
                this.totalEnergyStored -= energyRequired;
                this.totalMinedOre += summedOreOutput;
            }
            else if (this.mode == "Energy")
            {

            }
        }
        sb.AppendLine($"Energy Provided: {energyProvided}" + Environment.NewLine
                       + $"Plumbus Ore Mined: {summedOreOutput}");
        return sb.ToString().TrimEnd();
    }
    public string Mode(List<string> arguments)
    {
        //{mode}

        this.mode = arguments[0];
        return $"Successfully changed working mode to {arguments[0]} Mode";
    }
    public string Check(List<string> arguments)
    {
        //{id}
        var id = arguments[0];
        return this.harvesters.FirstOrDefault(h => h.Id == id)?.ToString() ?? this.providers.FirstOrDefault(h => h.Id == id)?.ToString() ?? $"No element found with id - {id}";
    }
    public string ShutDown()
    {
        //

        return $"System Shutdown" + Environment.NewLine
                + $"Total Energy Stored: {this.totalEnergyStored}" + Environment.NewLine
                + $"Total Mined Plumbus Ore: {this.totalMinedOre}";
    }

}