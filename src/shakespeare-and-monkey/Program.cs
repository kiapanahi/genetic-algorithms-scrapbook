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
            var population = new Population(1000, phrase, 0.01, new Random());
            population.DoStuff();

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}