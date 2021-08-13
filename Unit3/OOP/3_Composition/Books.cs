using System;
using System.Collections.Generic;

namespace Unit3
{
    public class Book
    {
        public Author Author {get;set;}

        public string Title {get;set;}

        public int Year {get;set;}

        public List<string> Genres {get;set;}
    }
}
