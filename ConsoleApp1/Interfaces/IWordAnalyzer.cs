using System.Collections.Generic;

namespace Siri.Interfaces
{
    public interface IWordAnalyzer
    {
        List<string> FindRhymes(string word);
        List<string> GetResults(Dictionary<string, int> matches);
    }
}
