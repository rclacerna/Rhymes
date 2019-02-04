using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Siri.Interfaces;

namespace Siri
{
    public class WordAnalyzer : IWordAnalyzer
    {
        private readonly Dictionary<string, int> _wordCollection;

        public WordAnalyzer(IData data)
        {
            _wordCollection = data.WordsCollection();
        }

        public List<string> FindRhymes(string userInput)
        {
            if (!IsValid(userInput))
                return null;

            ProcessAllWordsInParallel(userInput);

            return GetResults(_wordCollection);
        }

        private void ProcessAllWordsInParallel(string userInput)
        {
            Parallel.ForEach(_wordCollection.ToList(),
                word =>
                {
                    _wordCollection[word.Key] += ScoreTokens(userInput, word.Key);
                });
        }

        public List<string> GetResults(Dictionary<string, int> scoreTable)
        {
            var scores = scoreTable.OrderByDescending(key => key.Value).ToList();
            var highestScore = scores[0].Value;

            if (highestScore < 1)
                return null;

            return GetMatchList(scores, highestScore);
        }

        private static List<string> GetMatchList(List<KeyValuePair<string, int>> scores, int highestScore)
        {
            var matches = new List<string>();

            foreach (var score in scores)
            {
                if (score.Value < highestScore)
                    break;

                matches.Add(score.Key);
            }
            return matches;
        }

        private int ScoreTokens(string userInput, string wordToMatch)
        {
            var score = 0;

            for (var i = 0; i < userInput.Length - 1; i++)
            {
                if (GetChar(userInput, i) != GetChar(wordToMatch, i))
                    break;

                score++;
            }

            return score;
        }

        private char GetChar(string word, int index)
        {
            return word[word.Length - 1 - index];
        }

        public bool IsValid(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput) || _wordCollection.ContainsKey(userInput))
                return false;

            return true;
        }
    }
}