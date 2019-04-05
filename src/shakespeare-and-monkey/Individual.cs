using System;
using System.Collections.Generic;
using System.Linq;

namespace ShakespeareAndMonkey
{
    /*
    individual: the entity that
        * can calculate it's fitness
        * knows about it's gene[s]
        * can crossover with another individual
        * can apply mutation to it's gene[s]
     */
    public class Individual
    {
        public char[] GenomePool { get; private set; }
        public double Fitness { get; private set; }

        private const string Characters = "abcdefghijklmnopqrstuvwxyz1234567890 .@_+";

        public Individual(int poolSize, Random random)
        {
            GenomePool = new char[poolSize];

            for (var i = 0; i < poolSize; i++)
            {
                var c = Characters[random.Next(Characters.Length - 1)];
                GenomePool[i] = c;
            }

        }

        public double CalculateFitness()
        {
            throw new NotImplementedException();
        }

        public Individual CrossOver(Individual other)
        {
            throw new NotImplementedException();
        }

    }

}
