using System.Collections.Generic;
using System.IO;
using System;

namespace QuizCreator.Part7
{
    public class FilePrinter : IPrintResults
    {
        private readonly string _filename;

        public FilePrinter(string filename) {
            _filename = filename;
        }
        
        public void Print(QuizResult result) {
            File.WriteAllText($"./{_filename}.txt", result.QuizText);
            File.WriteAllText($"./{_filename}_answers.txt", String.Join(", ", result.AnswerKey));
        }
    }
}