using System;
using System.Collections.Generic;
using System.Text;

public class Box<T> where T : IComparable
{
    private List<T> data;

    public int CountOfGreaterElements { get; private set; }

    public Box()
    {
        this.data = new List<T>();
    }

    public void Add(T element)
    {
        this.data.Add(element);
    }

    public int FindGreaterElementsCount(T element)
    {
        foreach (var item in this.data)
        {
            if (item.CompareTo(element) > 0)
            {
                this.CountOfGreaterElements++;
            }
        }

        return this.CountOfGreaterElements;
    }
}

