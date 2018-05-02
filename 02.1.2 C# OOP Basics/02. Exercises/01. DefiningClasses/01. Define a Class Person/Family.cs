
using System.Collections.Generic;
using System.Linq;

public class Family
{
    private List<Person> people;

    public List<Person> People { get => this.people; set => this.people = value; }

    public Family()
    {
        this.people = new List<Person>();
    }
    public void AddMember(Person member)
    {
        this.people.Add(member);
    }
    public Person GetOldestMember()
    {
        return this.people.OrderByDescending(a => a.Age).FirstOrDefault();
    }
}
