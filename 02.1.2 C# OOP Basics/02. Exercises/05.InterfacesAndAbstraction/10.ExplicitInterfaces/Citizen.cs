using System;
using System.Collections.Generic;
using System.Text;

public class Citizen : IResident, IPerson
{
    public string Name { get; set; }

    public int Age { get; set; }

    public string Country { get; set; }

    public Citizen(string name, int age, string country)
    {
        Name = name;
        Age = age;
        Country = country;
    }

    public override string ToString()
    {
        return base.ToString();
    }

    string IResident.GetName()
    {
        return "Mr/Ms/Mrs ";
    }

    string IPerson.GetName()
    {
        return $"{this.Name}";
    }
}