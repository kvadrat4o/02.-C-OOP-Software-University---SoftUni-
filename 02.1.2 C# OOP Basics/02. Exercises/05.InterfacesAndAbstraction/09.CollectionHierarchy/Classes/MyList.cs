using System;
using System.Collections.Generic;
using System.Text;

public class MyList : IMyCollection
{
    public int Used => this.Strings.Count;

    public List<string> Strings = new List<string>();


    public int Add(string st)
    {
        this.Strings.Insert(0, st);
        return 0;
    }

    public string Remove()
    {
        string first = this.Strings[0];
        this.Strings.RemoveAt(0);
        return first;
    }
}