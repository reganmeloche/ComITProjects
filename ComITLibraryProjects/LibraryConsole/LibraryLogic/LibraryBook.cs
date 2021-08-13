using System;
using System.Collections.Generic;

namespace LibraryLogic
{
    public class LibraryBook
    {
        public long Id { get; private set; }
        public Book Book { get; }
        public bool IsCheckedOut { get; private set; }
        public DateTime DateReceived { get; }

        public LibraryBook(long id, Book book) {
            Id = id;
            Book = book;
            DateReceived = DateTime.Now;
            IsCheckedOut = false;
        }

        public void CheckOut() {
            if (IsCheckedOut) {
                throw new Exception("Library book is already checked out.");
            }
            IsCheckedOut = true;
        }

        public void Return() {
            IsCheckedOut = false;
        }

        public override string ToString() {
            string result = $"\nLibrary Book: {Id}";
            result += Book.ToString();
            result += $"\nAvailable: {!IsCheckedOut}\n";
            return result;
        }
    }
}

