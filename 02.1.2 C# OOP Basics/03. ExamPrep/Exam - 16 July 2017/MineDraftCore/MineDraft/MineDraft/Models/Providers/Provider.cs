using System;
using System.Collections.Generic;
using System.Text;

public abstract class Provider : MagicalCreature
{
    private const int maxEnergyOutput = 10_000;

    private double energyOutput;
    public string Type { get; protected set; }

    protected Provider(string id,double energyOutput) : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get { return  energyOutput; }
        protected set
        {
            if (value < 0 || value > maxEnergyOutput)
            {
                throw new ArgumentException(Exceptions.providerEnergy);
            }
            energyOutput = value;
        }
    }

    public override string ToString()
    {
        return $"{this.Type} Provider - {this.Id}" + Environment.NewLine
                +  $"Energy Output: {this.EnergyOutput}";
    }
}