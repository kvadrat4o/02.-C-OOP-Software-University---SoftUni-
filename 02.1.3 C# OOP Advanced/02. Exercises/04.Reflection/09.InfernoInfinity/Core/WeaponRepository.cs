using System;
using System.Collections.Generic;
using System.Text;

public class WeaponRepository : IRepository
{
    public string Statistics
    {
        get
        {
            StringBuilder sb = new StringBuilder();
            foreach (var weapon in this.Weapons)
            {
                sb.Append(weapon);
                foreach (var gem in weapon.sockets.Values)
                {
                    sb.Append(gem);
                }
            }

            return sb.ToString().Trim();
        }
            
    }

    public IList<IWeapon> Weapons { get; set; }

    public WeaponRepository()
    {
        this.Weapons = new List<IWeapon>();
    }

    public void AddWeapon(IWeapon weapon)
    {
        this.Weapons.Add(weapon);
    }

    public void RemoveWeapon(string weaponType)
    {
        throw new NotImplementedException();
    }
}
