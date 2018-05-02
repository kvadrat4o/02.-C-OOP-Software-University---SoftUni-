using System;
using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    public double OreProduced { get; protected set; }

    private IHarvesterFactory factory;

    private IEnergyRepository energyRepository;

    protected IList<IHarvester> harvesters;

    public double TotalEnergyProduced { get;  protected set; }
    
    private string mode;

    private double modeFactor;

    public HarvesterController(IEnergyRepository repository)
    {
        this.energyRepository = repository;
        this.harvesters = new List<IHarvester>();
        this.factory = new HarvesterFactory();
        this.mode = "Full";
    }

    public string ChangeMode(string mode)
    {
        this.mode = mode;
        List<IHarvester> reminder = new List<IHarvester>();

        foreach (var harvester in this.harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch (Exception ex)
            {
                reminder.Add(harvester);
            }
        }

        foreach (var entity in reminder)
        {
            this.harvesters.Remove(entity);
        }
        return $"Mode changed to {mode}!";
    }

    public string Produce()
    {
        double totalOre = this.harvesters.Sum(h => h.Produce());
        double totalEnergy = this.harvesters.Sum(h => h.EnergyRequirement);
        this.TotalEnergyProduced += totalEnergy;
        if (this.energyRepository.TakeEnergy(totalEnergy) == true)
        {
            if (this.mode == "Energy")
            {
                this.modeFactor = 0.20;
                totalOre *= this.modeFactor;
                totalEnergy *= this.modeFactor;
            }
            else if (this.mode == "Half")
            {
                this.modeFactor = 0.50;
                totalOre *= this.modeFactor;
                totalEnergy *= this.modeFactor;
            }
            this.OreProduced += totalOre;
            return $"Produced {totalOre} ore today!";
        }
        else
        {
            return $"Produced 0 ore today!";
        }
        
    }

    public string Register(IList<string> args)
    {
        try
        {
            IHarvester harvester = this.factory.GenerateHarvester(args.Skip(2).ToList());
            this.harvesters.Add(harvester);
            return string.Format(Constants.SuccessfullRegistration,
            harvester.GetType().Name);
        }
        catch (Exception e)
        {
           return "0";
        }
    }

    public string CheckForHarvester(int id)
    {
        if (this.harvesters.Any(h => h.ID == id))
        {
            return this.harvesters.FirstOrDefault(h => h.ID == id).ToString();
        }
        else
        {
            return $"No entity found with id - {id}";
        }
    }

    public bool IdExists(int id)
    {
        if (this.harvesters.Any(h => h.ID == id))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}