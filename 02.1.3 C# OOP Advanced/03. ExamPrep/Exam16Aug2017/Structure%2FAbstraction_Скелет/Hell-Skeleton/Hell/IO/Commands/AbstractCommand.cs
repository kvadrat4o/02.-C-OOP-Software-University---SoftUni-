using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class AbstractCommand : ICommand
{
    protected IManager heroManager;

    protected List<string> arguments;

    protected AbstractCommand(List<string> arguments,IManager heroManager)
    {
        this.heroManager = heroManager;
        this.arguments = arguments;
    }

    public abstract string Execute();
}
