using System.Collections.Generic;

namespace QuizCreator.Part6
{
    public class WordInfoGetter : IGetWordInfo
    {
        private readonly ICountWords _wordCounter;
        private readonly ILookupAWord _wordLookup;

        public WordInfoGetter(ICountWords wordCounter, ILookupAWord wordLookup) {
            _wordCounter = wordCounter;
            _wordLookup = wordLookup;
        }

        public Dictionary<string, WordInfo> GetInfo(string text) {
            var result = new Dictionary<string, WordInfo>();
            var wordCounts = _wordCounter.CountWords(text);

            foreach (var entry in wordCounts) {
                var coreWord = _wordLookup.Lookup(entry.Key);

                var wordInfo = new WordInfo() {
                    WordCount = entry.Value,
                    WordType = coreWord.WordType,
                    CharacterCount = entry.Key.Length
                };
                result.Add(entry.Key, wordInfo);
            }
            return result;
        } 
    }
}