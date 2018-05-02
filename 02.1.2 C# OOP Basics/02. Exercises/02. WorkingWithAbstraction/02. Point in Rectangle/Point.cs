﻿public class Point
{
    private int x;
    private int y;

    public int X
    {
        get { return x; }
        set { x = value; }
    }
    
    public int Y
    {
        get { return y; }
        set { y = value; }
    }

    public Point()
    {

    }

    public Point(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }
}