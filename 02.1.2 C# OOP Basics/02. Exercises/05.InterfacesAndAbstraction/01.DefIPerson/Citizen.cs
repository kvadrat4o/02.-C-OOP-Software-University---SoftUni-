using System;
using System.Collections.Generic;
using System.Text;

public class Citizen : IPerson, IBirthable, IIdentifiable
{
    public int Age { get; set; }

    public string Name { get; set; }

    public string Id { get; set; }

    public string Birthdate { get; set; }

    public Citizen(string name, int age, string id, string birthdate)
    {
        Age = age;
        Name = name;
        Id = id;
        Birthdate = birthdate;
    }
}
