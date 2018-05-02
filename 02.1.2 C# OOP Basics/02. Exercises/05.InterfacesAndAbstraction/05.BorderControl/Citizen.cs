using System;
using System.Collections.Generic;
using System.Text;

public class Citizen : IIdentifiable, IBirthdatable, IPerson, IBuyer
{
    private int age;
    private string name;

    public string Id { get; set; }
    public string Birthday { get; set; }


    public Citizen(string id, string name, int age, string birthday)
    {
        Id = id;
        Name = name;
        Age = age;
        Birthday = birthday;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public int Food { get; set; }

    public void BuyFood()
    {
        this.Food += 10;
    }
}
