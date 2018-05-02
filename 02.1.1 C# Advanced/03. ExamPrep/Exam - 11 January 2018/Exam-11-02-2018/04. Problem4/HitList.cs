using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _04HitList
{
    class HitList
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, Dictionary<string,int>>> killOrder = new Dictionary<string, Dictionary<string, Dictionary<string,int>>>();
            int targetInfo = int.Parse(Console.ReadLine());
            var propName = "";
            var propValue = "";
            int infoIndex = 0;
            int currIndexInfo = 0;
            var input = Console.ReadLine();
            while (true)
            {
                if (input.Contains("Kill"))
                {
                    var intermed = input.Split(new char[] { ' ' });
                    var name = intermed[1];
                    foreach (var person in killOrder.Where(p => p.Key == name))
                    {
                        Console.WriteLine($"Info on {person.Key}:");
                        foreach (var item in person.Value.OrderBy(a => a.Key))
                        {
                            Console.WriteLine($"---{item.Key}: {item.Value}");
                        }
                        Console.WriteLine($"Info index: {infoIndex}");
                        if (infoIndex >= targetInfo)
                        {
                            Console.WriteLine($"Proceed");
                        }
                        else
                        {
                            Console.WriteLine($"Need {targetInfo - infoIndex} more info.");
                        }
                    }
                    break;
                }
                else
                {
                    while (input != "end transmissions")
                    {
                        var tokens = input.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                        var name = tokens[0];
                        var props = tokens[1];
                        if (tokens[1].Contains(';'))
                        {
                            var interm = props
                                .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                            for (int i = 0; i <= interm.Length - 1; i++)
                            {
                                var properties = interm[i].Split(new char[] { ':' });

                                propName = properties[0];
                                propValue = properties[1];

                                if (!killOrder.ContainsKey(name))
                                {
                                    killOrder[name] = new Dictionary<string, Dictionary<string,int>>();
                                }

                                if (!killOrder[name].ContainsKey(propName))
                                {
                                    killOrder[name].Add(propName, new Dictionary<string, int>());
                                    //if (killOrder[name][propName].ContainsKey(propValue))
                                    //{

                                    //}
                                    killOrder[name][propName][propValue] += propName.Length + propValue.Length;
                                }
                                else
                                {
                                    killOrder[name][propName][propValue] += propName.Length + propValue.Length;
                                    killOrder[name][propName] = new Dictionary<string, int>();
                                }
                            }
                        }
                        else
                        {
                            var properties = props
                                .Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                            propName = properties[0];
                            propValue = properties[1];

                            if (!killOrder.ContainsKey(name))
                            {
                                killOrder[name] = new Dictionary<string, Dictionary<string,int>>();
                            }
                            if (!killOrder[name].ContainsKey(propName))
                            {
                                killOrder[name].Add(propName, new Dictionary<string, int>());
                                killOrder[name][propName][propValue] += propName.Length + propValue.Length;
                            }
                            else
                            {
                                killOrder[name][propName] = new Dictionary<string, int>();
                                killOrder[name][propName][propValue] += propName.Length + propValue.Length;
                            }
                        }
                        input = Console.ReadLine();
                    }
                    input = Console.ReadLine();
                }
            }
        }
    }
}
