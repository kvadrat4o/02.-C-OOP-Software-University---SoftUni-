using System;
using System.Collections.Generic;
using System.Text;

public class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;

    public const int minAge = 40;

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public List<Person> FirstTeam
    {
        get { return this.firstTeam; }
       //set { firstTeam = value; }
    }
    
    public List<Person> ReserveTeam
    {
        get { return this.reserveTeam; }
        //set { reverseTeam = value; }
    }

    public Team()
    {

    }

    public Team(string name)
    {
        this.Name = name;
        this.firstTeam = new List<Person>();
        this.reserveTeam = new List<Person>();
    }

    public void AddPlayer(Person person)
    {
        if (person.Age < minAge)
        {
            firstTeam.Add(person);
        }
        else
        {
            reserveTeam.Add(person);
        }
    }

    public override string ToString()
    {
        return $"First team has {this.firstTeam.Count} players.\nReserve team has {this.reserveTeam.Count} players.";
    }
}