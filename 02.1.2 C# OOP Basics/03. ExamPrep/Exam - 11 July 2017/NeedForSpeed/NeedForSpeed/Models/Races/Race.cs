using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Race
{
    private int length;
    private string route;
    private int prizePool;
    private List<Car> participants;

    public Race(int length, string route, int prizePool)
    {
        this.PrizePool = prizePool;
        this.Route = route;
        this.Length = length;
        this.Participants = new List<Car>();
    }

    public List<Car> Participants
    {
        get { return participants; }
        protected set { participants = value; }
    }

    public int PrizePool
    {
        get { return prizePool; }
        protected set { prizePool = value; }
    }

    public string Route
    {
        get { return route; }
        protected set { route = value; }
    }

    public int Length
    {
        get { return length; }
        protected set { length = value; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        
        if (this.Participants.Count < 0 )
        {
            sb.AppendLine("Cannot start the race with zero participants.");
            return sb.ToString();
        }
        else
        {
            sb.AppendLine($"{this.Route} - {this.Length}");
        }
        return sb.ToString();
    }
}
