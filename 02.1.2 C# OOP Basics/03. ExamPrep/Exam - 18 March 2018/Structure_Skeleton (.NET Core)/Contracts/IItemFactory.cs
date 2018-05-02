using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Contracts
{
    public interface IItemFactory
    {
        Item CreateItem(string itemName);
    }
}
