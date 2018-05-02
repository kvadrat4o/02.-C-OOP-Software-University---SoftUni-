using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

[TestFixture]
public class IntegrationTester
{

    private UserCategoryController userCategoryController { get; set; }

    private HashSet<ICategory> categories { get; set; }

    [SetUp]
    public void Initialize()
    {
        this.userCategoryController = new UserCategoryController();
        this.categories = (HashSet<ICategory>)this.userCategoryController.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(f => f.Name == "categories").GetValue(this.userCategoryController);
    }

    [Test]
    public void CheckIfAddCategorySavesTheCategoryAddedByName()
    {
        var categoryName = "KuraMiYanko";

        this.userCategoryController.AddCategory(categoryName);

        Assert.AreEqual(1, this.categories.Count, "AddCategory cannot save the added category");
    }

    [Test]
    [TestCase(5)]
    [TestCase(10)]
    [TestCase(30)]
    public void CheckIfAddCategorySavesTheCategoriesByCollection(int categoriesCount)
    {
        var categoryName = "KuraMiYanko";

        for (int i = 0; i < categoriesCount; i++)
        {
            this.userCategoryController.AddCategory($"{categoryName} - {i}");
        }

        Assert.AreEqual(categoriesCount, this.categories.Count, "Adding category collection does not save the collection!");
    }

    [Test]
    [TestCase(5)]
    [TestCase(10)]
    [TestCase(30)]
    public void CheckIfAddCategoryCollectionSavesTheCollection(int categoriesCount)
    {
        var categoryNames = new string[categoriesCount];
        for (int i = 0; i < categoryNames.Length; i++)
        {
            categoryNames[i] = $"Wabamama - {i}";
        }

        this.userCategoryController.AddCategory(categoryNames);

        Assert.AreEqual(categoriesCount, this.categories.Count, "Add category collection doesn't save them!");
    }

    [Test]
    public void CheCkIfAddCategoryCanWorkWithoutParams()
    {
        Assert.Throws<ArgumentException>(() => this.userCategoryController.AddCategory(""),"You cannot add a category with empty name!");
    }

    [Test]
    [TestCase(" ")]
    [TestCase("   ")]
    [TestCase("\t")]
    [TestCase("\r")]
    [TestCase("\n")]
    [TestCase("\r\n")]
    [TestCase("\n\r")]
    public void CheCkIfAddCategoryCanWorkWithEmptyParams(string categoryName)
    {
        Assert.Throws<ArgumentException>(() => this.userCategoryController.AddCategory(categoryName), "You cannot add a category with empty name!");
    }

    [Test]
    public void CheckIfAddChildAssignsTheChildCategoryToParent()
    {
        var parentName = "Koki";
        this.userCategoryController.AddCategory(parentName);
        var parentCategory = this.categories.First(c => c.Name == parentName);

        this.userCategoryController.AddChild(parentCategory, "WabaMama");

        Assert.AreEqual(parentCategory.Children.Count, 1, "AddChild doesn't add the child category to it's parent!");
    }

    [Test]
    public void CheckIfAddUserAssignsTheUserToTheCategory()
    {
        var categoryName = "KuraMiYanko";
        this.userCategoryController.AddCategory(categoryName);
        var categoryToAdd = this.categories.First(c => c.Name == categoryName);

        this.userCategoryController.AddUser(categoryToAdd, new User("Loki"));

        Assert.AreEqual(categoryToAdd.Users.Count, 1, "You cannot add the category to the user, when adding category to the list of categories!");
    }

    [Test]
    public void CheckIfAddUserAssignsTheCategoryToItsUsersCategories()
    {
        var categoryName = "KuraMiYanko";
        this.userCategoryController.AddCategory(categoryName);
        var userName = "Thor";
        var user = new User(userName);

        this.userCategoryController.AddUser(this.categories.First(), user);

        Assert.AreEqual(categoryName, user.categories.First().Name, "You cannot add category to user's categories, when adding User to category!");
    }

    [Test]
    public void CheckIfRemoveCategoryByNameRemovesTheCategory()
    {
        var categoriesCount = 10;
        var categoryname = "Wabamama - {0}";
        for (int i = 0; i < categoriesCount; i++)
        {
            this.userCategoryController.AddCategory(string.Format(categoryname, i));
        }

        this.userCategoryController.RemoveCategory(string.Format(categoryname, 0));

        Assert.AreEqual(categoriesCount - 1, this.categories.Count, "You cannot remove the category by it's name!");
    }

    [Test]
    [TestCase(10)]
    [TestCase(20)]
    public void CheckIfRemoveCategoryWithCollectionOfNamesRemovesThem(int deleteCount)
    {
        var categoryCount = deleteCount + 5;
        var categoryname = "Test - {0}";
        for (int i = 0; i < categoryCount; i++)
        {
            this.userCategoryController.AddCategory(string.Format(categoryname, i));
        }

        var deletionNames = new string[deleteCount];
        for (int i = 0; i < deletionNames.Length; i++)
        {
            deletionNames[i] = string.Format(categoryname, i);
        }

        this.userCategoryController.RemoveCategory(deletionNames);

        Assert.AreEqual(categoryCount - deletionNames.Length, this.categories.Count, "You cannto mass delete categories by their names!");
    }

    [Test]
    public void CheckIfRemoveCategoryRemovesItselfFromItsUsers()
    {
        var categoryName = "Category";
        this.userCategoryController.AddCategory(categoryName);
        var category = this.categories.First();
        var user = new User("User");
        this.userCategoryController.AddUser(category, user);

        this.userCategoryController.RemoveCategory(categoryName);

        Assert.AreEqual(0, user.categories.Count(), "You cannot remove a category without a parent from its user lists!");
    }

    private void RemoveChildCategoryContainingUser()
    {
        var parentCategoryName = "Quin Jet";
        var childCategoryName = "Daisy johnson";
        this.userCategoryController.AddCategory(parentCategoryName);
        this.userCategoryController.AddChild(this.categories.First(), childCategoryName);

        var userName = "User's Name";
        var childCategody = this.categories.First().Children.First();
        this.userCategoryController.AddUser(childCategody, new User(userName));

        this.userCategoryController.RemoveCategory(childCategoryName);
    }
}
