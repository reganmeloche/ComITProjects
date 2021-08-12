using System;

namespace QuizCreator.Part7
{
    public static class Helpers
    {
        public static string StripPunctuation(string word) {
            string newWord = "";
            foreach (char nextChar in word) {
                if (!Char.IsPunctuation(nextChar)) {
                    newWord += nextChar;
                }
            }
            return newWord;
        }
    }
}