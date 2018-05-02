using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory : IItemFactory
    {
        public Item CreateItem(string itemName)
        {
            Type typeOfItem = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == itemName);
            if (typeOfItem != typeof(PoisonPotion) && typeOfItem != typeof(HealthPotion) && typeOfItem != typeof(ArmorRepairKit))
            {
                throw new ArgumentException($"Parameter Error: Invalid item \"{ itemName }\"!");
            }
            Item instance = (Item)Activator.CreateInstance(typeOfItem);
            return instance;
        }
    }
}
