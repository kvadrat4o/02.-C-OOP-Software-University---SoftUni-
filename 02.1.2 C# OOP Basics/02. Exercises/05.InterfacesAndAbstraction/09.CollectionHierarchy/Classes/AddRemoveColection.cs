using System;
using System.Collections.Generic;
using System.Text;

public class AddRemoveColection : IAddRemoveCollection
{

    public List<string> Strings = new List<string>();

    public int Add(string st)
    {
        this.Strings.Insert(0,st);
        return 0;
    }

    public string Remove()
    {
        string last = this.Strings[this.Strings.Count - 1];
        this.Strings.RemoveAt(this.Strings.Count - 1);
        return last;
    }
}
