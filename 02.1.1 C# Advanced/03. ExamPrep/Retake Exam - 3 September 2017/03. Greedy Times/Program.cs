using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Greedy_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());


            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var startIndex = FindStartIndex(input);

            Dictionary<string, Dictionary<string, long>> treasures = new Dictionary<string, Dictionary<string, long>>();
            treasures.Add("Gold", new Dictionary<string, long>());
            treasures["Gold"].Add("Gold", 0);
            treasures.Add("Gem", new Dictionary<string, long>());
            treasures.Add("Cash", new Dictionary<string, long>());
            long totalAmount = 0;
            long gemAmounts = 0;
            long cashAmounts = 0;
            for (int i = startIndex; i < input.Length; i += 2)
            {
                string item = input[i];
                long quantity = long.Parse(input[i + 1]);

                if (item.Equals("Gold", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (capacity >= treasures["Gold"]["Gold"] + quantity)
                    {
                        treasures["Gold"]["Gold"] += quantity;
                    }
                }
                else if (item.EndsWith("gem") || item.EndsWith("Gem") && item.Length >= 4)
                {
                    if (treasures["Gold"]["Gold"] >= gemAmounts + quantity && capacity >= totalAmount + quantity)
                    {
                        if (treasures["Gem"].ContainsKey(item))
                        {
                            treasures["Gem"][item] += quantity;
                        }
                        else
                        {
                            treasures["Gem"].Add(item, quantity);
                        }
                    }
                }
                else if (item.Length == 3 && AreAllCharsLetters(item))
                {
                    if (capacity >= totalAmount + quantity && gemAmounts >= cashAmounts + quantity)
                    {
                        if (treasures["Cash"].ContainsKey(item))
                        {
                            treasures["Cash"][item] += quantity;
                        }
                        else
                        {
                            treasures["Cash"].Add(item, quantity);
                        }
                    }
                }

                totalAmount = SumQuantities(treasures);
                gemAmounts = SumGems(treasures["Gem"]);
                cashAmounts = SumCash(treasures["Cash"]);
            }
            foreach (var kvp in treasures)
            {
                var treasure = kvp.Key;

                if (treasure == "Gold")
                {
                    if (treasures["Gold"]["Gold"] == 0)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"<{treasure}> ${treasures["Gold"]["Gold"]}");
                    }
                }
                else if (treasure == "Gem")
                {
                    if (gemAmounts == 0)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"<{treasure}> ${gemAmounts}");
                    }
                }
                else
                {
                    if (cashAmounts == 0)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"<{treasure}> ${cashAmounts}");
                    }
                }


                foreach (var quant in kvp.Value.OrderByDescending(a => a.Key).ThenBy(b => b.Value))
                {
                    Console.WriteLine($"##{quant.Key} - {quant.Value}");
                }
            }
        }

        private static int FindStartIndex(string[] input)
        {
            int startIndex = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == "Gold")
                {
                    startIndex = i;
                    break;
                }
            }
            return startIndex;
        }

        private static long SumCash(Dictionary<string, long> dictionary)
        {
            long result = 0;
            foreach (var cash in dictionary)
            {
                result += cash.Value;
            }
            return result;
        }

        private static long SumGems(Dictionary<string, long> dictionary)
        {
            long result = 0;
            foreach (var gem in dictionary)
            {
                result += gem.Value;
            }
            return result;
        }

        private static long SumQuantities(Dictionary<string, Dictionary<string, long>> treasures)
        {
            long result = 0;
            foreach (var item in treasures.Values)
            {
                foreach (var quantity in item.Values)
                {
                    result += quantity;
                }
            }
            return result;
        }

        private static bool AreAllCharsLetters(string item)
        {
            for (int i = 0; i < item.Length; i++)
            {
                if (!char.IsLetter(item[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
