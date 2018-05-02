using System;
using System.Collections.Generic;
using System.Text;

public class Bubble : IBubbleSorter
{
    private IList<int> collection { get; set; }

    public Bubble()
    {
        this.collection = new List<int>();
    }

    public Bubble(IList<int> nums) : this()
    {
        if (nums != null)
        {
            foreach (var item in nums)
            {
                this.collection.Add(item);
            }
        }
    }

    public IList<int> Sort()
    {
        if (this.collection.Count == 1)
        {
            throw new InvalidOperationException("You cannot sort collection with one element!");
        }
        if (this.collection.Count == 0)
        {
            throw new ArgumentNullException("Sorting upon empty collection is not permited!");
        }
        bool areSwapped = true;
        while (areSwapped)
        {
            areSwapped = false;
            for (int i = 0; i < this.collection.Count - 1; i++)
            {
                int current = this.collection[i];
                int next = this.collection[i + 1];
                int temp = 0;
                if (current > next)
                {
                    temp = this.collection[i];
                    this.collection[i] = next;
                    this.collection[i + 1] = temp;
                    areSwapped = true;
                }
            }
        }

        return this.collection;
    }
}
