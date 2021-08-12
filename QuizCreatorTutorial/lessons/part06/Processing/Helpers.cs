using System;

namespace QuizCreator.Part6
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