using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Military_Elite
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ISoldier> soldiers = new List<ISoldier>();
            var input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split();
                switch (tokens[0])
                {
                    case "Private":
                        AddPrivate(tokens, soldiers);
                        break;
                    case "LeutenantGeneral":
                        AddLeutenantGeneral(tokens,soldiers);
                        break;
                    case "Engineer":
                        AddEngineer(tokens,soldiers);
                        break;
                    case "Commando":
                        AddComando(tokens,soldiers);
                        break;
                    case "Spy":
                        AddSpy(tokens, soldiers);
                        break;
                    default:
                        break;
                }
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private static void AddLeutenantGeneral(string[] tokens, List<ISoldier> soldiers)
        {
            LeutenantGeneral lg = new LeutenantGeneral(tokens[2], tokens[3], tokens[1], double.Parse(tokens[4]));
            for (int i = 5; i < tokens.Length; i++)
            {
                var priv = (Private)soldiers.First(a => a.Id == tokens[i]);
                lg.Privates.Add(priv);
            }
            soldiers.Add(lg);
        }

        private static void AddPrivate(string[] tokens, List<ISoldier> soldiers)
        {
            soldiers.Add(new Private(tokens[2], tokens[3], tokens[1], double.Parse(tokens[4])));
        }

        private static void AddEngineer(string[] tokens, List<ISoldier> soldiers)
        {
            Engineer eng = new Engineer(tokens[2], tokens[3], tokens[1], double.Parse(tokens[4]), tokens[5]);
            if (eng.Corps != null)
            {
                for (int i = 6; i < tokens.Length; i += 2)
                {
                    var repair = new Repair(tokens[i], int.Parse(tokens[i + 1]));
                    eng.Repairs.Add(repair);
                }
                soldiers.Add(eng);
            }
        }

        private static void AddComando(string[] tokens, List<ISoldier> soldiers)
        {
            Commando cmd = new Commando(tokens[2], tokens[3], tokens[1], double.Parse(tokens[4]), tokens[5]);
            
            if (cmd.Corps != null)
            {
                for (int i = 6; i < tokens.Length; i += 2)
                {
                    cmd.AddMission(new Mission(tokens[i], tokens[i + 1]));
                }
                soldiers.Add(cmd);
            }

        }

        private static void AddSpy(string[] tokens, List<ISoldier> soldiers)
        {
            soldiers.Add(new Spy(tokens[2], tokens[3], tokens[1], int.Parse(tokens[4])));

        }
    }
}
