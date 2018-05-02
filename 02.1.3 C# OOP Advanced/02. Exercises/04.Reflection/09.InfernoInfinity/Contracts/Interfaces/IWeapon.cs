using System;
using System.Collections.Generic;
using System.Text;

public interface IWeapon
{
    string Name { get; }

    IDictionary<int, Gem> sockets { get; }

    void ChangeWeaponStats();
}
