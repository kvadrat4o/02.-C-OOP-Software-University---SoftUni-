using System;
using System.Collections.Generic;
using System.Text;

public abstract class Gem : IGem
{
    private int vitality;
    private int agility;
    private int strength;
    private QualityLevel quality;
    private string type;

    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    public QualityLevel Quality
    {
        get { return quality; }
        set { quality = value; }
    }

    protected int DefaultVitality = 0;
    protected int DefaultAgility = 0;
    protected int DefaultStrength = 0;

    public Gem(string type, QualityLevel quality)
    {
        this.Type = type;
        this.Quality = quality;
        this.Vitality = this.DefaultVitality;
        this.Agility = this.DefaultAgility;
        this.Strength = this.DefaultStrength;
    }

    public int Strength
    {
        get { return strength; }
        set { strength = value; }
    }

    public int Agility
    {
        get { return agility; }
        set { agility = value; }
    }

    public int Vitality
    {
        get { return vitality; }
        set { vitality = value; }
    }


    public void ChangeGemStats()
    {
        var typeOfGem = this.GetType();
        int qualityInt = (int)this.Quality;
        int[] stats = new int[3] { this.Vitality, this.Strength, this.Agility };
        for (int i = 0; i < stats.Length; i++)
        {
            stats[i] += qualityInt;
        }
    }

    public void ChangeWeaponStats(Weapon weapon)
    {
        for (int i = 0; i < this.Strength; i++)
        {
            weapon.MinDamage += 2;
            weapon.MaxDamage += 3;
        }
        for (int i = 0; i < this.Agility; i++)
        {
            weapon.MinDamage += 1;
            weapon.MaxDamage += 4;
        }
    }

    public override string ToString()
    {
        return $", +{this.Strength} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality";
    }
}
