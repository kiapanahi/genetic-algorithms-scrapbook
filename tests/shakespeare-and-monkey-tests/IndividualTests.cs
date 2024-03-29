using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace ShakespeareAndMonkey.Tests
{
    public class IndividualTests
    {
        private const int NumberOfGenomes = 20;
        private static readonly Random Random = new Random();

        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        [Theory]
        [InlineData("abcdef", "abcdef", 1d)]
        [InlineData("abcdef", "xxxxxx", 0d)]
        [InlineData("abcdef", "abcxxx", 0.5d)]
        [InlineData("abcdef", "xxxdef", 0.5d)]
        [InlineData("abcdef", "axcxex", 0.5d)]
        [InlineData("abc", "abcxxx", 1d)]
        public void Should_Return_Correct_Fitness(string target, string genes, double fitness)
        {
            var sut = new Individual(genes.ToCharArray(), Random);
            sut.CalculateFitness(target.ToCharArray());

            Assert.Equal(fitness, sut.Fitness);
        }

        [Fact]
        public void Should_Calculate_Fitness()
        {
            const string targetString = "sample text";

            var sut = new Individual("sample other".ToCharArray(), Random);

            var oldFitness = sut.Fitness;

            sut.CalculateFitness(targetString.ToCharArray());

            Assert.NotEqual(sut.Fitness, oldFitness);
        }

        [Fact]
        public void Should_CrossOver()
        {
            var parent1 = new Individual(NumberOfGenomes, Random);
            var parent2 = new Individual(NumberOfGenomes, Random);

            var child = parent1.CrossOver(parent2);

            Assert.NotNull(child);
            Assert.Equal(NumberOfGenomes, child.Genes.Length);
        }

        [Fact]
        public void Should_Generate_Correct_Number_Of_Genomes()
        {
            var sut = new Individual(NumberOfGenomes, Random);

            Assert.NotNull(sut.Genes);
            Assert.NotEmpty(sut.Genes);
            Assert.Equal(NumberOfGenomes, sut.Genes.Length);
        }


        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        [Fact]
        public void Should_Return_Child_From_Two_Parents()
        {
            var p1 = new Individual("abcdefg".ToCharArray(), Random);
            var p2 = new Individual("tuvwxyz".ToCharArray(), Random);

            var child = p1.CrossOver(p2);

            Assert.NotNull(child);
        }

        [Fact]
        public void Should_Return_Correct_String_Representation()
        {
            const string s = "kia.panahirad@gmail.com";

            var sut = new Individual(s.ToCharArray(), Random);
            sut.CalculateFitness(s.ToCharArray());

            Assert.Equal(1d, sut.Fitness);

            Assert.Equal($"fitness: 100.00% - phrase: {s}", sut.ToString());
        }
    }
}