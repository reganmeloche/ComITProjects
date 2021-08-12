using System.Collections.Generic;

namespace QuizCreator.Part6
{
    public interface ICountWords
    {
        Dictionary<string, int> CountWords(string text);
    }
}