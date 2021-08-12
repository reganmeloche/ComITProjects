using System;
using System.IO;
using System.Collections.Generic;

namespace QuizCreator.Part2
{
    class Program2
    {
        static void Main_(string[] args) {
            // Welcome
            Console.WriteLine("Welcome to your console app!");
            Console.WriteLine("Please enter your text:");

            // Get user input
            string userInput = Console.ReadLine();

            // Do the processing
            Dictionary<string, int> result = ProcessInput(userInput);

            // Output the results
            PrintResult(result);
        }   

        private static Dictionary<string, int> ProcessInput(string input) {
            var result = new Dictionary<string, int>();

            string[] wordArray = input.Split(' ');

            foreach (string word in wordArray) {
                string strippedWord = StripPunctuation(word);
                if (result.ContainsKey(strippedWord)) {
                    result[strippedWord]++;
                } else {
                    result.Add(strippedWord, 1);
                }
            }

            return result;
        }

        // Bonus part
        private static string StripPunctuation(string word) {
            string newWord = "";
            foreach (char nextChar in word) {
                if (!Char.IsPunctuation(nextChar)) {
                    newWord += nextChar;
                }
            }
            return newWord;
        }

        private static void PrintResult(Dictionary<string, int> result) {
            Console.WriteLine("-------------");
            foreach (var entry in result) {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }
    }
}



