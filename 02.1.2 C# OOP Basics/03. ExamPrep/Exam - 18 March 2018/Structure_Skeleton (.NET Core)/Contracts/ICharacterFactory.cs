using DungeonsAndCodeWizards.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Contracts
{
    public interface ICharacterFactory
    {
        Character CreateCharacter(string characterFaction, string characterType, string characterName);
    }
}
