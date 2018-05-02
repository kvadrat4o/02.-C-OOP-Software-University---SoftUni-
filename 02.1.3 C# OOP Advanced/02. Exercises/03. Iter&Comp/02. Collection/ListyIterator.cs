using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class ListyIterator<T> : IEnumerable<T>
{

    public List<T> elements;

    public int currentIndex;

    public ListyIterator(params T[] pars)
    {
        this.elements = new List<T>(pars);
        this.currentIndex = 0;
    }

    public bool Move()
    {
        if (this.currentIndex + 1 < this.elements.Count)
        {
            this.currentIndex++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool HasNext()
    {
        return currentIndex == this.elements.Count - 1 ? false : true;
    }

    public void Print()
    {
        if (this.elements.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        Console.WriteLine(this.elements[currentIndex]);
    }

    

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.elements.Count; i++)
        {
            yield return this.elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        for (int i = 0; i < this.elements.Count; i++)
        {
            yield return this.elements[i].ToString();
        }
    }
}