using System;
using System.IO;
using System.Collections.Generic;

namespace QuizCreator.Part5
{
    public class Runner
    {
        private readonly IReadInput _reader;
        private readonly IPrintResults _printer;
        private readonly IBuildAQuiz _quizBuilder;
        
        public Runner(
            IReadInput reader,
            IPrintResults printer, 
            IBuildAQuiz quizBuilder) 
        {
            _reader = reader;
            _printer = printer;
            _quizBuilder = quizBuilder;
        }

        public void Run()
        {
            var text = _reader.Read();
            var result = _quizBuilder.Build(text);
            _printer.Print(result);
        }    
    }
}
