﻿using System;
using System.Collections.Generic;
using System.Text;

public class BookComparator : IComparer<Book>
{
    public BookComparator()
    {

    }

    public int Compare(Book x, Book y)
    {
        int result = x.Title.CompareTo(y.Title);
        if (result == 0)
        {
            result = y.Year.CompareTo(x.Year);
        }

        return result;
    }
}