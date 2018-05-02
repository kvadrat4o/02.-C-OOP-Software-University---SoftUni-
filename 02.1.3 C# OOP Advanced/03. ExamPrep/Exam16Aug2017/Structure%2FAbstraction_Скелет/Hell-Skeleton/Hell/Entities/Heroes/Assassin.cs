using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Assassin : AbstractHero
{
    private const int baseAssasinStrength = 25;
    private const int baseAssasinAgility = 100;
    private const int baseAssasinIntelligence = 15;
    private const int baseAssasinHitPoints = 150;
    private const int baseAssasinDamage = 300;

    public Assassin(string name) : base(name, baseAssasinStrength, baseAssasinAgility, baseAssasinIntelligence, baseAssasinHitPoints, baseAssasinDamage)
    {
    }
}