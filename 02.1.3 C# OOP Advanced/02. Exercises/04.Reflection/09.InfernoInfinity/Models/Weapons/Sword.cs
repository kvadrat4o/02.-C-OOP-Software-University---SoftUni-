using System;
using System.Collections.Generic;
using System.Text;

public class Sword : Weapon
{
    private const int DefaultMinDamage = 4;
    private const int DefaultMaxDamage = 6;
    private const int DefaultNumOfSockets = 3;

    public Sword(string name,Rarity rarity) : base(name, DefaultMinDamage, DefaultMaxDamage, DefaultNumOfSockets,rarity)
    {
    }
}
