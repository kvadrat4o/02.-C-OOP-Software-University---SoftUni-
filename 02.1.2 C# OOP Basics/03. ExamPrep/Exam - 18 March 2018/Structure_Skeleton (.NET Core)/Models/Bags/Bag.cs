using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public abstract class Bag : IBag
    {
        private List<Item> items;

        public Bag(int capacity)
        {
            this.items = new List<Item>();
            Capacity = capacity;
        }

        public int Capacity { get; }

        public int Load { get; }

        public IReadOnlyCollection<Item> Items { get { return this.items.AsReadOnly(); } }

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!this.Items.Any())
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            if (!this.Items.Any(i => i.GetType().ToString() == name))
            {
                throw new ArgumentException($"Parameter Error: No item with name {name} in bag!");
            }
            Item item = (Item)this.Items.FirstOrDefault(i => i.GetType().ToString() == name);
            return item;
        }
    }
}
