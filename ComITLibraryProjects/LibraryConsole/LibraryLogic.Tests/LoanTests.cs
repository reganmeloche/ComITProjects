using Xunit;
using LibraryLogic;
using System;
using FakeItEasy;

namespace LibraryLogic.UnitTests.Services
{
    public class LoanTests
    {
        [Fact]
        public void Should_RenewABook()
        {
            var mockLoan = A.Fake<Loan>();
            DateTime initialDueDate = mockLoan.DueDate;

            mockLoan.Renew();
            DateTime newDueDate = mockLoan.DueDate;

            int dueDateDifference = (newDueDate - initialDueDate).Days; 
            Assert.Equal(10, dueDateDifference);
        }

        [Fact]
        public void Should_RenewABookThreeTimes()
        {
            var mockLoan = A.Fake<Loan>();
            DateTime initialDueDate = mockLoan.DueDate;

            mockLoan.Renew();
            mockLoan.Renew();
            mockLoan.Renew();
            DateTime newDueDate = mockLoan.DueDate;

            int dueDateDifference = (newDueDate - initialDueDate).Days; 
            Assert.Equal(30, dueDateDifference);
        }

        [Fact]
        public void Should_FailRenewalDueToMaxRenews()
        {
            var mockLoan = A.Fake<Loan>();
            DateTime initialDueDate = mockLoan.DueDate;
            bool pass = false;
            string message = "";

            mockLoan.Renew();
            mockLoan.Renew();
            mockLoan.Renew();

            try {
                mockLoan.Renew();
            } catch (Exception e) {
                message = e.Message;
                pass = true;
            }
            
            Assert.True(pass);
            Assert.Contains("Cannot renew more than 3 times", message);
        }
    
        [Fact]
        public void Should_FailRenewalDueToOverdue() {
            var fakeLibraryBook = A.Fake<LibraryBook>();
            var fakeOverdueChecker = new FakeOverDueChecker();
            var loan = new Loan(fakeLibraryBook, fakeOverdueChecker);

            bool pass = false;
            string message = "";

            try {
                loan.Renew();
            } catch (Exception e) {
                message = e.Message;
                pass = true;
            }
            
            Assert.True(pass);
            Assert.Contains("Cannot renew an overdue book", message);
        }
    }

    public class FakeOverDueChecker : ICheckOverdueBooks {
        public bool IsOverdue(DateTime dueDate) {
            return true;
        }
    }
}