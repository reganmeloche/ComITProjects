using System.Collections.Generic;
using System;

namespace QuizCreator.Part7
{

    public class ConsoleReader : IReadInput {
        public string Read() {
            Console.WriteLine("Please enter your text:");
            string userInput = Console.ReadLine();
            return userInput;
        }
    }

}