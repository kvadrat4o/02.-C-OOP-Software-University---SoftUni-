using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class LinkedList<T> : IEnumerable<T>
{
    public int Count => this.data.Count;

    public IList<T> data;

    public LinkedList()
    {
        this.data = new List<T>();
    }

    public IEnumerator<T> GetEnumerator()
    {
       return this.data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public void Add(T item)
    {
        this.data.Add(item);
    }

    public bool Remove(T item)
    {
        return this.data.Remove(item);
    }
}
