using System.Collections.Generic;

namespace QuizCreator.Part7
{
    public interface IGetWordInfo
    {
        Dictionary<string, WordInfo> GetInfo(string text);
    }
}