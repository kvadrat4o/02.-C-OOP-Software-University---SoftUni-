using System;
using System.Collections.Generic;
using System.Text;

public class EventLogger : Logger
{
    public override void Handle(LogType eventType, string message)
    {
        switch (eventType)
        {
            case LogType.TARGET:
                Console.WriteLine(eventType.ToString() + ": " + message);
                break;
            case LogType.ERROR:
                Console.WriteLine(eventType.ToString() + ": " + message);
                break;
            case LogType.EVENT:
                Console.WriteLine(eventType.ToString() + ": " + message);
                break;
        }
        this.PassToSuccessor(eventType, message);
    }
}
