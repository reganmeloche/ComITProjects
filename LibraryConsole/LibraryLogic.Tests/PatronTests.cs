using Xunit;
using LibraryLogic;
using System;
using FakeItEasy;

namespace LibraryLogic.UnitTests.Services
{
    public class PatronTests
    {
        [Fact]
        public void Should_CheckoutABook()
        {
            var mockPatron = A.Fake<Patron>();
            var mockLibraryBook = A.Fake<LibraryBook>();
            
            mockPatron.CheckOut(mockLibraryBook);

            Assert.Equal(1, mockPatron.ItemsCheckedOut);
        }

        [Fact]
        public void Should_FailToCheckoutABookDueToMaxLoans()
        {
            var mockPatron = A.Fake<Patron>();
            string message = "";
            bool pass = false;

            for (int i = 0; i < 10; i++) {
                var mockLibraryBook = A.Fake<LibraryBook>();
                mockPatron.CheckOut(mockLibraryBook);
            }

            try {
                var mockLibraryBook = A.Fake<LibraryBook>();
                mockPatron.CheckOut(mockLibraryBook);
            } catch (Exception e) {
                message = e.Message;
                pass = true;
            }

            Assert.Contains("Patron has already checked out the maximum number of books", message);
            Assert.True(pass);
        }

        [Fact]
        public void Should_RenewABook()
        {
            var mockPatron = A.Fake<Patron>();
            var mockLibraryBook = A.Fake<LibraryBook>();
            
            mockPatron.CheckOut(mockLibraryBook);
            mockPatron.Renew(mockLibraryBook);

            Assert.True(true);
        }

        [Fact]
        public void Should_FailToRenewBookDueToNotHavingIt()
        {
            var mockPatron = A.Fake<Patron>();
            string message = "";
            bool pass = false;


            try {
                var mockLibraryBook = A.Fake<LibraryBook>();
                mockPatron.Renew(mockLibraryBook);
            } catch (Exception e) {
                message = e.Message;
                pass = true;
            }

            Assert.Contains("Patron does not have this book out", message);
            Assert.True(pass);
        }

        [Fact]
        public void Should_ReturnABook()
        {
            var mockPatron = A.Fake<Patron>();
            var fakeBook = A.Fake<Book>();
            var mockLibraryBook1 = A.Fake<LibraryBook>(x => x.WithArgumentsForConstructor(() => new LibraryBook(1, fakeBook)));
            var mockLibraryBook2 = A.Fake<LibraryBook>(x => x.WithArgumentsForConstructor(() => new LibraryBook(2, fakeBook)));
            
            mockPatron.CheckOut(mockLibraryBook1);
            mockPatron.CheckOut(mockLibraryBook2);
            mockPatron.Return(mockLibraryBook1);

            Assert.Equal(1, mockPatron.ItemsCheckedOut);
            Assert.Equal(2, mockPatron.CurrentLoans[0].LibraryBook.Id);
        }

        [Fact]
        public void Should_FailToReturnABookDueToNotHavingIt()
        {
            var mockPatron = A.Fake<Patron>();
            string message = "";
            bool pass = false;

            try {
                var mockLibraryBook = A.Fake<LibraryBook>();
                mockPatron.Return(mockLibraryBook);
            } catch (Exception e) {
                message = e.Message;
                pass = true;
            }

            Assert.Contains("Patron does not have this book out", message);
            Assert.True(pass);
        }
     
    }
}