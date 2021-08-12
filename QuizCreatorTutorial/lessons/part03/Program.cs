using System;
using System.IO;
using System.Collections.Generic;

namespace QuizCreator.Part3
{
    class Program3
    {
        static void Main_(string[] args) {
            // Setting up implementation
            //IReadInput reader = new ConsoleReader();
            IReadInput reader = new FileReader("./myFile.txt");
            //IPrintResults printer = new ConsolePrinter();
            IPrintResults printer = new FilePrinter("outputFile");
            
            // Welcome
            Console.WriteLine("Welcome to your console app!");

            // Get input
            string text = reader.Read();

            // Do the processing
            Dictionary<string, int> result = ProcessInput(text);

            // Output the results
            printer.Print(result);
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

        private static string StripPunctuation(string word) {
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



