
using System;
using System.IO;
using System.Collections.Generic;

namespace QuizCreator.Part1
{
    class Program1
    {
        static void Main_(string[] args) {
            // Welcome
            Console.WriteLine("Welcome to your console app!");
            Console.WriteLine("Please enter your text:");

            // Get user input
            string userInput = Console.ReadLine();

            // Do the processing
            string[] wordArray = userInput.Split(' ');
            int wordCount = wordArray.Length;
            string nonSpaceCharacters = String.Join("", wordArray);
            int characterCount = nonSpaceCharacters.Length;

            // Output the results
            Console.WriteLine($"Word count: {wordCount}");
            Console.WriteLine($"Character count: {characterCount}");
        }
    }
}



