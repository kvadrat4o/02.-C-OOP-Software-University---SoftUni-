using System.Collections.Generic;

public interface IManager
{
    string Quit(IList<string> arguments);

    string Inspect(List<string> arguments);

    string AddItemToHero(List<string> arguments);

    string AddHero(List<string> arguments);

    string AddRecipeToHero(List<string> arguments);

    Dictionary<string, IHero> Heroes { get; }

}