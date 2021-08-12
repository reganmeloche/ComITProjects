using System.Collections.Generic;
using System.IO;

namespace QuizCreator.Part3
{
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
}