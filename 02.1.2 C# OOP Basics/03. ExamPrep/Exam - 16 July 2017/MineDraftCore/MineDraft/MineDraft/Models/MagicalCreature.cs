using System;
using System.Collections.Generic;
using System.Text;

public abstract class MagicalCreature
{
    //private string id;

    protected MagicalCreature(string id)
    {
        this.Id = id;
    }

    public string Id { get; }

}