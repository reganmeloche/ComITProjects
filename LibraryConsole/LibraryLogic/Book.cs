using System;
using System.Collections.Generic;

namespace LibraryLogic
{
    public class Book
    {
        public Author Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }

        public override string ToString() {
            return $"\nTitle: {Title}\n- Author: {Author.FullName}\n- Genre: {Genre}\n- Year: {Year}";
        }
    }
}
