using System.Collections.Generic;

namespace QuizCreator.Part3 {
    public interface IPrintResults {
        void Print(Dictionary<string, int> result);
    }
}
