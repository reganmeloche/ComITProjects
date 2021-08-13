using System;
using System.Collections.Generic;

namespace Unit3
{
    public class WordCounterRunner
    {
        private readonly IPrintResults _printer;
        private readonly IReadInput _reader;
        private readonly ICountWords _counter;

        public WordCounterRunner(IPrintResults printResults, IReadInput reader, ICountWords counter) {
            _printer = printResults;
            _reader = reader;
            _counter = counter; 
        }

        public void Run()
        {
            string input = _reader.Read();
            List<WordResult> result = _counter.CountWords(input);
            _printer.Print(result);
        }
    }
}


//Example:

/*
IReadInput reader = new ConsoleReader(); //FileReader();
IPrintResults printer = new ConsolePrinter(); //FilePrinter();
ICountWords wordCounter = new WordCounterList(); //WordCounterDict();

var runner = new WordCounterRunner(printer, reader, counter);
runner.Run();
*/