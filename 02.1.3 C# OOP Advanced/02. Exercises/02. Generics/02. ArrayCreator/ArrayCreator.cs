using System;
using System.Collections.Generic;
using System.Text;

public static class ArrayCreator
{
    public static T[] Create<T>(int length, T item)
    {
        var arr = new T[length];

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = item;
        }

        return arr;
    }
}

