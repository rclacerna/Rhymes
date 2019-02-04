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

            var userInput = "yg";
            var results = analyzerService.FindRhymes(userInput);

            if (results == null)
            {
                Console.WriteLine("No Matches found");
            }
            else
            {
                results.ForEach(Console.WriteLine);
            }
        }
    }
}
