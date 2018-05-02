using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class BubbleSortTester
{
    private IList<int> collection { get; set; }

    [SetUp]
    public void Initialize()
    {
        this.collection = new List<int>() { 3, 5, 2, 1, 6, 0, 4 };
    }

    [Test]
    public void CheckIfSortThrowsExceptionWhenCollectionIsEmpty()
    {
        this.collection = new List<int>();
        Bubble bubble = new Bubble(this.collection);
        Assert.Throws<ArgumentNullException>(() => bubble.Sort(),"You cannot sort empty collection!");
    }

    [Test]
    public void CheckIfSortCanSortOneIntegerCollection()
    {
        this.collection = new List<int>() { 1 };
        Bubble bubble = new Bubble(this.collection);
        Assert.Throws<InvalidOperationException>(() => bubble.Sort(), "You cannot sort collection with one element!");
    }

    [Test]
    public void CheckIfSortCanWorkWithEqualNumbers()
    {
        this.collection = new List<int>() { 1,1,1,1,1,1,1 };
        Bubble bubble = new Bubble(this.collection);

        bubble.Sort();

        Assert.AreEqual(1, this.collection[0], "Sorting on equal elements doesn't return the initial collection!");
    }

    [Test]
    public void CheckIfSortSortsCollectionWithDifferentNumbers()
    {
        Bubble bubble = new Bubble(this.collection);
        IList<int> sorted = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };

        bubble.Sort();

        //CollectionAssert.AreEqual(sorted,this.collection, "Sorting on non-equal elements doesn't work!");
        Assert.That(() => this.collection, Is.EquivalentTo(sorted), "Sorting on non-equal elements doesn't work!");
    }
}