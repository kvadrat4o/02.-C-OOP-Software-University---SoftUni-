using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Sorter
{
    public static void Sort<T>(MyCustomList<T> list) where T:IComparable
    {
        var newList = new List<T>();
        var listCount = list.Count;

        for (int i = 0; i < listCount; i++)
        {
            newList.Add(list.Remove(0));
        }

        newList = newList.OrderBy(a => a).ToList();

        for (int i = 0; i < listCount; i++)
        {
            list.Add(newList[i]);
        }
    }
}

