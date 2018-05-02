using System;

namespace P11_Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            var fullNameAndAddress = Console.ReadLine().Split();
            var nameAndBeer = Console.ReadLine().Split();
            var intAndDouble = Console.ReadLine().Split();

            var tupleFullNameAndAddress = new Threeuple<string, string, string>(fullNameAndAddress[0] + " " + fullNameAndAddress[1], fullNameAndAddress[2], fullNameAndAddress[3]);
            var tupleNameAndBeer = new Threeuple<string, int, bool>(nameAndBeer[0], int.Parse(nameAndBeer[1]), nameAndBeer[2] == "drunk" ? true : false);
            var tupleIntAndDouble = new Threeuple<string, double, string>(intAndDouble[0], double.Parse(intAndDouble[1]), intAndDouble[2]);

            Console.WriteLine(tupleFullNameAndAddress);
            Console.WriteLine(tupleNameAndBeer);
            Console.WriteLine(tupleIntAndDouble);
        }
    }
}
