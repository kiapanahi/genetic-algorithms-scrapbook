using System;

namespace ShakespeareAndMonkey
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Enter the phrase you wanna do:");
            Console.Write("> ");
            var phrase = Console.ReadLine();

            var random = new Random();

            var population = new Population(1000, phrase, 0.01, random);
            
            var evolvingPopulation = new EvolvingPopulation(population, random);

            evolvingPopulation.Evolve();

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}