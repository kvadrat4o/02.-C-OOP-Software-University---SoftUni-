using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class UserCategoryController
{
    private HashSet<ICategory> categories;

    public UserCategoryController()
    {
        this.categories = new HashSet<ICategory>();
    }

    public UserCategoryController(ICollection<string> names) : this()
    {
        foreach (var categoryName in names)
        {
            this.AddCategory(categoryName);
        }
    }

    public void AddCategory(string categoryName)
    {
        if (this.categories.Any(ct => ct.Children.Any(chc => chc.Name == categoryName) || ct.Name == categoryName))
        {
            return;
        }

        this.categories.Add(new Category(categoryName));
    }

    public void AddCategory(ICollection<string> categoryNames)
    {
        foreach (var categoryName in categoryNames)
        {
            this.AddCategory(categoryName);
        }
    }

    public void RemoveCategory(string categoryName)
    {
        var category = this.categories.First(c => c.Name == categoryName);
        if (category == null)
        {
            foreach (var cat in this.categories)
            {
                if ((category = category.Children
                    .First(c => c.Name == categoryName)) != null)
                {
                    break;
                }
            }
        }

        if (category == null)
        {
            return;
        }

        category.MoveUsersToParentCategory();
        this.RemoveCategoryFromUsers(category);
        this.AddChildrentCategoriesToParentCategory(category);

        if (category.Parent == null)
        {
            this.categories.Remove(category);
        }
        else
        {
            category.Parent.RemoveChildCategory(category.Name);
        }
    }

    public void RemoveCategory(ICollection<string> categoryNames)
    {
        foreach (var categoryName in categoryNames)
        {
            this.RemoveCategory(categoryName);
        }
    }

    public void AddChild(ICategory parent, string childName) => parent.AddChild(new Category(childName));

    public void AddUser(ICategory category, IUser user) => category.AddUser(user);

    private void AddChildrentCategoriesToParentCategory(ICategory removedCategory)
    {
        if (removedCategory.Parent == null)
        {
            foreach (var category in removedCategory.Children)
            {
                this.categories.Add(category);
            }

            return;
        }

        foreach (var child in removedCategory.Children)
        {
            removedCategory.Parent.AddChild(child);
        }
    }

    private void RemoveCategoryFromUsers(ICategory removedCategory)
    {
        foreach (var user in removedCategory.Users)
        {
            user.RemoveCategory(removedCategory);
        }
    }
}
