using System;
using System.Collections.Generic;
using System.Text;

public class Knife : Weapon
{
    private const int DefaultMinDamage = 3;
    private const int DefaultMaxDamage = 4;
    private const int DefaultNumOfSockets = 2;

    public Knife(string name,Rarity rarity) : base(name, DefaultMinDamage, DefaultMaxDamage, DefaultNumOfSockets,rarity)
    {
    }
}
