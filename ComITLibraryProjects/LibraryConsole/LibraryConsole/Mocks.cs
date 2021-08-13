using System;
using System.Collections.Generic;
using LibraryLogic;

namespace LibraryConsole
{
    static class MockBuilder
    {
        public static List<Book> BuildBooks()
        {
            var kurtVonnegut = new Author("Kurt", "Vonnegut", new DateTime(1920, 11, 1));
            var sh5 = new Book() {
                Author = kurtVonnegut,
                Title = "Slaughterhouse Five",
                Year = 1969,
                Genre = "sci-fi"
            };

            var harperLee = new Author("Harper", "Lee", new DateTime(1910, 11, 1));
            var tkam = new Book() {
                Author = harperLee,
                Title = "To Kill a Mockingbird",
                Year = 1960,
                Genre = "drama"
            };

            var toniMorrison = new Author("Toni", "Morrison", new DateTime(1930, 11, 1));
            var beloved = new Book() {
                Author = toniMorrison,
                Title = "Beloved",
                Year = 1987,
                Genre = "drama"
            };

            var jrrTolkien = new Author("J.R.R", "Tolkien", new DateTime(1900, 11, 1));
            var lotr = new Book() {
                Author = jrrTolkien,
                Title = "Lord of the Rings",
                Year = 1954,
                Genre = "Fantasy"
            };
            var hobbit = new Book() {
                Author = jrrTolkien,
                Title = "The Hobbit",
                Year = 1937,
                Genre = "Fantasy"
            };

            var bookList = new List<Book>() {
                sh5, tkam, beloved, lotr, hobbit
            };

            return bookList;
        }

        public static List<Author> BuildAuthors()
        {
            return new List<Author>();
        }
    
        public static List<LibraryBook> BuildLibraryBooks(List<Book> books) {
            var result = new List<LibraryBook>();

            for (int i = 0; i < books.Count; i++) {
                var newLb = new LibraryBook(i+1, books[i]);
                result.Add(newLb);
            }

            return result;
        }   

        public static List<Patron> BuildPatrons() {
            //Add
            var patron1 = new Patron(1, "Joe", "Smith", new DateTime(2000, 12, 10));

            var patron2 = new Patron(2, "Jane", "Doe", new DateTime(1990, 1, 30));

            var patron3 = new Patron(3, "Kyle", "Jones", new DateTime(1980, 4, 12));


            return new List<Patron>() {
                patron1, patron2, patron3
            };
        }
    }
}
