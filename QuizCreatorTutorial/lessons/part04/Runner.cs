using System;
using System.IO;
using System.Collections.Generic;

namespace QuizCreator.Part4
{
    public class Runner
    {
        private readonly IReadInput _reader;
        private readonly IPrintResults _printer;
        private readonly ICountWords _wordCounter;
        
        public Runner(
            IReadInput reader,
            IPrintResults printer, 
            ICountWords wordCounter) 
        {
            _reader = reader;
            _printer = printer;
            _wordCounter = wordCounter;
        }

        public void Run()
        {
            string text = _reader.Read();
            
            var result = new Dictionary<string, WordInfo>();
            var wordCountDict = _wordCounter.CountWords(text);
            
            foreach (var entry in wordCountDict) {
                var wordInfo = new WordInfo() {
                    WordCount = entry.Value,
                    CharacterCount = entry.Key.Length
                };
                result.Add(entry.Key, wordInfo);
            }

            _printer.Print(result);
        }    
    }
}
