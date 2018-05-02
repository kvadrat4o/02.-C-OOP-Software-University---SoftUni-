using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Enums;
using DungeonsAndCodeWizards.Models.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory : ICharacterFactory
    {
        public Character CreateCharacter(string characterFaction, string characterType, string characterName)
        {
            
            if (characterType != "Cleric" && characterType != "Warrior")
            {
                throw new ArgumentException($"Parameter Error: Invalid character type \"{ characterType }\"!");
            }

            if (characterFaction != "CSharp" && characterFaction != "Java")
            {
                throw new ArgumentException($"Parameter Error: Invalid faction \"{characterFaction}\"!");
            }
            Type typeOfCharacter = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == characterType);
            Faction charFaction = (Faction)Enum.Parse(typeof(Faction), characterFaction);
            Character instance = (Character)Activator.CreateInstance(typeOfCharacter, new object[] { characterName, charFaction});
            return instance;
        }
    }
}
