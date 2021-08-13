using System;
using System.Collections.Generic;
using System.IO;

namespace Unit3
{
    public interface IReadInput {
        string Read();
    }

    public class FileReader : IReadInput
    {
        private readonly string _filename;

        public FileReader(string filename) {
            _filename = filename;
        }
        
        public string Read() {
            string fileInput = File.ReadAllText(_filename);
            return fileInput;
        }
    }

    public class ConsoleReader : IReadInput {
        public string Read() {
            Console.WriteLine("Please enter your text:");
            string userInput = Console.ReadLine();
            return userInput;
        }
    }
}
