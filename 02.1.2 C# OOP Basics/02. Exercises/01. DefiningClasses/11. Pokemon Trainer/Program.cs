using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Pokemon_Trainer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<string, List<Pokemon>> pokeData = new Dictionary<string, List<Pokemon>>();
            List<Trainer> pokeData = new List<Trainer>();
            var input = "";
            while ((input = Console.ReadLine()) != "Tournament")
            {
                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Pokemon poke = new Pokemon() { Name = tokens[1], Element = tokens[2], Health = int.Parse(tokens[3]) };
                if (!pokeData.Any(а => а.Name == tokens[0]))
                {
                    pokeData.Add(new Trainer() { Name = tokens[0], NumBadges = 0, Pokemons = new List<Pokemon>() { poke } });
                }
                else
                {
                    pokeData.Where(a => a.Name == tokens[0]).First().Pokemons.Add(poke);
                }
            }
            var command = "";
            while ((command = Console.ReadLine()) != "End")
            {
                foreach (var trainer in pokeData)
                {
                    if (trainer.Pokemons.Any(a => a.Element == command))
                    {
                        trainer.NumBadges += 1;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(a => a.Health -= 10);
                        if (trainer.Pokemons.Any(a => a.Health <= 0))
                        {
                            //var poke = trainer.Pokemons.Where(x => x.Health <= 0).ToList();
                            for (int i = trainer.Pokemons.Count - 1; i >= 0; i--)
                            {
                                if (trainer.Pokemons[i].Health <= 0)
                                {
                                    trainer.Pokemons.RemoveAt(i);
                                }

                            }
                        }
                    }
                }
            }

            foreach (var trainer in pokeData.OrderByDescending(a => a.NumBadges))
            {
                Console.WriteLine(trainer.ToString());
            }
        }
    }
}
