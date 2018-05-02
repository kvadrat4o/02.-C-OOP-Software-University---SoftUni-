using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Wizard : AbstractHero
{
    private const int baseAssasinStrength = 25;
    private const int baseAssasinAgility = 25;
    private const int baseAssasinIntelligence = 100;
    private const int baseAssasinHitPoints = 100;
    private const int baseAssasinDamage = 250;

    public Wizard(string name) : base(name, baseAssasinStrength, baseAssasinAgility, baseAssasinIntelligence, baseAssasinHitPoints, baseAssasinDamage)
    {
    }
}
