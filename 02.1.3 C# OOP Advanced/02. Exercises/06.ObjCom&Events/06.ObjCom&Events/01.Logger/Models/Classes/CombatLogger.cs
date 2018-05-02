using System;
using System.Collections.Generic;
using System.Text;

public class CombatLogger : Logger
{
    public override void Handle(LogType eventType, string message)
    {
        switch (eventType)
        {
            case LogType.ATTACK:
                Console.WriteLine(eventType.ToString() + ": " + message);
                break;
            case LogType.MAGIC:
                Console.WriteLine(eventType.ToString() + ": " + message);
                break;
        }
        this.PassToSuccessor(eventType, message);
    }
}