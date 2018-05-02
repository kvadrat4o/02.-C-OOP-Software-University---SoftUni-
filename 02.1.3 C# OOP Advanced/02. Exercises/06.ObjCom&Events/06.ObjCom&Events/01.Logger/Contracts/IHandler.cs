using System;
using System.Collections.Generic;
using System.Text;

public interface IHandler
{
    void Handle(LogType eventType, String eventName);

    void SetSuccessor(IHandler handler);
}
