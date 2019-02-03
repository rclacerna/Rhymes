using Microsoft.Extensions.DependencyInjection;

namespace Siri
{
    internal class Startup
    {
        private static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IData, Data>()
                .AddSingleton<IWordAnalyzer, WordAnalyzer>()
                .BuildServiceProvider();

            var analyzerService = serviceProvider.GetService<IWordAnalyzer>();

            var userInput = "uting";

            analyzerService.FindRhymes(userInput);
        }
    }
}
