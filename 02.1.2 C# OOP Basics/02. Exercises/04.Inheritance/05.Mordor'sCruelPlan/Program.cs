using System;

namespace _05.Mordor_sCruelPlan
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = console.ReadLine().Split(new char[] { ' ' },StrinSplitOptions.RemoveEmptyEntries);
            int result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                Food fo = new Food();
                result += fo.GetPoints();
            }
            GetGandalfMood(result);
        }
        public string GetGandalfMood(int result)
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
            else if (result > 15)
            {
                global::System.Console.WriteLine("JavaScript ");
            }
        }

    }
}
