using System;
using System.Collections.Generic;
using Xunit;
using FakeItEasy;
using QuizCreator.Part7;


namespace QuizCreator.tests
{
    public class WordInfoGetterTests
    {
        private readonly ICountWords _wordCounter;
        private readonly ILookupAWord _wordLookup;
        private WordInfoGetter _tester;
        public WordInfoGetterTests() {
            _wordCounter = A.Fake<ICountWords>();
            _wordLookup = A.Fake<ILookupAWord>();
            _tester = new WordInfoGetter(_wordCounter, _wordLookup);
        }

        [Fact]
        public void ShouldGetWordInfo()
        {
            var testText = "this is a test";

            var fakeWordCounts = new Dictionary<string, int>() {
                { "test", 2 },
                { "fake" , 3 }
            };
            A.CallTo(() => _wordCounter.CountWords(A<string>._)).Returns(fakeWordCounts);
            
            var testWord1 = new CoreWord() {
                Word = "test",
                Definition = "test definition",
                WordType = "noun"
            };
            A.CallTo(() => _wordLookup.Lookup("test")).Returns(testWord1);

            var testWord2 = new CoreWord() {
                Word = "fake",
                Definition = "test definition 2",
                WordType = "adjective"
            };
            A.CallTo(() => _wordLookup.Lookup("fake")).Returns(testWord2);
            
            var result = _tester.GetInfo(testText);

            Assert.Equal(2, result["test"].WordCount);
            Assert.Equal("noun", result["test"].WordType);
            Assert.Equal(4, result["fake"].CharacterCount);
            // Can add more
        }

    }
}