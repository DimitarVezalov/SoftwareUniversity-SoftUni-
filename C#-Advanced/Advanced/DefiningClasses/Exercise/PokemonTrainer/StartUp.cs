using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string command;
            while ((command = Console.ReadLine()) != "Tournament")
            {
                string[] cmdArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string trName = cmdArgs[0];
                string pokemonName = cmdArgs[1];
                string element = cmdArgs[2];
                int health = int.Parse(cmdArgs[3]);

                Pokemon pokemon = new Pokemon(pokemonName, element, health);

                Trainer trainer = CreateTrainer(trainers, trName);
                trainer.AddPokemon(pokemon);

                if (!trainers.Contains(trainer) && trainer != null)
                {
                    trainers.Add(trainer);
                }
            }


            string elementArg;
            while ((elementArg = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == elementArg))
                    {
                        trainer.BadgesCount++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }
                        
                        trainer.Pokemons = trainer.Pokemons.Where(p => p.Health > 0).ToList();
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(t => t.BadgesCount))
            {
                Console.WriteLine($"{trainer.Name} {trainer.BadgesCount} {trainer.Pokemons.Count}");
            }
        }

        private static Trainer CreateTrainer(List<Trainer> trainers, string trName)
        {
            Trainer trainer = null;

            if (trainers.Any(t => t.Name == trName))
            {
                trainer = trainers.FirstOrDefault(t => t.Name == trName);
            }
            else
            {
                trainer = new Trainer(trName);
            }

            return trainer;
        }
    }
}
