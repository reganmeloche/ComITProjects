using System.Collections.Generic;

namespace QuizCreator.Part4
{
    public interface ICountWords
    {
        Dictionary<string, int> CountWords(string text);
    }
}