using System;
using System.Collections.Generic;
using System.Text;

public class Spy : Soldier,  ISpy
{
    public int SpyCode { get; private set; }

    public Spy(string firstName, string lastName, string id, int spyCode) :base(firstName,lastName,id)
    {
        SpyCode = spyCode;
    }

    public override string ToString()
    {
        return base.ToString() + $"\nCode Number: {this.SpyCode}";
    }
}
