using System;
using System.Collections.Generic;

public class RegisterCommand : Command
{

    private IHarvesterController HarvesterController;

    private IProviderController ProviderController;

    public RegisterCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) : base(arguments)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public override string Execute()
    {
        //•	Register Harvester Sonic {id} {oreOutput} {energyRequirement}
        //•	Register Provider Hammer {id} {energyOutput}

        string entityType = this.Arguments[1];
        try
        {
            if (entityType == "Harvester")
            {
                return this.HarvesterController.Register(this.Arguments);
            }
            else
            {
                return this.ProviderController.Register(this.Arguments);
            }
            
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}