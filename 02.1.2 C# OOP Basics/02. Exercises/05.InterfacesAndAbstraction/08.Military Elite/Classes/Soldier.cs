using System;
using System.Collections.Generic;
using System.Text;

public  abstract class Soldier : ISoldier
{
    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Id { get; private set; }

    public Soldier(string firstName, string lastName, string id)
    {
        FirstName = firstName;
        LastName = lastName;
        Id = id;
    }

    public override string ToString()
    {
        return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}";
    }
}
