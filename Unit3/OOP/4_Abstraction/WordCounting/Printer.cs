using System;
using System.Collections.Generic;
using System.IO;

namespace Unit3
{
    public interface IPrintResults {
        void Print(List<WordResult> result);
    }

    public class FilePrinter : IPrintResults
    {
        private readonly string _filename;

        public FilePrinter(string filename) {
            _filename = filename;
        }
        
        public void Print(List<WordResult> result) {
            var fileText = "";
            foreach (var item in result) {
               fileText +=$"{item.Word}\n";
               fileText +=$"-- Word Count: {item.Count}\n\n";
            }

            File.WriteAllText($"./{_filename}.txt", fileText);
        }
    }

    public class ConsolePrinter : IPrintResults {
        public void Print(List<WordResult> result) {
            var textToPrint = "";
            foreach (var item in result) {
               textToPrint +=$"{item.Word}\n";
               textToPrint +=$"-- Word Count: {item.Count}\n\n";
            }
            Console.Write(textToPrint);
        }
    }
}
