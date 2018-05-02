
using System.Collections.Generic;

public class Trainer
{
    private string name;
    private int numBadges;
    private List<Pokemon> pokemons;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    
    public int NumBadges
    {
        get { return numBadges; }
        set { numBadges = value; }
    }
    
    public List<Pokemon> Pokemons
    {
        get { return pokemons; }
        set { pokemons = value; }
    }

    public Trainer()
    {
        this.Pokemons = new List<Pokemon>();
        this.NumBadges = 0;
    }
    public Trainer(string name, List<Pokemon> pokemons, int numBadges)
    {
        this.Name = name;
        this.Pokemons = pokemons;
        this.NumBadges = numBadges;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.NumBadges} {this.Pokemons.Count}";
    }
}
