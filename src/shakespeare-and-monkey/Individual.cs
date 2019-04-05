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
        private const string Characters = "abcdefghijklmnopqrstuvwxyz1234567890 .@_+";

        public Individual(int poolSize, Random random)
        {
            Genes = new char[poolSize];

            for (var i = 0; i < poolSize; i++)
            {
                var c = Characters[random.Next(Characters.Length - 1)];
                Genes[i] = c;
            }
        }

        public Individual(char[] genes)
        {
            Genes = genes;
        }

        public char[] Genes { get; }
        public double Fitness { get; private set; }

        public double CalculateFitness(char[] target)
        {
            if (target.Length > Genes.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(target),
                    "target's length must be less than or equal to DNA's gene pool size");
            }

            var score = 0;
            for (var i = 0; i < target.Length; i++)
            {
                score += Genes[i] == target[i] ? 1 : 0;
            }

            Fitness = (double) score / target.Length;
            return Fitness;
        }

        public Individual CrossOver(Individual other)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"fitness: {Fitness:P} - phrase: {new string(Genes)}";
        }
    }
}