using System.Collections.Generic;

namespace QuizCreator.Part7
{
    public interface ILookupAWord
    {
        CoreWord Lookup(string word);
    }
}