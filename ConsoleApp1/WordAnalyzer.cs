using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siri
{
    public class WordAnalyzer : IWordAnalyzer
    {
        private IData _data;
        private Dictionary<string, int> wordCollection;

        public WordAnalyzer(IData data)
        {
            _data = data;
            wordCollection = _data.WordsCollection();
        }

        public void FindRhymes(string userInput)
        {
            if (!IsValid(userInput))
            {
                PrintResults("Matches none");
            }
            else
            {
                ProcessAllWordsInParallel(userInput);
                GetMatches(wordCollection);
            }
        }

        private void ProcessAllWordsInParallel(string userInput)
        {
            Parallel.ForEach(wordCollection.ToList(), word =>
            {
                wordCollection[word.Key] += ScoreTokens(userInput, word.Key);
            });
        }

        public void GetMatches(Dictionary<string, int> scoreTable)
        {
            var scores = scoreTable.OrderByDescending(key => key.Value).ToList();
            var highestScore = scores[0].Value;

            if (highestScore < 1)
            {
                PrintResults("Matches none");
            }
            else
            {
                for (var i = 0; i <= scores.Count - 1; i++)
                {
                    if (scores[i].Value < highestScore)
                    {
                        break;
                    }

                    PrintResults(scores[i].Key);
                }
            }
        }

        private int ScoreTokens(string userInput, string wordToMatch)
        {
            var score = 0;

            for (int i = 0; i < userInput.Length - 1; i++)
            {
                if (GetChar(userInput, i) != GetChar(wordToMatch, i))
                {
                    break;
                }

                score++;
            }

            return score;
        }

        private char GetChar(string word, int index)
        {
            return word[(word.Length - 1) - index];
        }

        public void PrintResults(string results)
        {
            Console.WriteLine(results);
        }

        public bool IsValid(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput) || wordCollection.ContainsKey(userInput))
            {
                return false;
            }

            return true;
        }

    }
}
