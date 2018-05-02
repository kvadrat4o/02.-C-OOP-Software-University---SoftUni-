using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        public void Run()
        {
            DungeonMaster dm = new DungeonMaster();
            var input = "";
            while (true)
            {
                input = Console.ReadLine();
                if (String.IsNullOrEmpty(input))
                {
                    break;
                }
                if (dm.IsGameOver())
                {
                    break;
                }
                var inputTokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string commandName = inputTokens[0];
                inputTokens = inputTokens.Skip(1).ToArray();
                try
                {
                    switch (commandName)
                    {
                        case "JoinParty":
                            Console.WriteLine(dm.JoinParty(inputTokens));
                            break;
                        case "AddItemToPool":
                            Console.WriteLine(dm.AddItemToPool(inputTokens));
                            break;
                        case "PickUpItem":
                            Console.WriteLine(dm.PickUpItem(inputTokens));
                            break;
                        case "UseItem":
                            Console.WriteLine(dm.UseItem(inputTokens));
                            break;
                        case "UseItemOn":
                            Console.WriteLine(dm.UseItemOn(inputTokens));
                            break;
                        case "GiveCharacterItem":
                            Console.WriteLine(dm.GiveCharacterItem(inputTokens));
                            break;
                        case "GetStats":
                            Console.WriteLine(dm.GetStats());
                            break;
                        case "Attack":
                            Console.WriteLine(dm.Attack(inputTokens));
                            break;
                        case "Heal":
                            Console.WriteLine(dm.Heal(inputTokens));
                            break;
                        case "EndTurn":
                            Console.WriteLine(dm.EndTurn(inputTokens));
                            break;
                        case "IsGameOver":
                            Console.WriteLine(dm.IsGameOver());
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                //input = Console.ReadLine();
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Final stats:");
            sb.AppendLine(dm.GetStats());
            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
