using System.Collections.Generic;
using System.IO;

namespace QuizCreator.Part3
{
    public class FilePrinter : IPrintResults
    {
        private readonly string _filename;

        public FilePrinter(string filename) {
            _filename = filename;
        }
        
        public void Print(Dictionary<string, int> result) {
            var fileText = "";
            foreach (var entry in result) {
               fileText +=$"{entry.Key} ({entry.Value})\n";
            }

            File.WriteAllText($"./{_filename}.txt", fileText);
        }
    }
}