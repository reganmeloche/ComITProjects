using System;
using Xunit;
using QuizCreator.Part7;

namespace QuizCreator.tests
{
    public class WordCounterTests
    {
        private readonly WordCounter _tester;
        public WordCounterTests() {
            _tester = new WordCounter();
        }

        [Fact]
        public void ShouldCountTheWords()
        {
            var testText = "hello. test. hello, hello test";
            int expectedHello = 3;
            int expectedTest = 2;

            var result = _tester.CountWords(testText);

            Assert.Equal(expectedHello, result["hello"]);
            Assert.Equal(expectedTest, result["test"]);
        }

    }
}