using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Barbarian : AbstractHero
{
    private const int baseAssasinStrength = 90;
    private const int baseAssasinAgility = 25;
    private const int baseAssasinIntelligence = 10;
    private const int baseAssasinHitPoints = 350;
    private const int baseAssasinDamage = 150;

    public Barbarian(string name) : base(name, baseAssasinStrength, baseAssasinAgility, baseAssasinIntelligence, baseAssasinHitPoints, baseAssasinDamage)
    {
    }
}
