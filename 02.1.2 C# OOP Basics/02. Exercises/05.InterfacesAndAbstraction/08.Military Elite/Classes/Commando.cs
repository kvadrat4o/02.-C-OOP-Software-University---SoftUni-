using System;
using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    public HashSet<Mission> Missions { get; private set; }


    public Commando(string firstName, string lastName, string id, double salary, string corps) : base(firstName,lastName,id,salary,corps)
    {
        Missions = new HashSet<Mission>();
    }

    public void AddMission(Mission mission)
    {
        if (mission.State == "inProgress" || mission.State == "Finished")
        {
            this.Missions.Add(mission);
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(base.ToString() + $"\nCorps: {this.Corps}\nMissions:");
        foreach (var mis in this.Missions)
        {
            sb.AppendLine("  " + mis.ToString());
        }
        return sb.ToString().TrimEnd();
    }
}
