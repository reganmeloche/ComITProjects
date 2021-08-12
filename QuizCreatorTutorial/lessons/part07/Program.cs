using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;

namespace QuizCreator.Part7
{
    class Program7
    {
        static void Main(string[] args) {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var oxfordConfig = config.GetSection("oxfordApi");

            IReadInput reader = new FileReader(config["inputFilePath"]);
            IPrintResults printer = new FilePrinter(config["outputFileName"]);
            ICountWords wordCounter = new WordCounter();

            string url = oxfordConfig["url"];    
            string appId = oxfordConfig["appId"];
            string appKey = oxfordConfig["appKey"];
            string languageCode = oxfordConfig["languageCode"];
            ILookupAWord oxfordLookup = new OxfordLookup(url, appId, appKey, languageCode);
            ILookupAWord wordLookup = new OuterLookup(oxfordLookup);
            IGetWordInfo wordInfoGetter = new WordInfoGetter(wordCounter, wordLookup);

            GameOptions gameOptions = new GameOptions() {
                RandomFactor = Int32.Parse(config["randomFactor"]),
                ScoreThreshold = Int32.Parse(config["scoreThreshold"])
            };

            IBuildAQuiz quizBuilder = new QuizBuilder(wordInfoGetter, gameOptions);

            var runner = new Runner(reader, printer, quizBuilder);
            runner.Run();
        }   
    }
}
