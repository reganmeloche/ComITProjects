using System.Collections.Generic;
using System;

namespace QuizCreator.Part7
{
    public class QuizBuilder : IBuildAQuiz
    {
        private readonly IGetWordInfo _wordInfoGetter;
        private readonly GameOptions _gameOptions;

        public QuizBuilder(IGetWordInfo wordInfoGetter, GameOptions gameOptions) {
            _wordInfoGetter = wordInfoGetter;
            _gameOptions = gameOptions;
        }

        public QuizResult Build(string initialText) {
            var quiz = new List<string>();
            var answerKey = new List<string>();

            var wordInfoDict = _wordInfoGetter.GetInfo(initialText);

            var splitWords = initialText.Split(' ');
            var distance = 0;
            Random rnd = new Random();

            foreach (var word in splitWords) {
                var strippedWord = Helpers.StripPunctuation(word);

                if (wordInfoDict.ContainsKey(strippedWord)) {
                    var score = 
                        GetTypeScore(wordInfoDict[strippedWord].WordType) +
                        wordInfoDict[strippedWord].WordCount + 
                        strippedWord.Length + 
                        rnd.Next(-_gameOptions.RandomFactor, _gameOptions.RandomFactor) +
                        distance;

                    if (score > _gameOptions.ScoreThreshold) {
                        var blank = BuildBlank(strippedWord);
                        quiz.Add(blank);
                        answerKey.Add(strippedWord);
                        distance = 0;
                        continue;
                    }
                }
                distance++;
                quiz.Add(word); 
            }

            return new QuizResult() {
                AnswerKey = answerKey,
                QuizText = String.Join(" ", quiz)
            };
        }

        private string BuildBlank(string word) {
            string result = $"{word[0]}";
            for (var i = 0; i < word.Length - 1; i++) {
                result += " _";
            }
            return result;
        }

        private int GetTypeScore(string wordType) {
            var result = 0;

            switch (wordType) {
                case "noun": 
                    result = 4;
                    break;
                case "adjective":
                    result = 2;
                    break;
                case "verb":
                    result = 3;
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}