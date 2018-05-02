using System;
using System.Collections.Generic;
using System.Text;

public interface IPerson : IIdentifier
{
    string Username { get; }
}
