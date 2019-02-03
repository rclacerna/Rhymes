using System.Collections.Generic;

namespace Siri
{
    public interface IWordAnalyzer
    {
        void FindRhymes(string word);
        void GetMatches(Dictionary<string, int> matches);
        void PrintResults(string results);
    }
}
