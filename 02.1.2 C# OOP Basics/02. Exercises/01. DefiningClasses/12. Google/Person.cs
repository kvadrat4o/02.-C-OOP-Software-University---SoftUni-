using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private Company company;

    public Company Company
    {
        get { return company; }
        set { company = value; }
    }

    private Car car;

    public Car Car
    {
        get { return car; }
        set { car = value; }
    }

    private List<Child> children;

    public List<Child> Children
    {
        get { return children; }
        set { children = value; }
    }

    private List<Parent> parents;

    public List<Parent> Parents
    {
        get { return parents; }
        set { parents = value; }
    }

    private List<Pokemon> pokemons;

    public List<Pokemon> Pokemons
    {
        get { return pokemons; }
        set { pokemons = value; }
    }

    public Person()
    {
        this.Parents = new List<Parent>();
        this.Children = new List<Child>();
        this.Pokemons = new List<Pokemon>();
    }

    public Person(string name, Car car, Company company, List<Parent> parents, List<Child> children, List<Pokemon> pokemons)
    {
        this.Name = name;
        this.Car = car;
        this.Company = company;
        this.Pokemons = pokemons;
        this.Parents = parents;
        this.Children = children;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(this.Name);
        sb.AppendLine("Company:");
        if (this.Company != null)
        {
            sb.AppendLine($"{this.Company.Name} {this.Company.Department} {this.Company.Salary:F2}");
        }
        sb.AppendLine("Car:");
        if (this.Car != null)
        {
            sb.AppendLine($"{this.Car.Model} {this.Car.Speed}");
        }
        sb.AppendLine("Pokemon:");
        if (this.Pokemons != null)
        {
            foreach (var pokemon in this.Pokemons)
            {
                sb.AppendLine($"{pokemon.Name} {pokemon.Type}");
            }
        }
        sb.AppendLine("Parents:");
        if (this.Parents != null)
        {
            foreach (var parent in this.Parents)
            {
                sb.AppendLine($"{parent.Name} {parent.Birthday}");
            }
        }
        sb.AppendLine("Children:");
        if (this.Children != null)
        {
            foreach (var child in this.Children)
            {
                sb.AppendLine($"{child.Name} {child.Birthday}");
            }
        }
        return sb.ToString();
    }
}
