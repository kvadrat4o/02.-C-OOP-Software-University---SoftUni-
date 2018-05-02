using System;

namespace P10_Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            var fullNameAndAddress = Console.ReadLine().Split();
            var nameAndBeer = Console.ReadLine().Split();
            var intAndDouble = Console.ReadLine().Split();

            var tupleFullNameAndAddress = new Tuple<string, string>(fullNameAndAddress[0] + " " + fullNameAndAddress[1], fullNameAndAddress[2]);
            var tupleNameAndBeer = new Tuple<string, int>(nameAndBeer[0], int.Parse(nameAndBeer[1]));
            var tupleIntAndDouble = new Tuple<int, double>(int.Parse(intAndDouble[0]), double.Parse(intAndDouble[1]));

            Console.WriteLine(tupleFullNameAndAddress);
            Console.WriteLine(tupleNameAndBeer);
            Console.WriteLine(tupleIntAndDouble);
        }
    }
}
