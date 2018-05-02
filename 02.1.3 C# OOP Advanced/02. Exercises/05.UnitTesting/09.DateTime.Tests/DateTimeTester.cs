using NUnit.Framework;
using System;

[TestFixture]
public class DateTimeTester
{
    private IDatetime sut;

    [SetUp]
    public void TestInit()
    {
        this.sut = new CustomDateTime();
    }

    [Test]
    public void NowShouldReturnCurrentDate()
    {
        // Arrange 
        var expectedValue = DateTime.Now.Date;

        // Assert
        Assert.AreEqual(expectedValue, this.sut.Now().Date);
    }

    [Test]
    public void AddingADayToTheLastOneOfAMonthShouldResultInTheFirstDayOfTheNextMonth()
    {
        // Arrange
        var testDate = new DateTime(2000, 10, 31);
        var expectedDate = new DateTime(2000, 11, 1);

        // Act
        testDate = testDate.AddDays(1);

        // Assert
        Assert.AreEqual(expectedDate, testDate);
    }
}
