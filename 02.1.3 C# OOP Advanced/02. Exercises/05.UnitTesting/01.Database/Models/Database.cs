using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Database
{
    public int[] list { get; set; }

    public int count { get; set; }

    public const int MinArrayCapacity = 16;

    public Database()
    {
        this.list = new int[MinArrayCapacity];
    }

    public Database(int[] numbers):this()
    {
        if (numbers != null)
        {
            foreach (var item in numbers)
            {
                this.Add(item);
            }
        }
    }

    public Database(IEnumerable<int> numbers)
            : this()
    {
        foreach (var item in numbers)
        {
            this.Add(item);
        }
    }

    public void Add(int element)
    {
        
        if (this.count >= 16)
        {
            throw new ArgumentOutOfRangeException("You cannot add more than 16 elements in the array!");
        }
        this.list[this.count] = element;
        this.count++;
    }

    public void Remove()
    {
        if (this.count == 0)
        {
            throw new InvalidOperationException("You cannot remove elements fromman empty array!");
        }
        //this.list[this.list.Length - 1] = default(int);
        this.count--;
    }

    public int[] Fetch() => this.list.Take(this.count).ToArray();
}
