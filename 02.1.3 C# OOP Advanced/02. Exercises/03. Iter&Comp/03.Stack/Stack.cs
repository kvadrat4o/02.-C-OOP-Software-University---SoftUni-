using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Stack<T> : IEnumerable<T>
{
    public IList<T> data;

    public int Count;

    public Stack()
    {
        this.data = new List<T>();
        this.Count = 0;
    }

    public void Push(T element)
    {
        this.data.Add(element);
        this.Count++;
    }

    public void Pop()
    {
        if (this.data.Count == 0)
        {
            Console.WriteLine("No elements");
        }
        else
        {
            this.data.RemoveAt(this.data.Count - 1);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.data.Count; i > 0; i--)
        {
            yield return this.data[i];
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}