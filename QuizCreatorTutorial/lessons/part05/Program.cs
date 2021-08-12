using System;
using System.IO;
using System.Collections.Generic;

namespace QuizCreator.Part5
{
    class Program5
    {
        static void Main_(string[] args) {
            IReadInput reader = new FileReader("./myFile.txt");
            IPrintResults printer = new FilePrinter("outputFile");
            ICountWords wordCounter = new WordCounter();
            IBuildAQuiz quizBuilder = new QuizBuilder(wordCounter);

            var runner = new Runner(reader, printer, quizBuilder);
            runner.Run();
        }   
    }
}
