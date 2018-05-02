using System;
using System.Collections.Generic;
using System.Text;

public abstract class Weapon : IWeapon
{
    private const int DefaultMinDamage = 0;
    private const int DefaultMaxDamage = 0;
    private const int DefaultNumOfSockets = 0;
    private Rarity rarity;

    public Rarity Rarity
    {
        get { return rarity; }
        set { rarity = value; }
    }

    private int minDamage;
    private int maxDamage;
    private string name;
    public IDictionary<int,Gem> sockets;

    public IDictionary<int,Gem> Sockets
    {
        get { return sockets; }
        protected set { sockets = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Weapon(string name,int mminDamage, int maxDamage,int numOfSockets, Rarity rarity)
    {
        this.Name = name;
        this.MaxDamage = maxDamage;
        this.MinDamage = minDamage;
        this.Sockets = new Dictionary<int, Gem>(numOfSockets);
        this.Rarity = rarity;
    }

    public int MaxDamage
    {
        get { return maxDamage; }
        set { maxDamage = value; }
    }

    public int MinDamage
    {
        get { return minDamage; }
        set { this.minDamage = value; }
    }

    IDictionary<int, Gem> IWeapon.sockets => throw new NotImplementedException();

    public void ChangeWeaponStats()
    {
        int rarityInt = (int)this.Rarity;
        int[] stats = new int[2] { this.MinDamage, this.MaxDamage };
        for (int i = 0; i < stats.Length; i++)
        {
            stats[i] *= rarityInt;
        }
        foreach (var gem in this.Sockets.Values)
        {
            gem.ChangeWeaponStats(this);
        }
    }

    public override string ToString()
    {
        return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage";
    }
}
