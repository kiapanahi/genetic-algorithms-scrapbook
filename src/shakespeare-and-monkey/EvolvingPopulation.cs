using System;
using System.Linq;

namespace ShakespeareAndMonkey
{
    public class EvolvingPopulation
    {
        private readonly Population _population;
        private readonly Random _random;

        public EvolvingPopulation(Population population, Random random)
        {
            _population = population;
            _random = random;
        }

        public void Evolve()
        {
            while (Math.Abs(_population.Fittest.Fitness - 1) > 0.001)
            {
                CalculateFitness();
                NaturalSelection();
                GenerateNewPopulation();
                Report();
            }
        }

        private void CalculateFitness()
        {
            foreach (var member in _population.Members)
            {
                var memberFitness = member.CalculateFitness(_population.Target.ToCharArray());
                if (memberFitness > _population.Fittest.Fitness)
                {
                    _population.Fittest = member;
                }
            }
        }

        private void Report()
        {
            Console.WriteLine($"Generation: {_population.GenerationCount}\n" +
                              $"fittest match: {_population.Fittest}\n" +
                              "=====================================");
        }

        private void GenerateNewPopulation()
        {
            var size = _population.Members.Count;
            _population.Members.Clear();

            for (var i = 0; i < size; i++)
            {
                var father = _population.MatingPool[_random.Next(_population.MatingPool.Count - 1)];
                var mother = _population.MatingPool[_random.Next(_population.MatingPool.Count - 1)];
                var child = father.CrossOver(mother);
                child.Mutate(_population.MutationRate);
                _population.Members.Add(child);
            }

            _population.GenerationCount++;
        }

        private void NaturalSelection()
        {
            _population.MatingPool.Clear();

            foreach (var individual in _population.Members)
            {
                var recurrence = (int)(individual.Fitness * 100);
                _population.MatingPool.AddRange(Enumerable
                    .Range(1, recurrence)
                    .Select(s => individual));
            }
        }
    }
}