using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CasualRace : Race
{
    public CasualRace(int prizePool, string route, int length) : base(prizePool, route, length)
    {

    }

    public override string ToString()
    {
        //(Horsepower / acceleration) + (suspension + durability)
        int counter = 1;
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        foreach (var participant in this.Participants)
        {
            participant.power = (participant.HorsePower / participant.Acceleration) + (participant.Suspension + participant.Durability);
        }
        this.Participants = this.Participants.OrderByDescending(c => c.power).ToList();
        var fPrize = ( this.PrizePool * 50 ) / 100;
        var sPrize = ( this.PrizePool * 30 ) / 100;
        var tPrize = ( this.PrizePool * 20 ) / 100;
        if (this.Participants.Count >= 3)
        {
            this.Participants = this.Participants.Take(3).ToList();
            sb.AppendLine($"{counter}. {this.Participants.First().Brand} {this.Participants.First().Model} {this.Participants.First().power}PP - ${fPrize}");
            sb.AppendLine($"{counter}. {this.Participants[1].Brand} {this.Participants[1].Model} {this.Participants[1].power}PP - ${sPrize}");
            sb.AppendLine($"{counter}. {this.Participants.Last().Brand} {this.Participants.Last().Model} {this.Participants.Last().power}PP - ${tPrize}");
        }
        else if (this.Participants.Count == 2)
        {
            this.Participants = this.Participants.Take(2).ToList();
            sb.AppendLine($"{counter}. {this.Participants.First().Brand} {this.Participants.First().Model} {this.Participants.First().power}PP - ${fPrize}");
            sb.AppendLine($"{counter}. {this.Participants.Last().Brand} {this.Participants.Last().Model} {this.Participants.Last().power}PP - ${tPrize}");
        }
        else
        {
            sb.AppendLine($"{counter}. {this.Participants.First().Brand} {this.Participants.First().Model} {this.Participants.First().power}PP - ${fPrize}");
        }
        return sb.ToString().TrimEnd();
    }
}
