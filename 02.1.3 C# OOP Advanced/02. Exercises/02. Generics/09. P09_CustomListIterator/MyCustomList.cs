using System;
using System.Collections.Generic;
using System.Linq;

public class MyCustomList<T> where T : IComparable
{
    private List<T> data;

    public int Count => this.data.Count;

    public MyCustomList()
    {
        this.data = new List<T>();
    }

    public void Add(T element)
    {
        this.data.Add(element);
    }

    public T Remove(int index)
    {
        var element = data[index];
        data.RemoveAt(index);
        return element;
    }

    public bool Contains(T element)
    {
        if (this.data.Contains(element))
        {
            return true;
        }
        return false;
    }

    public void Swap(int index1, int index2)
    {
        var element1 = this.data[index1];
        var element2 = this.data[index2];

        this.data[index1] = element2;
        this.data[index2] = element1;
    }

    public int CountGreaterThan(T element)
    {
        int counter = 0;

        foreach (var item in this.data)
        {
            if (item.CompareTo(element) > 0)
            {
                counter++;
            }
        }
        return counter;
    }

    public T Max()
    {
        return this.data.Max();
    }

    public T Min()
    {
        return this.data.Min();
    }

    public void Print()
    {
        foreach (var item in this.data)
        {
            Console.WriteLine(item);
        }
    }

    //public void Sort()
    //{
    //    Sorter.Sort<T>(this.data);
    //}
}

