using System;
using System.Collections.Generic;
using System.Text;

public class Rebel : IPerson, IBuyer
{
    private string group;

    public Rebel()
    {
        this.Food = 0;
    }

    public Rebel(string name, int age, string group)
        :base()
    {
        Name = name;
        Age = age;
        Group = group;
    }

    public string Name { get; set; }

    public int Age { get; set; }

    public string Group
    {
        get { return group; }
        set { group = value; }
    }

    public int Food { get; set; }

    public void BuyFood()
    {
        this.Food += 5;
    }
}
