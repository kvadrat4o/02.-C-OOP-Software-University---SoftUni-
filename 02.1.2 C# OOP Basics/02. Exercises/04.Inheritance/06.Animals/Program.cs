using System;

namespace _06.Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "";
            while ((input = Console.ReadLine()) != "Beast!")
            {
                try
                {

                    var type = input;
                    var animalArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (type == "Cat")
                    {
                        Cat cat = new Cat(animalArgs[2], int.Parse(animalArgs[1]), animalArgs[0]);
                        Console.WriteLine(cat);
                        cat.ProduceSound();
                    }
                    else if (type == "Dog")
                    {
                        Dog dog = new Dog(animalArgs[2], int.Parse(animalArgs[1]), animalArgs[0]);
                        Console.WriteLine(dog);
                        dog.ProduceSound();
                    }
                    else if (type == "Frog")
                    {
                        Frog frog = new Frog(animalArgs[2], int.Parse(animalArgs[1]), animalArgs[0]);
                        Console.WriteLine(frog);
                        frog.ProduceSound();
                    }
                    else if (type == "Tomcat")
                    {
                        Tomcat cat = new Tomcat(int.Parse(animalArgs[1]), animalArgs[0]);
                        Console.WriteLine(cat);
                        cat.ProduceSound();
                    }
                    else if (type == "Kitten")
                    {
                        Kitten cat = new Kitten(int.Parse(animalArgs[1]), animalArgs[0]);
                        Console.WriteLine(cat);
                        cat.ProduceSound();
                    }
                    else
                    {
                        throw new ArgumentException("Invalid input!");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
