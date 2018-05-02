using System;
using System.Collections.Generic;
using System.Text;

public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    private string corps;

    public string Corps
    {
        get
        {
            return this.corps;
        }
        private set
        {
            if (value == "Airforces" || value == "Marines")
            {
                this.corps = value;
            }
        }
    }

    public SpecialisedSoldier(string firstName, string lastName, string id, double salary,string corps) : base(firstName,lastName,id,salary)
    {
        Corps = corps;
    }
}
