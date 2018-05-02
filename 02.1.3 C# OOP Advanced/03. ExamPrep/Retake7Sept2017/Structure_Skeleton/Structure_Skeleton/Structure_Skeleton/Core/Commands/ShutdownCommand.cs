using System;
using System.Collections.Generic;

public class ShutdownCommand : Command
{

    private IProviderController providerController;

    private IHarvesterController harvesterController;

    public ShutdownCommand(IList<string> arguments,IProviderController providerController, IHarvesterController harvesterController) : base(arguments)
    {
        this.providerController = providerController;
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        //Environment.Exit(0);
        return $"System Shutdown" + Environment.NewLine + $"Total Energy Produced: {this.providerController.TotalEnergyProduced}" + Environment.NewLine +
        $"Total Mined Plumbus Ore: {this.harvesterController.OreProduced}";
    }
}