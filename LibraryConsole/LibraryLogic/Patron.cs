using System;
using System.Linq;
using System.Collections.Generic;

namespace LibraryLogic
{
    public class Patron : Person
    {

        // Private 
        private readonly ICheckOverdueBooks _overdueChecker = new OverdueChecker();
        private const int MAX_LOANS = 10;
        private const decimal MAX_FINE = 10m;

        // Properties: Maybe I should remove fines
        public long Id { get; private set; }
        private decimal storedFines;
        public decimal TotalFines {
            get {
                return storedFines + this.CalculateFeesOnCurrentLoans();
            }
        }
        public int ItemsCheckedOut { get { return CurrentLoans.Count; } }
        public DateTime JoinDate { get; }
        public List<Loan> CurrentLoans { get; }

        public Patron(long id, string firstName, string lastName, DateTime dateOfBirth) 
            : base(firstName, lastName, dateOfBirth)  {
            Id = id;
            CurrentLoans = new List<Loan>();
            JoinDate = DateTime.Now;
            storedFines = 0m;
        }

        public Loan CheckOut(LibraryBook libraryBook) {
            if (ItemsCheckedOut >= MAX_LOANS) {
                throw new Exception("Patron has already checked out the maximum number of books");
            }

            if (TotalFines > MAX_FINE) {
                throw new Exception("Patron must pay fine before checking out more books.");
            }

            libraryBook.CheckOut();
            var newLoan = new Loan(libraryBook, _overdueChecker);
            CurrentLoans.Add(newLoan);
            return newLoan;
        }

        public void Renew(LibraryBook libraryBook) {
            var loan = CurrentLoans.Find(x => x.LibraryBook.Id == libraryBook.Id);
            if (loan == null) {
                throw new Exception("Patron does not have this book out");
            }
            
            loan.Renew();
        }

        public void Return(LibraryBook libraryBook) {
            var loanIndex = CurrentLoans.FindIndex(x => x.LibraryBook.Id == libraryBook.Id);

            if (loanIndex < 0) {
                throw new Exception("Patron does not have this book out");
            }

            var loan = CurrentLoans[loanIndex];

            if (loan != null) {
                storedFines += loan.Fees;
                CurrentLoans.RemoveAt(loanIndex);
            }
        }

        public decimal CalculateFeesOnCurrentLoans() {
            decimal result = 0m;
            foreach (var loan in CurrentLoans) {
                result += loan.Fees;
            }
            return result;
        }
        public void PayFine(decimal amount) {
            storedFines -= amount;
            storedFines = Math.Max(TotalFines, 0);
        }

        public override string ToString() {
            string res = $"\nPatron: {Id}";
            res += base.ToString();
            res += $"\nCurrent Loans: {CurrentLoans.Count}\n";
            return res;
        }

    }
}
