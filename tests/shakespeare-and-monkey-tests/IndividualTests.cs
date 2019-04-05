using System;
using Xunit;

namespace ShakespeareAndMonkey.Tests
{
    public class IndividualTests
    {
        private const int NumberOfGenomes = 20;
        private static readonly Random Random = new Random();

        [Fact]
        public void Should_Calculate_Fitness()
        {
            var sut = new Individual(NumberOfGenomes, Random);

            var oldFitness = sut.Fitness;

            sut.CalculateFitness();

            Assert.NotEqual(sut.Fitness, oldFitness);
        }

        [Fact]
        public void Should_CrossOver()
        {
            var parent1 = new Individual(NumberOfGenomes, Random);
            var parent2 = new Individual(NumberOfGenomes, Random);

            var child = parent1.CrossOver(parent2);

            Assert.NotNull(child);
            Assert.Equal(NumberOfGenomes, child.GenomePool.Length);
        }

        [Fact]
        public void Should_Generate_Correct_Number_Of_Genomes()
        {
            var sut = new Individual(NumberOfGenomes, Random);

            Assert.NotNull(sut.GenomePool);
            Assert.NotEmpty(sut.GenomePool);
            Assert.Equal(NumberOfGenomes, sut.GenomePool.Length);
        }
    }
}