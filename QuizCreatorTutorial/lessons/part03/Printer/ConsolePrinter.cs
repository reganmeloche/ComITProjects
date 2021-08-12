using System.Collections.Generic;
using System;

namespace QuizCreator.Part3 {

    public class ConsolePrinter : IPrintResults {
        public void Print(Dictionary<string, int> result) {
            foreach (var entry in result) {
               Console.WriteLine($"{entry.Key} ({entry.Value})");
            }
        }
    }

}