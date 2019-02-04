using System;
using Microsoft.Extensions.DependencyInjection;
using Siri.Interfaces;

namespace Siri
{
    internal class Startup
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IData, Data>()
                .AddSingleton<IWordAnalyzer, WordAnalyzer>()
                .BuildServiceProvider();

            var analyzerService = serviceProvider.GetService<IWordAnalyzer>();

            Console.WriteLine("Please enter a word: ");
            var input = Console.ReadLine();
            Console.WriteLine("---results---");

            var results = analyzerService.FindRhymes(input);

            if (results == null)
            {
                Console.WriteLine("Matches none");
            }
            else
            {
                results.ForEach(Console.WriteLine);
            }
        }
    }
}
