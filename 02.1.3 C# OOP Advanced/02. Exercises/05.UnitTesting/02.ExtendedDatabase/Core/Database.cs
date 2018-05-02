using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Database
{
    private HashSet<IPerson> people;

    public Database()
    {
        this.people = new HashSet<IPerson>();
    }

    public Database(IEnumerable<IPerson> people)
        : this()
    {
        if (people != null)
        {
            foreach (var person in people)
            {
                this.Add(person);
            }
        }
    }

    public int Count => this.people.Count;

    public void Add(IPerson person)
    {
        if (this.people.Any(p => p.Id == person.Id || p.Username == person.Username))
        {
            throw new InvalidOperationException("You cannot add the same person twice!");
        }

        this.people.Add(person);
    }

    public void Remove(IPerson person)
    {
        this.people.RemoveWhere(p => p.Id == person.Id && p.Username == person.Username);
    }

    public IPerson FindById(long id)
    {
        if (id < 0)
        {
            throw new ArgumentOutOfRangeException("You cannot find people with index less than 0!");
        }

        var personInDb = this.people.FirstOrDefault(p => p.Id == id);
        if (personInDb == null)
        {
            throw new InvalidOperationException("You cannot return a person, with null value!");
        }

        return personInDb;
    }

    public IPerson FindByUsername(string username)
    {
        if (username == null)
        {
            throw new ArgumentNullException("You cannot find person with username 'null'!");
        }

        var personInDb = this.people.FirstOrDefault(p => p.Username == username);
        if (personInDb == null)
        {
            throw new InvalidOperationException("You cannot return a person, with null value!");
        }

        return personInDb;
    }
}
