using System;

public class StandartHarvester : Harvester
{
    private double durability;

    public StandartHarvester(int id, double oreOutput, double energyRequirement) : base(id, oreOutput,
        energyRequirement)
    {
    }
}