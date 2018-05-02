using System;
using System.Collections.Generic;
using System.Text;

public class WeaponFactory : IFactory<IWeapon>
{
    public IWeapon CreateInstance<IWeapon>(params string[] data)
    {
        string weaponName = data[1];
        var typeOfT = Type.GetType(weaponName);
        var instance = (IWeapon)Activator.CreateInstance(typeOfT);
        return instance;
    }
}