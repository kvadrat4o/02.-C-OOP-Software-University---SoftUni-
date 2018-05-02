using System.Collections.Generic;

public class QuitCommand : AbstractCommand
{
    public QuitCommand(List<string> arguments, IManager heroManager) : base(arguments, heroManager)
    {
    }

    public override string Execute()
    {
        return base.heroManager.Quit(this.arguments);
    }
}