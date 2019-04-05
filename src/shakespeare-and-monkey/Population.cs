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
        private readonly IEnumerable<Individual> _population;

        private int generationCount = 0;

        public Population(int populationCount,int stringLength, Random random)
        {
            _population = GenerateRandomPopulation(populationCount, stringLength, random);
        }

        public double CalculatePopulationFitness(string target)
        {
            var fitnessSum = 0d;
            foreach (var item in _population)
            {
                fitnessSum += item.CalculateFitness(target.ToCharArray());
            }
            var normalizedFitness = fitnessSum / _population.Count();

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