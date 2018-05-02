using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Category : ICategory
{

    private string name;
    private IList<IUser> users;
    private IList<ICategory> children;
    private ICategory parent;

    public string Name
    {
        get
        {
            return this.name;
        }

        private set
        {
            if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
            {
                throw new ArgumentException("Cannot create category without a name");
            }

            this.name = value;
        }
    }

    public IList<ICategory> Children => new List<ICategory>(this.children);

    public ICategory Parent
    {
        get
        {
            return this.parent;
        }

        private set
        {
            this.parent = value;
        }
    }

    public IList<IUser> Users
    {
        get
        {
            return new List<IUser>(this.users);
        }

        private set
        {
            this.users = value;
        }
    }

    public Category(string name)
    {
        this.Name = name;
        this.users = new List<IUser>();
        this.children = new List<ICategory>();
    }

    public void AddChild(ICategory child)
    {
        this.children.Add(child);
        child.SetParentCategory(this);
    }

    public void AddUser(IUser user)
    {
        this.users.Add(user);
        user.AddCategory(this);
    }

    public void MoveUsersToParentCategory()
    {
        if (this.Parent == null)
        {
            return;
        }

        foreach (var user in this.users)
        {
            this.Parent.AddUser(user);
        }
    }

    public void RemoveChildCategory(string categoryName)
    {
        var category = this.children.FirstOrDefault(c => c.Name == categoryName);
        this.children?.Remove(category);
    }

    public void SetParentCategory(ICategory category)
    {
        this.Parent = category;
    }
}
