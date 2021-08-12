using System.Collections.Generic;

namespace QuizCreator.Part5
{
    public interface ICountWords
    {
        Dictionary<string, int> CountWords(string text);
    }
}