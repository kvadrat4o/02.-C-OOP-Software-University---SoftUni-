using System;
using System.Collections.Generic;
using System.Text;

public class AddCollection : IAddCollection
{
    public List<string> Strings = new List<string>();

    public int Add(string st)
    {
        this.Strings.Add(st);
        return this.Strings.Count - 1;
    }
}
