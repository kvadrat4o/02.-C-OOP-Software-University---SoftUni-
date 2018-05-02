using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class ListyIterator<T>
{

    public List<T> elements { get; set; }

    public int currentIndex { get; set; }

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
       return currentIndex == this.elements.Count ? false : true;
    }

    public void Print()
    {
        if (this.elements.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        Console.WriteLine(this.elements[currentIndex]);
    }


}