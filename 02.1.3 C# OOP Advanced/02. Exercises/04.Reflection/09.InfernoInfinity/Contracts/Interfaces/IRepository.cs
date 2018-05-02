using System;
using System.Collections.Generic;
using System.Text;

public interface IRepository
{
    void AddWeapon(IWeapon weapon);

    string Statistics { get; }

    IList<IWeapon> Weapons { get; }

    void RemoveWeapon(string weaponType);
}
