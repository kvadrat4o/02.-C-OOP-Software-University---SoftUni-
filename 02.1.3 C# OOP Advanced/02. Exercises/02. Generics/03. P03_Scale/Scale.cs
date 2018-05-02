using System;
using System.Collections.Generic;
using System.Text;

public class Scale<T> where T : IComparable<T>
{
    public T Left { get; set; }
    public T Right { get; set; }

    public Scale(T left, T right)
    {
        this.Right = right;
        this.Left = left;
    }

    public T GetHeavier()
    {
        var result = this.Left.CompareTo(this.Right);

        if (result > 0)
        {
            return this.Left;
        }
        else if (result < 0)
        {
            return this.Right;
        }

        return default(T);
    }
}

