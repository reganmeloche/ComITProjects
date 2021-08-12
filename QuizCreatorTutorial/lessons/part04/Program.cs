using System;
using System.IO;
using System.Collections.Generic;

namespace QuizCreator.Part4
{
    class Program4
    {
        static void Main_(string[] args) {
            IReadInput reader = new FileReader("./myFile.txt");
            IPrintResults printer = new FilePrinter("outputFile");
            ICountWords wordCounter = new WordCounter();

            var runner = new Runner(reader, printer, wordCounter);
            runner.Run();
        }   
    }
}
