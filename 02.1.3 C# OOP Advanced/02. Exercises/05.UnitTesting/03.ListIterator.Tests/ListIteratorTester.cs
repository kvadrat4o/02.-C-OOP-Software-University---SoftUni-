using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


[TestFixture]
public class ListIteratorTester
{

    private ListIterator list { get; set; }

    [SetUp]
    public void Initialize()
    {
        this.list = new ListIterator("Sahso", "Ivan", "Rila", "Kiro", "Mira", "", "Vankata");
    }

    [Test]
    public void CheckIfConstructorCannotWorkWithNull()
    {
        Assert.Throws<ArgumentNullException>(() => new ListIterator(null),"You cannot initialize an empty listIterator structure!");
    }

    [Test]
    public void CheckIfPrintCanWorkWithEmptyCollection()
    {
        this.list = new ListIterator();

        Assert.Throws<InvalidOperationException>(() => this.list.Print(), "Invalid Operation! - you cannot print element from an empty list!");
    }

    [Test]
    public void CheckIfPrintReturnsTheCorrectElementFromTheCollection()
    {
        
        this.list.Move();
        this.list.Move();
        this.list.Move();
        this.list.Move();
        this.list.Move();
        this.list.Move();
        this.list.Move();


        Assert.AreEqual("Vankata", this.list.Print(), "Print() method doesn't return the element at the current index of the collection!");
    }

    [Test]
    public void CheckIfMoveReturnsTrueIfSuccessful()
    {
        Assert.AreEqual(true, this.list.Move(),"You cannot move the current index to the next index!");
    }

    [Test]
    public void CheckIfMoveReturnsFalseIfNotSuccessful()
    {
        this.list.Move();
        this.list.Move();
        this.list.Move();
        this.list.Move();
        this.list.Move();
        this.list.Move();
        this.list.Move();
        this.list.Move();

        Assert.AreEqual(false, this.list.Move(), "You cannot move the current index outside of the boounds of the iterator!");
    }

    [Test]
    public void CheckIfMoveMovesTheCurrentIndex()
    {
        this.list.Move();

        var currIndex = typeof(ListIterator).GetProperties(BindingFlags.Instance | BindingFlags.Public).First(f => f.Name == "currentIndex").GetValue(this.list);

        Assert.AreEqual(1, currIndex, "Move doesn't move the current index to the next one!");
    }

    [Test]
    public void CheckIfHasNextReturnsTrueIfSuccessful()
    {
        Assert.IsTrue(this.list.HasNext(), "You cannot have next element!");
    }

    [Test]
    public void CheckIfHasNextReturnsFalseIfNotSuccessful()
    {
        this.list = new ListIterator("Sahso", "Ivan");

        this.list.Move();

        Assert.IsFalse(this.list.HasNext(), "The sequence has no next element! - you are at the last possible element!");
    }
}