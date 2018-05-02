using System;

namespace _05.PizzaCalories3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var pizzaArgs = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries );
                var input = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
                string namePizza = pizzaArgs[1];
                Pizza pizaa = new Pizza(namePizza);
                string flour = input[1];
                string tech = input[2];
                double weightD = double.Parse(input[3]);
                Dough dough = new Dough(weightD, flour, tech);
                pizaa.Dough = dough;
                var inputTops = "";
                while ((inputTops = Console.ReadLine()) != "END")
                {
                    var inputToppings = inputTops.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string type = inputToppings[1];
                    double weightT = double.Parse(inputToppings[2]);
                    Topping top = new Topping(type, weightT);
                    pizaa.AddTopping(top);
                }
                Console.WriteLine(pizaa.ToString());
                
                //Console.WriteLine(dough.ToString());
                //Console.WriteLine(top.ToString());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
        }
    }
}
