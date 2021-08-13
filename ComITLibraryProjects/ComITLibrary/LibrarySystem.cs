using System;
using System.Collections.Generic;

using ComitLibrary.Storage;
using ComitLibrary.Models;

namespace ComitLibrary
{

    public class LibrarySystem
    {
        /*** CONSTRUCTOR ***/
        public LibrarySystem(IStoreBooks bookStorage, IStorePatrons patronStorage, IStoreLoans loanStorage) {
            // Init storage using Dependency Injection
            _bookStorage = bookStorage;
            _patronStorage = patronStorage;
            _loanStorage = loanStorage;

            // Create 3 sample books
            _bookStorage.Create(new Book(123, "The Hobbit", "Tolkien"));
            _bookStorage.Create(new Book(999, "Handmaids Tale", "Atwood"));
            _bookStorage.Create(new Book(76348, "Slaughterhouse five", "Vonnegut"));

            // Create 2 sample patrons
            _patronStorage.Create(new Patron(11118888, "Pablo", "Listingart"));
            _patronStorage.Create(new Patron(22227777, "Jesselyn", "Popoff"));
        }

        /*** STORAGE ***/
        private readonly IStoreBooks _bookStorage;
        private readonly IStorePatrons _patronStorage;
        private readonly IStoreLoans _loanStorage;
        

        /*** METHODS ***/
        public List<Book> SearchForBook(string titleToSearch) {
            return _bookStorage.GetByTitle(titleToSearch);
        }

        public List<Book> GetAllBooks() {
            return _bookStorage.GetAll();
        }

        public Book AddNewBook(Book newBook) {
            _bookStorage.Create(newBook);
            return newBook;
        }

        public List<Patron> GetAllPatrons() {
            return _patronStorage.GetAll();
        }

        public Loan CheckoutBook(long patronId, long bookId) {
            var patron = _patronStorage.GetById(patronId);
            patron.CheckOutBook();

            var book = _bookStorage.GetById(bookId);
            book.CheckOut();

            var loan = new Loan(patron, book);
            _loanStorage.Create(loan);
            return loan;
        }

        public void ReturnBook(long patronId, long bookId) {
            var patron = _patronStorage.GetById(patronId);
            patron.CheckInBook();

            var book = _bookStorage.GetById(bookId);
            book.CheckIn();

            var loan = _loanStorage.GetByPatronIdAndBookId(patronId, bookId);
            loan.IsReturned = true;
        }
    }
}