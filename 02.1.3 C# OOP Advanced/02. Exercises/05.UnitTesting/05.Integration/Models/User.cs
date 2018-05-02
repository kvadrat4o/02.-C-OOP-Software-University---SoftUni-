using System;
using System.Collections.Generic;
using System.Text;

public class User : IUser
{
    public string Name { get; private set; }

    public HashSet<ICategory> categories { get; private set; }

    public User(string name)
    {
        this.Name = name;
        this.categories = new HashSet<ICategory>();
    }

    public IEnumerable<ICategory> Categories => this.categories as IReadOnlyCollection<ICategory>;

    public void AddCategory(ICategory category) => this.categories.Add(category);

    public void RemoveCategory(ICategory category)
    {
        this.categories.RemoveWhere(c => c.Name == category.Name);

        if (category.Parent != null)
        {
            this.categories.Add(category.Parent);
        }
    }
}
