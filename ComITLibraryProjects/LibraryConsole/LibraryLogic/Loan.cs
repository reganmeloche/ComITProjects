using System;
using System.Collections.Generic;

namespace LibraryLogic
{
    public class Loan
    {
        private readonly ICheckOverdueBooks _overdueChecker;

        // Private constants
        private const int DAYS_ON_LOAN = 20;
        private const int EXTRA_DAYS_FOR_RENEWAL = 10;
        private const int MAX_RENEWS = 3;
        private const decimal FEE_PER_DAY = 0.5m;

        // Properties
        public LibraryBook LibraryBook { get; private set; }
        public DateTime CheckoutDate { get; private set; }
        public DateTime DueDate { get; private set; }
        public int TimesRenewed { get; private set; }
        private List<DateTime> _daysFeesCalculated = new List<DateTime>();
        public decimal Fees { 
            get {  
                updateFeeDays();
                return _daysFeesCalculated.Count * FEE_PER_DAY; 
            } 
        }

        // Constructor to create a loan
        public Loan(LibraryBook libraryBook, ICheckOverdueBooks overdueChecker) {
            _overdueChecker = overdueChecker;

            LibraryBook = libraryBook;
            CheckoutDate = DateTime.Now;
            DueDate = DateTime.Now.AddDays(DAYS_ON_LOAN);
            TimesRenewed = 0;
        }

        // Renew an existing loan
        public void Renew() {
            if (TimesRenewed >= MAX_RENEWS) {
                throw new Exception("Cannot renew more than 3 times");
            }

            if (_overdueChecker.IsOverdue(DueDate)) {
                throw new Exception("Cannot renew an overdue book");
            }
            
            TimesRenewed++;
            DueDate = DueDate.AddDays(EXTRA_DAYS_FOR_RENEWAL);
        }

        // Tricky one - fees will be left as a bonus
        private void updateFeeDays() {
            int daysOverdue = (DateTime.Now - DueDate).Days; 

            for (int i = 1; i < daysOverdue; i++) {
                var nextDay = DateTime.Now.AddDays(i);

                var zeroedDay = Utilities.ZeroDate(nextDay);

                if (!_daysFeesCalculated.Contains(zeroedDay)) {
                    _daysFeesCalculated.Add(zeroedDay);
                }
            }
        }

        public override string ToString() {
            return $"\nLoan Info:\nLibrary Book Id: {LibraryBook.Id}\n...\n";
        }

    }
}

