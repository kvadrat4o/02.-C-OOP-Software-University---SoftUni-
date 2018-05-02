using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Factories;
using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private IList<Item> itemPool;

        private IList<Character> characterParty;

        private int lastSurvivorConsecRounds;

        private ICharacterFactory characterFactory;

        private IItemFactory itemFactory;

        public DungeonMaster()
        {
            this.itemPool = new List<Item>();
            this.characterParty = new List<Character>();

            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();

            this.lastSurvivorConsecRounds = 0;
        }

        public string JoinParty(string[] args)
        {
            string characterName = args[2];
            string characterType = args[1];
            string characterFaction = args[0];
            Character character = this.characterFactory.CreateCharacter(characterFaction, characterType, characterName);
            string result = $"{characterName} joined the party!";
            this.characterParty.Add(character);
            return result;
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item item = this.itemFactory.CreateItem(itemName);
            string result = $"{itemName} added to pool.";
            this.itemPool.Add(item);
            return result;
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            if (!this.characterParty.Any(ch => ch.Name == characterName))
            {
                throw new ArgumentException($"Parameter Error: Character {characterName} not found!");
            }
            if (!this.itemPool.Any())
            {
                throw new InvalidOperationException("Invalid Operation: No items left in pool!");
            }
            Item item = this.itemPool.Last();
            this.itemPool.Remove(item);
            Character character = characterParty.SingleOrDefault(ch => ch.Name == characterName);
            character.Bag.AddItem(item);
            string result = $"{characterName} picked up {item.GetType().Name}!";
            return result;
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];
            if (!this.characterParty.Any(ch => ch.Name == characterName))
            {
                throw new ArgumentException($"Parameter Error: Character {characterName} not found!");
            }
            Character character = characterParty.SingleOrDefault(ch => ch.Name == characterName);
            if (character.Bag.Items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation: Bag is empty!");
            }
            if (!character.Bag.Items.Any(i => i.GetType().Name == itemName))
            {
                throw new InvalidOperationException($"Parameter Error: No item with name {itemName} in bag!");
            }
            Item item = character.Bag.Items.First(i => i.GetType().Name == itemName);
            character.UseItem(item);
            string result = $"{character.Name} used {itemName}.";
            return result;
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string recieverName = args[1];
            string itemName = args[2];
            if (!this.characterParty.Any(ch => ch.Name == giverName))
            {
                throw new ArgumentException($"Parameter Error: Character {giverName} not found!");
            }
            if (!this.characterParty.Any(ch => ch.Name == recieverName))
            {
                throw new ArgumentException($"Parameter Error: Character {recieverName} not found!");
            }
            Character giver = characterParty.SingleOrDefault(ch => ch.Name == giverName);
            Character reciever = characterParty.SingleOrDefault(ch => ch.Name == recieverName);
            if (giver.Bag.Items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation: Bag is empty!");
            }

            Item item = giver.Bag.Items.First(i => i.GetType().Name == itemName);
            giver.UseItemOn(item, reciever);
            string result = $"{giver.Name} used {itemName} on {reciever.Name}.";
            return result;
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string recieverName = args[1];
            string itemName = args[2];
            if (!this.characterParty.Any(ch => ch.Name == giverName))
            {
                throw new ArgumentException($"Parameter Error: Character {giverName} not found!");
            }
            if (!this.characterParty.Any(ch => ch.Name == recieverName))
            {
                throw new ArgumentException($"Parameter Error: Character {recieverName} not found!");
            }
            Character giver = characterParty.SingleOrDefault(ch => ch.Name == giverName);
            Character reciever = characterParty.SingleOrDefault(ch => ch.Name == recieverName);
            if (giver.Bag.Items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation: Bag is empty!");

            }
            if (!giver.Bag.Items.Any(i => i.GetType().Name == itemName))
            {
                throw new InvalidOperationException($"Parameter Error: No item with name {itemName} in bag!");
            }
            Item item = giver.Bag.Items.Last();
            giver.GiveCharacterItem(item, reciever);
            string result = $"{giver.Name} gave {reciever.Name} {itemName}.";
            return result;
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var character in this.characterParty.OrderByDescending(ch => ch.IsAlive).ThenByDescending(c => c.Health))
            {
                sb.AppendLine(character.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            StringBuilder result = new StringBuilder();
            string attackerName = args[0];
            string recieverName = args[1];
            if (!this.characterParty.Any(ch => ch.Name == attackerName))
            {
                throw new ArgumentException($"Parameter Error: Character {attackerName} not found!");
            }
            if (!this.characterParty.Any(ch => ch.Name == recieverName))
            {
                throw new ArgumentException($"Parameter Error: Character {recieverName} not found!");
            }
            Warrior attacker = (Warrior)characterParty.SingleOrDefault(ch => ch.Name == attackerName);
            Character reciever = characterParty.SingleOrDefault(ch => ch.Name == recieverName);
            if (attacker.GetType() != typeof(Warrior))
            {
                throw new ArgumentException($"Invalid Operation: {attacker.Name} cannot attack!");
            }
            attacker.Attack(reciever);
            result.AppendLine($"{attacker.Name} attacks {reciever.Name} for {attacker.AbilityPoints} hit points! {reciever.Name} has {reciever.Health}/{reciever.BaseHealth} HP and {reciever.Armor}/{reciever.BaseArmor} AP left!");
            
            if (!reciever.IsAlive)
            {
                result.AppendLine($"{reciever.Name} is dead!");
            }
            return result.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            StringBuilder result = new StringBuilder();
            string healerName = args[0];
            string recieverName = args[1];
            if (!this.characterParty.Any(ch => ch.Name == healerName))
            {
                throw new ArgumentException($"Parameter Error: Character {healerName} not found!");
            }
            if (!this.characterParty.Any(ch => ch.Name == recieverName))
            {
                throw new ArgumentException($"Parameter Error: Character {recieverName} not found!");
            }
            Cleric healer = (Cleric)characterParty.SingleOrDefault(ch => ch.Name == healerName);
            if (healer.GetType() != typeof(Cleric))
            {
                throw new ArgumentException($"{healer.Name} cannot heal!");
            }
            Character reciever = characterParty.SingleOrDefault(ch => ch.Name == recieverName);
            healer.Heal(reciever);
            result.AppendLine($"{healer.Name} heals {reciever.Name} for {healer.AbilityPoints}! {reciever.Name} has {reciever.Health} health now!");
            return result.ToString().TrimEnd();
        }

        public string EndTurn(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var character in this.characterParty.Where(c => c.IsAlive == true))
            {
                double healthBeforeRest = character.Health;
                character.Rest();
                sb.AppendLine($"{character.Name} rests ({healthBeforeRest} => {character.Health})");
            }
            if (this.characterParty.Where(c => c.IsAlive).Count() == 1 || this.characterParty.Where(c => c.IsAlive).Count() == 0)
            {
                this.lastSurvivorConsecRounds++;
                if (this.lastSurvivorConsecRounds > 1)
                {
                    this.IsGameOver();
                }
            }
            return sb.ToString().TrimEnd();
        }

        public bool IsGameOver()
        {
            if (this.characterParty.Where(c => c.IsAlive).Count() == 1 && this.lastSurvivorConsecRounds > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
