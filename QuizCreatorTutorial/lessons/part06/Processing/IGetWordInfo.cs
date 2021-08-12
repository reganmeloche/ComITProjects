using System.Collections.Generic;

namespace QuizCreator.Part6
{
    public interface IGetWordInfo
    {
        Dictionary<string, WordInfo> GetInfo(string text);
    }
}