using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IHero : IEntity
{
    ICollection<IItem> Items { get; }

    long Strength { get; }

    long Agility { get; }

    long Intelligence { get; }

    long HitPoints { get; }

    long Damage { get; }

    //IInventory Inventory { get; }

    void AddRecipe(IRecipe recipe);

    void AddItem(IItem recipe);
}