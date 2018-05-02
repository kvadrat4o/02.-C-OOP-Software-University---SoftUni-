using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class ListIterator
{

    public List<string> elements { get; set; }

    public int currentIndex { get; set; }

    public ListIterator(params string[] pars)
    {
        this.elements = new List<string>(pars);
        this.currentIndex = 0;
    }

    public bool Move()
    {
        if (this.currentIndex + 1 < this.elements.Count)
        {
            this.currentIndex++;
            return true;
        }
        else if(this.currentIndex + 1 > this.elements.Count || this.currentIndex - 1 < 0)
        {
            throw new IndexOutOfRangeException("The index was outside bounds of the array!");
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

    public string Print()
    {
        if (this.elements.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        return this.elements[currentIndex];
    }


}