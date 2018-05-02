using System;
using System.Collections.Generic;
using System.Text;

public abstract class Logger : IHandler
{
    private IHandler successor;

    public abstract void Handle(LogType eventType, string message);

    public void SetSuccessor(IHandler handler)
    {
        this.successor = handler;
    }

    public void PassToSuccessor(LogType eventType, string message)
    {
        if (this.successor != null)
        {
            this.successor.Handle(eventType, message);
        }
    }
}
