using Xunit;
using LibraryLogic;
using System;
using FakeItEasy;

namespace LibraryLogic.UnitTests.Services
{
    public class LibraryBookTests
    {
        [Fact]
        public void Should_CheckoutSuccessfully()
        {
            var mockBook = A.Fake<LibraryBook>();

            try {
                mockBook.CheckOut();
            } catch (Exception) {
                Assert.True(false);
            }

            Assert.True(true);
        }

        [Fact]
        public void Should_FailCheckout()
        {
            var mockBook = A.Fake<LibraryBook>();
            bool pass = false;
            string message = "";

            try {
                mockBook.CheckOut();
                mockBook.CheckOut();
            } catch (Exception e) {
                message = e.Message;
                pass = true;
            }

            Assert.True(pass);
            Assert.Contains("Library book is already checked out.", message);

        }
    }
}