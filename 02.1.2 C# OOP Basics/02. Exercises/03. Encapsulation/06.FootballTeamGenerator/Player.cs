using System;
using System.Collections.Generic;
using System.Text;

public class Player
{
    private string name;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    public int Shooting
    {
        get { return shooting; }
        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"Shooting should be between 0 and 100.");
            }
            shooting = value;
        }
    }

    public int Passing
    {
        get { return passing; }
        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"Passing should be between 0 and 100.");
            }
            passing = value;
        }
    }

    public int Dribble
    {
        get { return dribble; }
        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"Dribble should be between 0 and 100.");
            }
            dribble = value;
        }
    }

    public int Sprint
    {
        get { return sprint; }
        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"Sprint should be between 0 and 100.");
            }
            sprint = value;
        }
    }

    public int Endurance
    {
        get { return endurance; }
        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"Endurance should be between 0 and 100.");
            }
            endurance = value;
        }
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

    public Player()
    {

    }

    public Player(string name)
    {
        Name = name;
    }

    public Player(global::System.Int32 shooting, global::System.Int32 passing, global::System.Int32 dribble, global::System.Int32 sprint, global::System.Int32 endurance, global::System.String name)
    {
        Shooting = shooting;
        Passing = passing;
        Dribble = dribble;
        Sprint = sprint;
        Endurance = endurance;
        Name = name;
    }

    public double GetStats() =>  (this.Dribble + this.Endurance +  this.Passing + this.Shooting + this.Sprint ) / 5.00;
}