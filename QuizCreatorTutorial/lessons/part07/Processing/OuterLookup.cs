using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace QuizCreator.Part7
{
    public class OuterLookup : ILookupAWord
    {
        private readonly int CHAR_LIMIT = 3;
        private readonly ILookupAWord _innerLookup;

        public OuterLookup(ILookupAWord innerLookup) {
            _innerLookup = innerLookup;
        }

        public CoreWord Lookup(string word) {
            var result = new CoreWord(word);

            if (word.Length <= CHAR_LIMIT) {
                return result;
            }

            return _innerLookup.Lookup(word);
        }
    }
}