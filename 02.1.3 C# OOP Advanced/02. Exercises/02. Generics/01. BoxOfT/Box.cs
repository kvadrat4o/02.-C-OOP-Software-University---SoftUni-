using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Box<T>
{
    private IList<T> data;

    public int Count => this.data.Count;

    public Box()
    {
        this.data = new List<T>();
    }

    public void Add(T element)
    {
        this.data.Add(element);
    }

    public T Remove()
    {
        var element = this.data.LastOrDefault();
        this.data.RemoveAt(this.Count - 1);
        return element;
    }
}

