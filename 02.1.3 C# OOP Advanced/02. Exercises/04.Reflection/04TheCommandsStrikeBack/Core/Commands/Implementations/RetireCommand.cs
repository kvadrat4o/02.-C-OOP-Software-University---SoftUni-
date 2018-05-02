using System;
using System.Collections.Generic;
using System.Text;

public class RetireCommand : Command
{
    public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
    {
    }

    public override string Execute()
    {
        string unitType = this.Data[1];
        if (this.Repository.Statistics.Contains(unitType))
        {
            this.Repository.RemoveUnit(unitType);
            return $"{unitType} retired!";
        }
        else
	    {
            return $"No such units in repository.";
        }
    }
}
