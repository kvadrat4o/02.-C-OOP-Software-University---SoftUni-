using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;


[TestFixture]
public class ExtendedDatabaseTester
{
    private Database database;

    [SetUp]
    public void TestInitialization()
    {
        this.database = new Database();
    }

    [Test]
    public void CheckIfAddCannotAddPersonWithSameUsername()
    {
        this.database.Add(new Person(0, "Pesho"));

        Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(1, "Pesho")));
    }
    [Test]
    public void CheckIfAddCannotAddPersonWithSameId()
    {
        this.database.Add(new Person(0, "Pesho"));

        Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(0, "Rado")));
    }


    [Test]
    public void CheckIfRemoveDecreasesPeopleCount()
    {
        var fp = new Person(1L, "F");
        var sp = new Person(2L, "S");
        var tp = new Person(2, "T");
        this.database.Add(fp);
        this.database.Add(sp);

        this.database.Remove(tp);
        this.database.Remove(fp);

        Assert.AreEqual(1, this.database.Count, $"Remove of people doesn't work");
    }

    [Test]
    public void CheckIfFindByIdThrowsExceptionWhenIdIsNotPresent()
    {
        var fp = new Person(1L, "F");
        var sp = new Person(2L, "S");
        var tp = new Person(2, "T");
        this.database.Add(fp);
        this.database.Add(sp);

        Assert.Throws<InvalidOperationException>(() => this.database.FindById(10), "You cannot search for a non-present IDs!");
    }

    [Test]
    public void CheckIfFindByIdThrowsExceptionWhenNegativeIdIsPassed()
    {
        var fp = new Person(1L, "F");
        var sp = new Person(2L, "S");
        var tp = new Person(2, "T");
        this.database.Add(fp);
        this.database.Add(sp);

        Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(-10), "There are ni people with negative IDs in the DB!");
    }

    [Test]
    public void CheckIfFindByUsernameThrowsExceptionWhenIdIsNotPresent()
    {
        var fp = new Person(1L, "F");
        var sp = new Person(2L, "S");
        var tp = new Person(2, "T");
        this.database.Add(fp);
        this.database.Add(sp);

        Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername("KuraMiYanko"), "You cannot search for a non-present usernames!");
    }

    [Test]
    public void CheckIfFindByUsernameThrowsExceptionWhenPassedUsernameIsNull()
    {
        var fp = new Person(1L, "F");
        var sp = new Person(2L, "S");
        var tp = new Person(2, "T");
        this.database.Add(fp);
        this.database.Add(sp);

        Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(default(string)), "You cannot search for a null usernames!");
    }
    [Test]
    public void CheckIfAddPersonAddsThePerson()
    {
        var person = new Person(21L, "Mariah");

        this.database.Add(person);

        Assert.AreEqual(1, this.database.Count, $"Add Person method doesn't work");
    }


    [Test]
    public void CheckIfDatabaseConstructorWorksWithCollectionOfPeople()
    {

        var fp = new Person(21, "F");
        var sp = new Person(22L, "S");
        var collection = new IPerson[] { fp, sp };

        // Act
        this.database = new Database(collection);

        // Assert
        Assert.AreEqual(2, this.database.Count, $"Constructor doesn't work with collection of people as parameter");
    }

    [Test]
    public void CheckIfDatabaseConstructorWithNullCreatesEmptyDB()
    {

        Assert.DoesNotThrow(() => this.database = new Database(null));
    }
}
