using System.Collections.Generic;
using System;

namespace QuizCreator.Part6
{
    public class QuizBuilder : IBuildAQuiz
    {
        private readonly int _scoreThreshold;
        private readonly IGetWordInfo _wordInfoGetter;

        public QuizBuilder(IGetWordInfo wordInfoGetter, int scoreThreshold) {
            _wordInfoGetter = wordInfoGetter;
            _scoreThreshold = scoreThreshold;
        }

        public QuizResult Build(string initialText) {
            var quiz = new List<string>();
            var answerKey = new List<string>();

            var wordInfoDict = _wordInfoGetter.GetInfo(initialText);

            var splitWords = initialText.Split(' ');
            var distance = 0;

            foreach (var word in splitWords) {
                var strippedWord = Helpers.StripPunctuation(word);

                if (wordInfoDict.ContainsKey(strippedWord)) {
                    // word score goes here- update this. Maybe no wordScorer class
                    var score = 
                        GetTypeScore(wordInfoDict[strippedWord].WordType) +
                        wordInfoDict[strippedWord].WordCount + 
                        strippedWord.Length + 
                        distance;

                    if (score > _scoreThreshold) {
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