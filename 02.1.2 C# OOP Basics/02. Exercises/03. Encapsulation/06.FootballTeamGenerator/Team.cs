using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Team
{
    private string name;
    private int rating;
    private List<Player> players;

    public List<Player> Players
    {
        get { return players; }
        set { players = value; }
    }

    public int Rating
    {
        get { return rating; }
        set { rating = value; }
    }
    
    public string Name
    {
        get { return name; }
        private set
        {
            if (value == String.Empty || value == "" || value == "  " || value == null || value == " ")
            {
                throw new ArgumentException("A name should not be empty.");
            }
            name = value;
        }
    }

    public Team()
    {
        this.Players = new List<Player>();
    }

    public Team(string name)
        :this()
    {
        Name = name;
    }

    public Team(List<Player> players, int rating, string name)
    {
        Players = players;
        Rating = rating;
        Name = name;
    }
    public void AddPlayer(Player player)
    {
        this.Players.Add(player);
    }

    public void RemovePlayer(Player player)
    {
        List<Player> fakeList = new List<Player>();
        if (!this.Players.Any(a => a.Name == player.Name))
        {
            throw new ArgumentException($"Player {player.Name} is not in {this.Name} team.");
        }
        int index = 0;
        for (int i = 0; i < this.Players.Count; i++)
        {
            if (this.Players[i].Name == player.Name)
            {
                index = i;
            }
        }
        this.Players.RemoveAt(index);
    }

    public double GetTeamRating()
    {
        if (this.Players.Count == 0)
        {
            return  0;
        }
        else
        {
            return Math.Round(this.Players.Average(a => a.GetStats()));
        }
    }
}
