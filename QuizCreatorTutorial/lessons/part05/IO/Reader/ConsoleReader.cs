using System.Collections.Generic;
using System;

namespace QuizCreator.Part5
{

    public class ConsoleReader : IReadInput {
        public string Read() {
            Console.WriteLine("Please enter your text:");
            string userInput = Console.ReadLine();
            return userInput;
        }
    }

}