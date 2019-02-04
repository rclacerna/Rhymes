using System.Collections.Generic;
using Siri.Interfaces;

namespace Siri
{
    public class Data : IData
    {
        public Dictionary<string, int> WordsCollection()
        {
            return new Dictionary<string, int>{
                {"Computing", 0 },
                {"Polluting", 0 },
                {"Diluting", 0 },
                {"Commuting", 0 },
                {"Recruiting", 0 },
                {"Drooping", 0 },
                {"Apples", 0 },
                {"Bling", 0 },
                {"Dog", 0 }
            };
        }
    }
}
