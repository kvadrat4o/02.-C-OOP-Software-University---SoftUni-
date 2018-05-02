using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class HeroManager : IManager
{
    public Dictionary<string, IHero> heroes;

    public Dictionary<string, IHero> Heroes { get; }

    public HeroManager()
    {
        this.Heroes = new Dictionary<string, IHero>();
    }

    public string AddHero(List<string> arguments)
    {
        string result = null;

        string heroName = arguments[0];
        string heroType = arguments[1];

        try
        {
            Type clazz = Type.GetType(heroType);
            var constructors = clazz.GetConstructors();
            IHero hero = (IHero) constructors[0].Invoke(new object[] {heroName});
            this.Heroes.Add(heroName, hero);

            result = string.Format(Constants.HeroCreateMessage,heroType,hero.Name);
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return result;
    }

    public string AddItemToHero(List<string> arguments)
    {
        string result = null;


        string itemName = arguments[0];
        string heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);

        IItem newItem = new CommonItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus,
            damageBonus);
        this.Heroes[heroName].AddItem(newItem);
        result = string.Format(Constants.ItemCreateMessage, newItem.Name, heroName);
        return result;
    }

    public string AddRecipeToHero(List<string> arguments)
    {
        string result = null;


        string itemName = arguments[0];
        string heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);
        List<string> requiredItems = arguments.Skip(7).ToList();
        IRecipe newItem = new RecipeItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus,
            damageBonus,requiredItems);
        this.Heroes[heroName].AddRecipe(newItem);
        result = string.Format(Constants.RecipeCreatedMessage, newItem.Name, heroName);
        return result;
    }

    //public string CreateGame()
    //{
    //    StringBuilder result = new StringBuilder();

    //    foreach (var hero in heroes)
    //    {
    //        result.AppendLine(hero.Key);
    //    }

    //    return result.ToString();
    //}

    public string Inspect(List<string> arguments)
    {
        string heroName = arguments[0];

        return this.Heroes[heroName].ToString();
    }
    
    public string Quit(IList<string> arguments)
    {
        StringBuilder sb = new StringBuilder();
        int counter = 1;
        foreach (var hero in this.Heroes.Values.OrderByDescending(h => h.Agility + h.Strength + h.Intelligence).ThenByDescending(he => he.HitPoints + he.Damage))
        {
            sb.AppendLine($"{counter++}. {hero.GetType().Name}: {hero.Name}");
            sb.AppendLine($"###HitPoints: {hero.HitPoints}");
            sb.AppendLine($"###Damage: {hero.Damage}");
            sb.AppendLine($"###Strength: {hero.Strength}");
            sb.AppendLine($"###Agility: {hero.Agility}");
            sb.AppendLine($"###Intelligence: {hero.Intelligence}");
            if (hero.Items.Count == 0)
            {
                sb.AppendLine("###Items: None");
            }
            else
            {
                sb.AppendLine($"###Items: {string.Join(", ", hero.Items.Select(i => i.Name))}");
            }
        }
        return sb.ToString().TrimEnd();
    }

    //Само Батман знае как работи това
    //public static void GenerateResult()
    //{
    //    const string PropName = "_connectionString";

    //    var type = typeof(HeroCommand);

    //    FieldInfo fieldInfo = null;
    //    PropertyInfo propertyInfo = null;
    //    while (fieldInfo == null && propertyInfo == null && type != null)
    //    {
    //        fieldInfo = type.GetField(PropName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    //        if (fieldInfo == null)
    //        {
    //            propertyInfo = type.GetProperty(PropName,
    //                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    //        }

    //        type = type.BaseType;
    //    }
    //}

    //public static void DontTouchThisMethod()
    //{
    //    //това не трябва да го пипаме, че ако го махнем ще ни счупи цялата логика
    //    var l = new List<string>();
    //    var m = new HeroManager();
    //    HeroCommand cmd = new HeroCommand(l, m);
    //    var str = "Execute";
    //    Console.WriteLine(str);
    //}


}