using System;
using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public HashSet<Repair> Repairs { get; set; }
    

    public Engineer(string firstName, string lastName, string id, double salary, string corps) :base(firstName,lastName,id,salary,corps)
    {
        Repairs = new HashSet<Repair>();
    }

    public override string ToString()
    {
        StringBuilder bs = new StringBuilder();
        bs.AppendLine(base.ToString() + $"\nCorps: {this.Corps}\nRepairs:");
        foreach (var rep in this.Repairs)
        {
            bs.AppendLine("  " + rep.ToString());
        }
        return bs.ToString().TrimEnd();
    }
}
