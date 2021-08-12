using System.Collections.Generic;

namespace QuizCreator.Part4
{
    public interface IPrintResults {
        void Print(Dictionary<string, WordInfo> result);
    }
}
