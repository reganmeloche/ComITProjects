using System;

namespace ComitLibrary.Models
{
    public class Book
    {
        public Book(long id, string title, string author) {
            Id = id;
            Title = title;
            Author = author;
            IsCheckedOut = false;
        }

        public long Id { get; }
        public string Title { get; private set; }
        public string Author {get; private set;}
        public bool IsCheckedOut { get; private set; }

        public void CheckOut() {
            if (!IsCheckedOut) {
                IsCheckedOut = true;
            } else {
                throw new Exception($"Book {Id} is already checked out!");
            }
        }

        public void CheckIn() {
            if (IsCheckedOut) {
                IsCheckedOut = false;
            } else {
                throw new Exception($"Book {Id} is already checked in!");
            }
        }

        public override string ToString()
        {
            string details = $"\n----- Book {Id} -----\n";
            details += $"Title: {Title}\n";
            details += $"Author: {Author}\n";
            details += $"Checked out: {IsCheckedOut}\n";
            details += "-------------------------\n";
            return details;
        }
    }
}