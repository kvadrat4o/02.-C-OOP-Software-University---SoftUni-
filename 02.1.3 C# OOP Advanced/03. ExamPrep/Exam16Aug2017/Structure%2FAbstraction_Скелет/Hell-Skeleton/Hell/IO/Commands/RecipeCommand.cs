using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RecipeCommand : AbstractCommand
{
    public RecipeCommand(List<string> arguments, IManager heroManager) : base(arguments, heroManager)
    {
    }

    public override string Execute()
    {
        return base.heroManager.AddRecipeToHero(arguments);
    }
}
