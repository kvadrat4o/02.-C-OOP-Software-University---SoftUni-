using System;
using System.Collections.Generic;
using System.Text;

public class Axe : Weapon
{
    private const int DefaultMinDamage = 5;
    private const int DefaultMaxDamage = 10;
    private const int DefaultNumOfSockets = 4;

    public Axe(string name,Rarity rarity) : base(name,DefaultMinDamage,DefaultMaxDamage,DefaultNumOfSockets,rarity)
    {
    }
}