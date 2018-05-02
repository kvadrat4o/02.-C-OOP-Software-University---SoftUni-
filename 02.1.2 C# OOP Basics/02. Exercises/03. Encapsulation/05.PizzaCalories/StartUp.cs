using System;

namespace _05.PizzaCalories
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string pName = input[1];
            try
            {
                Pizza pizza = new Pizza(pName);
                var tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                DoughType dType = (DoughType)Enum.Parse(typeof(DoughType), tokens[1]);
                BakingTechnique bTechnique = (BakingTechnique)Enum.Parse(typeof(BakingTechnique), tokens[2]);
                double weight = double.Parse(tokens[3]);
                try
                {
                    Dough dough = new Dough(weight, bTechnique, dType);
                    pizza.Dough = dough;
                    string tops = "";
                    while ((tops = Console.ReadLine()) != "END")
                    {
                        var splittedtops = tops.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        string tName = splittedtops[1];
                        double tWeight = double.Parse(splittedtops[2]);
                        try
                        {
                            Topping top = new Topping(tName, weight);
                            pizza.Toppings.Add(top);
                            pizza.CalculateCalories();
                            Console.WriteLine(pizza.ToString());
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Environment.Exit(0);
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
            
            

        }
    }
}
