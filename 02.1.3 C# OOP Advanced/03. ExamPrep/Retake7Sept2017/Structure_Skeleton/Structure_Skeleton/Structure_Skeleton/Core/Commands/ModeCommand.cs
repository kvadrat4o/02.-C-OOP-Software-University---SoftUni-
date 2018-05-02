using System.Collections.Generic;

public class ModeCommand : Command
{
    private IHarvesterController HarvesterController;

    public ModeCommand(IList<string> arguments, IHarvesterController harvesterController) : base(arguments)
    {
        this.HarvesterController = harvesterController;
    }

    public override string Execute()
    {
        string mode = this.Arguments[1];
        return this.HarvesterController.ChangeMode(mode);
    }
}
