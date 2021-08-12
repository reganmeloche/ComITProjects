using System.Collections.Generic;
using System;

namespace QuizCreator.Part5
{
    public class QuizBuilder : IBuildAQuiz
    {
        private readonly int SCORE_THRESHOLD = 12;
        private readonly ICountWords _wordCounter;

        public QuizBuilder(ICountWords wordCounter) {
            _wordCounter = wordCounter;
        }

        public QuizResult Build(string initialText) {
            var quiz = new List<string>();
            var answerKey = new List<string>();

            var wordCounts = _wordCounter.CountWords(initialText);

            var splitWords = initialText.Split(' ');
            var distance = 0;

            foreach (var word in splitWords) {
                var strippedWord = Helpers.StripPunctuation(word);

                if (wordCounts.ContainsKey(strippedWord)) {
                    var score = wordCounts[strippedWord] + strippedWord.Length + distance;

                    if (score > SCORE_THRESHOLD) {
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
    }
}