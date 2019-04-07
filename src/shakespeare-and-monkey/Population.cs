using System;
using System.Collections.Generic;
using System.Linq;

namespace ShakespeareAndMonkey
{
    /*
    population: a collection of individuals
        * initialize them
        * randomize them
        ...
     */
    public class Population
    {
        public Population(int populationCount, string target, double mutationRate, Random random)
        {
            Target = target;
            MutationRate = mutationRate;
            MatingPool = new List<Individual>();
            Random = random;
            Fittest = new Individual(0, random);

            Initialize(populationCount);
        }

        public List<Individual> Members { get; private set; }

        public int GenerationCount { get; set; }
        public string Target { get; }
        public double MutationRate { get; }
        public List<Individual> MatingPool { get; }
        public Random Random { get; }
        public Individual Fittest { get; set; }
        
        private void Initialize(int populationCount)
        {
            Members = GenerateRandomPopulation(populationCount, Target.Length, Random).ToList();
        }

        public static IEnumerable<Individual> GenerateRandomPopulation(int populationSize, int genomePoolSize,
            Random random)
        {
            return Enumerable
                .Range(1, populationSize)
                .Select(c => new Individual(genomePoolSize, random));
        }
    }
}