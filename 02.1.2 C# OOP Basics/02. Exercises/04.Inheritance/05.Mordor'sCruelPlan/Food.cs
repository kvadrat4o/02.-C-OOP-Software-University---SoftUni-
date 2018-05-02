using System;
using System.Collections.Generic;
using System.Text;

public class Food
{
    private Dictionary<string,int> foods;

    public Dictionary<string,int> Foods
    {
        get { return foods; }
        set { foods = value; }
    }

    public Food()
    {
        this.Foods = new Dictionary<string, int>() { {"Cream",2 }, {"Lembas",3 }, {"Apple",1 }, {"Melon",1 }, {"HoneyCake",5 }, { "Mushrooms", -10} };
    }

    public int GetPoints(string name)
    {
        int result = 0;
        switch (foods[name])
        {
            case "Cream":
                result += foods["Cream"];
                break;
            case "Lembas":
                result += foods["Lembas"];
                break;
            case "Apple":
                result += foods["Apple"];
                break;
            case "Melon":
                result += foods["Melon"];
                break;
            case "HoneyCake":
                result += foods["HoneyCake"];
                break;
            case "Mushrooms":
                result += foods["Mushrooms"];
                break;
            default:
                result += -1;
                break;
        }
        return result;
    }

    

}
