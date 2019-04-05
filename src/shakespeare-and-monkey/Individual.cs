using System;

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

        public Individual(int characterCount)
        {
            GenomePool = new char[characterCount];
        }

        public void CalculateFitness()
        {
            throw new NotImplementedException();
        }

        public Individual CrossOver(Individual other)
        {
            throw new NotImplementedException();
        }

    }

}
