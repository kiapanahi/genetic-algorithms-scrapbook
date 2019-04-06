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
        private readonly List<Individual> _population;

        private int _generationCount;
        private double _fitness;
        private readonly string _target;
        private readonly double _mutationRate;
        private readonly List<Individual> _matingPool;
        private readonly Random _random;
        private Individual _fittest;

        public Population(int populationCount, string target, double mutationRate, Random random)
        {
            _target = target;
            _mutationRate = mutationRate;
            _matingPool = new List<Individual>();
            _random = random;
            _fittest = new Individual(0, random);


            _population = GenerateRandomPopulation(populationCount, _target.Length, _random).ToList();

            foreach (var individual in _population)
            {
                individual.CalculateFitness(_target.ToCharArray());
            }
        }

        public void CalculateFitness(string target)
        {
            var fitnessSum = 0d;
            foreach (var item in _population)
            {
                var individualFitness = item.CalculateFitness(target.ToCharArray());

                if (individualFitness > _fittest.Fitness)
                {
                    _fittest = item;
                }

                fitnessSum += individualFitness;
            }
            var normalizedFitness = fitnessSum / _population.Count;

            _fitness = normalizedFitness;
        }

        public void DoStuff()
        {
            while (Math.Abs(_fittest.Fitness - 1) > 0.001)
            {
                CalculateFitness(_target);
                NaturalSelection();
                GenerateNewPopulation();
                Report();

            }
        }

        private void Report()
        {
            Console.WriteLine($"Generation: {_generationCount}\n" +
                              $"fittest match: {_fittest}\n" +
                              "=====================================");
        }

        private void GenerateNewPopulation()
        {
            var size = _population.Count;
            _population.Clear();

            for (var i = 0; i < size; i++)
            {
                var father = _matingPool[_random.Next(_matingPool.Count - 1)];
                var mother = _matingPool[_random.Next(_matingPool.Count - 1)];
                var child = father.CrossOver(mother);
                child.Mutate(_mutationRate);
                _population.Add(child);
            }
            _generationCount++;
        }

        private void NaturalSelection()
        {
            _matingPool.Clear();

            foreach (var individual in _population)
            {
                var recurrence = (int)(individual.Fitness * 100);
                _matingPool.AddRange(Enumerable
                    .Range(1, recurrence)
                    .Select(s => individual));
            }
        }

        public static IEnumerable<Individual> GenerateRandomPopulation(int populationSize, int genomePoolSize, Random random)
        {
            return Enumerable
                .Range(1, populationSize)
                .Select(c => new Individual(genomePoolSize, random));
        }

    }
}