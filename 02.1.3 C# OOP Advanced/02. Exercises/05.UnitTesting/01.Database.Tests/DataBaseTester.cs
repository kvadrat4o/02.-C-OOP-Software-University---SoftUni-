using NUnit.Framework;
using System;


[TestFixture]
public class DataBaseTester
{
    [Test]
    public void CheckIfArrayCanBeInitializedWithLessThan16Elements()
    {
        int[] nums = new int[15] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        Database db ;

        db = new Database(nums);

        Assert.AreEqual(7, db.list[6], "Removal only for the last element is supported");
    }

    [Test]
    public void CheckIfArrayCanBeCreatedWithMoreThan16Elements()
    {
        int[] nums = new int[17] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
        Database db;

        Assert.Throws<ArgumentOutOfRangeException>(() => db = new Database(nums), "The length of the array must be exactly 16 elements long!");
    }

    [Test]
    public void CheckIfAddMethodAddsElementOnTheLastPosition()
    {
        int[] nums = new int[14];
        Database db = new Database(nums);
        db.Add(89);
        Assert.AreEqual(89, db.list[14], "The element must be added at the last vacant position!");
    }

    [Test]
    public void TryToAddMoreThan16elementsInTheArray()
    {
        int[] nums = new int[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13,14,15,16 };
        Database db = new Database(nums);

        Assert.Throws<ArgumentOutOfRangeException>(() => db.Add(89), "You cannot add more than 16 elements in the array!");
    }

    [Test]
    public void TryToRemoveElementOnPositionDifferentThanTheLastOne()
    {
        int[] nums = new int[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        Database db = new Database(nums);

        db.Remove();

        Assert.AreEqual(16,db.list[db.list.Length - 1], "Removal only for the last element is supported");
    }

    [Test]
    public void TryToRemoveElementFromEmptyDBlist()
    {
       
        Database db = new Database();

        Assert.Throws<InvalidOperationException>(() => db.Remove(),"Removal from an empty DB is not supported");
    }

    [Test]
    public void CheckIfFetchMethodReturnsElementsAsArray()
    {
        int[] numbers = new int[16];
        Database db = new Database(numbers);
        var dataBaseContent = db.Fetch();
        for (int i = 0; i < dataBaseContent.Length; i++)
        {
            Assert.AreEqual(numbers[i], dataBaseContent[i]);
        }
    }

    [Test]
    public void CheckIfConstructorReturnsInitialArray()
    {
        int[] numbers = new int[16];
        Database db = new Database(numbers);
        for (int i = 0; i < db.list.Length; i++)
        {
            Assert.AreEqual(numbers[i], db.list[i]);
        }
    }
}
