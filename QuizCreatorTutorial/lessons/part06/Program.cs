using System;
using System.IO;
using System.Collections.Generic;

namespace QuizCreator.Part6
{
    class Program6
    {
        static void Main_(string[] args) {
            IReadInput reader = new FileReader("./myFile.txt");
            IPrintResults printer = new FilePrinter("outputFile");
            ICountWords wordCounter = new WordCounter();

            string url = "https://od-api.oxforddictionaries.com:443/api/v2/entries/";
            string appId = "27c066f9";
            string appKey = "5a04701d3d3b5a0e9120f79139b96751";
            string languageCode = "en-us";
            ILookupAWord oxfordLookup = new OxfordLookup(url, appId, appKey, languageCode);
            ILookupAWord wordLookup = new OuterLookup(oxfordLookup);
            IGetWordInfo wordInfoGetter = new WordInfoGetter(wordCounter, wordLookup);
            int scoreThreshold = 12;
            IBuildAQuiz quizBuilder = new QuizBuilder(wordInfoGetter, scoreThreshold);

            var runner = new Runner(reader, printer, quizBuilder);
            runner.Run();
        }   
    }
}
