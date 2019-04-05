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
        private readonly IEnumerable<Individual> _items;

        private int generationCount = 0;

        public Population(int populationCount,int stringLength, Random random)
        {
            _items = GenerateRandomPopulation(populationCount, stringLength, random);
        }

        public double CalculatePopulationFitness()
        {
            var fitnessSum = 0d;
            foreach (var item in _items)
            {
                fitnessSum += item.CalculateFitness();
            }
            var normalizedFitness = fitnessSum / _items.Count();

            return normalizedFitness;
        }

        public static IEnumerable<Individual> GenerateRandomPopulation(int populationSize, int genomePoolSize, Random random)
        {
            return Enumerable
                .Range(1, populationSize)
                .Select(c => new Individual(genomePoolSize, random));
        }

    }
}