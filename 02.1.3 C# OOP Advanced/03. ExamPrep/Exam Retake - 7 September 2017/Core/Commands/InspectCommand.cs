using System;
using System.Collections.Generic;

public class InspectCommand : Command
{
    private IHarvesterController harvesterController;

    private IProviderController providerController;

    public InspectCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        int id = int.Parse(this.Arguments[1]);
        if (this.harvesterController.IdExists(id))
        {
            return this.harvesterController.CheckForHarvester(id);
        }
        else
        {
            return this.providerController.CheckForProvider(id);
        }
    }
}
