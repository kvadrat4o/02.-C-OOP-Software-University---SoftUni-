using System;
using System.Collections.Generic;
using System.Text;

public class Pet : IBirthdatable
{
    private string name;

    public Pet(string name, string birthday)
    {
        Name = name;
        Birthday = birthday;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }



    public string Birthday { get; set; }
}
