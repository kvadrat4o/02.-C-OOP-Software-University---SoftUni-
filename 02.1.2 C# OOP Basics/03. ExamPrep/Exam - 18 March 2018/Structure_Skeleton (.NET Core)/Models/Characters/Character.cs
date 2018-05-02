using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Enums;
using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public abstract class Character : ICharacter
    {
        private string name;

        public string Name
        {
            get
            {
                return this.name;
            }

            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                this.name = value;
            }
        }

        public double BaseHealth { get; protected set; }

        public double Health { get; set; }

        public double BaseArmor { get; protected set; }

        public double Armor { get; set; }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; protected set; }

        public Faction Faction { get; private set; }

        public bool IsAlive { get; set; }

        public virtual double RestHealMultiplier { get; protected set; }

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.BaseArmor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
            this.RestHealMultiplier = 0.2;
            this.Health = this.BaseHealth;
            this.Armor = this.BaseArmor;
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException("Invalid Operation: Must be alive to perform this action!");

            }
            character.Bag.AddItem(item);
        }

        public void ReceiveItem(Item item)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Invalid Operation: Must be alive to perform this action!");

            }
            this.Bag.AddItem(item);
        }

        public void Rest()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Invalid Operation: Must be alive to perform this action!");
            }
            this.Health += (this.BaseHealth * this.RestHealMultiplier);
            if (this.Health > this.BaseHealth)
            {
                this.Health = this.BaseHealth;
            }
        }

        public void TakeDamage(double hitPoints)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Invalid Operation: Must be alive to perform this action!");

            }
            this.Armor -= hitPoints;
            double takenPoints = 0.0d;
            if (this.Armor>= hitPoints)
            {
                takenPoints = this.Armor - hitPoints;
            }
            else
            {
                takenPoints = hitPoints - this.Armor;
            }
            if (this.Armor < 0)
            {
                this.Armor = 0;
            }
            double hitPointsLeft = Math.Abs(hitPoints - takenPoints);
            if (this.Armor == 0 && hitPointsLeft > 0)
            //if(hitPoints > this.BaseArmor)
            {
                this.Health -= hitPointsLeft;
                if (this.Health <= 0)
                {
                    this.Health = 0;
                    this.IsAlive = false;
                }
            }
        }

        public void UseItem(Item item)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Invalid Operation: Must be alive to perform this action!");

            }
            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException("Invalid Operation: Must be alive to perform this action!");

            }
            item.AffectCharacter(character);
        }

        public override string ToString()
        {
            string status = this.IsAlive ? "Alive" : "Dead";
            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {status}";
        }
    }
}
