using System;
using System.Collections.Generic;
using System.Text;

public class RandomList : List<string>
{
    public string RandomString()
    {
        Random rnd = new Random();
        int index = rnd.Next();
        string result = this[index];
        this.RemoveAt(index);
        return result;
    }
}