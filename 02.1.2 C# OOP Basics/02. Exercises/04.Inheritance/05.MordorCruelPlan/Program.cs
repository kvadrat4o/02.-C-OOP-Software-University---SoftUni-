using System;

namespace _05.Mordor_sCruelPlan
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                Food fo = new Food();
                result += fo.GetPoints(input[i].ToLower());
            }
            Console.WriteLine(result);
            GetGandalfMood(result);
        }
        public static void GetGandalfMood(int result)
        {
            if (result < -5)
            {
                global::System.Console.WriteLine("Angry");
            }
            else if (result >= -5 && result <= 0)
            {
                global::System.Console.WriteLine("Sad");
            }
            else if (result <= 15 && result >= 1)
            {
                global::System.Console.WriteLine("Happy");
            }
            else
            {
                global::System.Console.WriteLine("JavaScript ");
            }
        }

    }
}
