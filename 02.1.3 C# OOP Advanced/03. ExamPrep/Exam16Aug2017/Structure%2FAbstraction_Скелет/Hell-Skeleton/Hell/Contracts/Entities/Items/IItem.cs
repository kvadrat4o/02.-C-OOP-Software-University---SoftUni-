using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IItem : IEntity
{
	int StrengthBonus { get; }

	int AgilityBonus { get; }

	int IntelligenceBonus { get; }

	int HitPointsBonus { get; }

	int DamageBonus { get; }

    //string Name { get; }

}
