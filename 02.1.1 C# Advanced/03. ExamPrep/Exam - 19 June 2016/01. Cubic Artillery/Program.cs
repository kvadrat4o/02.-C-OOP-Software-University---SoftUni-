using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Cubic_Artillery
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            var bunkers = new Queue<char>();
            var weapons = new Queue<int>();
            int freeCapacity = capacity;
            string input;
            while ((input = Console.ReadLine()) != "Bunker Revision")
            {
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < tokens.Length; i++)
                {
                    int weapon = 0;
                    if (int.TryParse(tokens[i], out weapon))
                    {
                        bool weaponContained = false;
                        while (bunkers.Count > 1)
                        {
                            if (freeCapacity >= weapon)
                            {
                                weapons.Enqueue(weapon);
                                freeCapacity -= weapon;
                                weaponContained = true;
                                break;
                            }
                            if (weapons.Count == 0)
                            {
                                Console.WriteLine($"{bunkers.Peek()} -> Empty");
                            }
                            else
                            {
                                Console.WriteLine($"{bunkers.Peek()} -> {string.Join(", ", weapons)}");
                            }
                            bunkers.Dequeue();
                            weapons.Clear();
                            freeCapacity = capacity;
                        }
                        if (!weaponContained && bunkers.Count == 1)
                        {
                            if (capacity >= weapon)
                            {
                                if (freeCapacity < weapon)
                                {
                                    while (freeCapacity < weapon)
                                    {
                                        int removedWeapon = weapons.Dequeue();
                                        freeCapacity += removedWeapon;
                                    }
                                }
                                weapons.Enqueue(weapon);
                                freeCapacity -= weapon;
                            }

                        }
                    }
                    else
                    {
                        bunkers.Enqueue(char.Parse(tokens[i]));
                    }
                }
            }
        }
    }
}
