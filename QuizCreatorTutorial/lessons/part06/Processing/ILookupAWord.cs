using System.Collections.Generic;

namespace QuizCreator.Part6
{
    public interface ILookupAWord
    {
        CoreWord Lookup(string word);
    }
}