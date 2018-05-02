using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Lake : IEnumerable<int>
{
    public IList<int> stones;

    public int currentPosition;

    public SortedSet<int> sortedStones;

    public Lake()
    {
        this.stones = new List<int>();
        this.currentPosition = 0;
        this.sortedStones = new SortedSet<int>();
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < this.stones.Count; i++)
        {
            if (i % 2 == 0)
            {
                yield return this.stones[i];
            }
        }
        int lastEvenIndex = (this.stones.Count - 1);
        if (lastEvenIndex % 2 == 0)
        {
            lastEvenIndex = lastEvenIndex - 1;
        }
        for (int i = lastEvenIndex; i > 0; i--)
        {
            if (i % 2 == 1)
            {
                yield return this.stones[i];
            }
        }
        
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}