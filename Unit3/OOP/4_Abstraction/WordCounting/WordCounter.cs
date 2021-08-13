using System;
using System.Collections.Generic;
using System.Linq;

namespace Unit3
{
    public interface ICountWords {
        List<WordResult> CountWords(string text);
    }

    public class WordCounterList : ICountWords {
        public List<WordResult> CountWords(string text) {
            var result = new List<WordResult>();

            string[] wordArray = text.Split(' ');

            foreach (string word in wordArray) {
                string strippedWord = this.StripPunctuation(word);
                
                // Look for the word
                WordResult foundWord = null;
                foreach (var item in result) {
                    if (item.Word == strippedWord) {
                        foundWord = item;
                    }
                }

                if (foundWord != null) {
                    foundWord.Count++;
                } else {
                    var newSet = new WordResult(strippedWord, 1);
                    result.Add(newSet);
                }

            }

            return result;
        }

        private string StripPunctuation(string word) {
            string newWord = "";
            foreach (char nextChar in word) {
                if (!Char.IsPunctuation(nextChar)) {
                    newWord += nextChar;
                }
            }
            return newWord;
        }
    }

    public class WordCounterDict : ICountWords
    {
        public List<WordResult> CountWords(string text) {
            var result = new List<WordResult>();

            var dict = new Dictionary<string, int>();

            string[] wordArray = text.Split(' ');

            foreach (string word in wordArray) {
                string strippedWord = this.StripPunctuation(word);
                if (dict.ContainsKey(strippedWord)) {
                    dict[strippedWord]++;
                } else {
                    dict.Add(strippedWord, 1);
                }
            }

            result = dict.Select(x => new WordResult(x.Key, x.Value)).ToList();
            return result;
        }

        private string StripPunctuation(string word) {
            string newWord = "";
            foreach (char nextChar in word) {
                if (!Char.IsPunctuation(nextChar)) {
                    newWord += nextChar;
                }
            }
            return newWord;
        }
    }

    public class WordResult {
        public string Word {get; set;}
        public int Count {get; set;}

        public WordResult(string word, int count) {
            Word = word;
            Count = count;
        }
    }
}
