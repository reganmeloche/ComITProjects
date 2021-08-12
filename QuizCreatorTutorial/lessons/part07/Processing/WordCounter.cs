using System;
using System.Collections.Generic;

namespace QuizCreator.Part7
{
    public class WordCounter : ICountWords
    {
        public Dictionary<string,int> CountWords(string input) {
            var result = new Dictionary<string, int>();

            string[] wordArray = input.Split(' ');

            foreach (string word in wordArray) {
                string strippedWord = Helpers.StripPunctuation(word);
                if (result.ContainsKey(strippedWord)) {
                    result[strippedWord]++;
                } else {
                    result.Add(strippedWord, 1);
                }
            }

            return result;
        }
    }
}