using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Dictionary<string, int> people = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                var person = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                people[person[0]] = int.Parse(person[1]);
            }
            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();
            Func<int, bool> smug = CreateSmug(condition, age);
            Action<KeyValuePair<string, int>> wabamama = CreatePrinter(format);
            Print(people, smug, wabamama);
        }

        private static void Print(Dictionary<string, int> people, Func<int, bool> smug, Action<KeyValuePair<string, int>> wabamama)
        {
            foreach (var person in people)
            {
                if (smug(person.Value))
                {
                    wabamama(person);
                }
            }
        }

        private static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name": return m => Console.WriteLine($"{m.Key}");
                case "name age": return m => Console.WriteLine($"{m.Key} - {m.Value}");
                case "age": return m => Console.WriteLine($"{m.Value}");
                default: return null;
            }
        }

        private static Func<int, bool> CreateSmug(string condition, int age)
        {
            switch (condition)
            {
                case "younger": return x => x < age;
                case "older": return x => x >= age;
                default: return null;
            }
        }
    }
}
