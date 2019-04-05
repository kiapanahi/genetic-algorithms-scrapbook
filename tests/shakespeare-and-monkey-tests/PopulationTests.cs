using System;
using System.Linq;
using Xunit;

namespace ShakespeareAndMonkey.Tests
{
    public class PopulationTests
    {
        private static readonly Random Random = new Random();

        [Fact]
        public void Should_Create_Randomly_Initialized_Individuals()
        {
            var population = Population
                .GenerateRandomPopulation(200, 20, Random)
                .ToList();

            Assert.NotNull(population);
            Assert.True(population.Count == 200);
            foreach (var item in population)
            {
                Assert.True(item.GenomePool.Length == 20);
            }
        }
    }
}