using System;
using System.Collections.Generic;
using System.Text;

public interface ICategory
{
    string Name { get; }

    ICategory Parent { get; }

    IList<IUser> Users { get; }

    IList<ICategory> Children { get; }

    void AddChild(ICategory child);

    void MoveUsersToParentCategory();

    void RemoveChildCategory(string name);

    void AddUser(IUser user);

    void SetParentCategory(ICategory category);
}
