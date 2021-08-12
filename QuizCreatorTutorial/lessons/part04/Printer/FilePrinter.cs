using System.Collections.Generic;
using System.IO;

namespace QuizCreator.Part4
{
    public class FilePrinter : IPrintResults
    {
        private readonly string _filename;

        public FilePrinter(string filename) {
            _filename = filename;
        }
        
        public void Print(Dictionary<string, WordInfo> result) {
            var fileText = "";
            foreach (var entry in result) {
               fileText +=$"{entry.Key}\n";
               fileText +=$"-- Word Count: {entry.Value.WordCount}\n";
               fileText +=$"-- Character Count: {entry.Value.CharacterCount}\n\n";
            }

            File.WriteAllText($"./{_filename}.txt", fileText);
        }
    }
}