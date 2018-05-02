using System;
using System.Collections.Generic;
using System.Text;

public class Mission
{
    public string CodeName { get; private set; }

    public string State { get; private set; }

    public Mission(string codeName, string state)
    {
        CodeName = codeName;
        State = state;
    }

    public override string ToString()
    {
        return $"Code Name: {this.CodeName} State: {this.State}";
    }
}