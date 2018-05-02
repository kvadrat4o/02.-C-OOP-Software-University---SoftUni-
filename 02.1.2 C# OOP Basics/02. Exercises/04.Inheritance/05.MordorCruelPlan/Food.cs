using System;
using System.Collections.Generic;
using System.Text;

public class Food
{
    private Dictionary<string, int> foods;

    public Dictionary<string, int> Foods
    {
        get { return foods; }
        set { foods = value; }
    }

    public Food()
    {
        this.Foods = new Dictionary<string, int>() { { "cram", 2 }, { "lembas", 3 }, { "apple", 1 }, { "melon", 1 }, { "honeycake", 5 }, { "mushrooms", -10 } };
    }

    public int GetPoints(string name)
    {
        int result = 0;
        switch (name)
        {
            case "cram":
                result += foods["cram"];
                break;
            case "lembas":
                result += foods["lembas"];
                break;
            case "apple":
                result += foods["apple"];
                break;
            case "melon":
                result += foods["melon"];
                break;
            case "honeycake":
                result += foods["honeycake"];
                break;
            case "mushrooms":
                result += foods["mushrooms"];
                break;
            default:
                result += -1;
                break;
        }
        return result;
    }



}
