using System.Collections.Generic;

public abstract class Command : ICommand
{
    protected Command(IList<string> Arguments)
    {
        this.Arguments = Arguments;
    }


    public IList<string> Arguments { get; protected set; }

    public abstract string Execute();
}
