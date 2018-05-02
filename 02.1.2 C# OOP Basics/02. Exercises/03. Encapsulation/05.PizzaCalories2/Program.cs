using System;

namespace _05.PizzaCalories2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var pizzaArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var tokensArgs = "";
                var tokens = new string[10];
                string pizzaName = pizzaArgs[1];
                Pizza pizza = new Pizza(pizzaName);
                while ((tokensArgs = Console.ReadLine()) != "END")
                {
                    tokens = tokensArgs.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    
                    BakingTechnique ba = (BakingTechnique)Enum.Parse(typeof(BakingTechnique), input[2]);
                    FlourType fl = (FlourType)Enum.Parse(typeof(FlourType), input[1]);
                    double weight = double.Parse(input[3]);
                    Dough dough = new Dough(weight, ba, fl);
                    double weightT = double.Parse(tokens[2]);
                    object tp;
                    Toppingtype tpo = Toppingtype.Cheese;
                    try
                    {
                        Enum.TryParse(typeof(Toppingtype), tokens[1], out tp);
                        if (Enum.TryParse(typeof(Toppingtype), tokens[1], out tp))
                        {
                            tpo = (Toppingtype)Enum.Parse(typeof(Toppingtype), tokens[1]);
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Environment.Exit(0);
                    }
                    
                    Topping top = new Topping(weightT, tpo);
                    pizza.Dough = dough;
                    pizza.AddTopping(top);
                }
                Console.WriteLine(pizza.ToString());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
        }
    }
}
