using System;
using System.Collections.Generic;
using System.Text;

public class StackOfStrings : Stack<string>
{
    private List<string> data;

    public void Push(string item)
    {
        this.data.Add(item);
    }

    public string Pop()
    {
        string result = this.data[data.Count - 1];
        this.data.RemoveAt(data.Count - 1);
        return result;
    }

    public string Peek()
    {
        return this.data[data.Count - 1];
    }

    public bool IsEmpty()
    {
        if (this.data.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
