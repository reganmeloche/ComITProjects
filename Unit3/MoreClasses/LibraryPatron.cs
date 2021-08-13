using System; 

namespace Unit3Examples
{
    public class LibraryPatron {
        // Constructor
        public LibraryPatron(int patronId) {
            PatronId = patronId;
            FinesOwing = 0;
            BooksCheckedOut = 0;
        }

        // Public Properties (Data)
        // public int PatronId {get; set;}
        // public double FinesOwing {get; set;}
        // public int BooksCheckedOut {get;set;}

        // Encapsulated Properties (Data)
        public int PatronId {get;} // Read-only property
        private double FinesOwing; // Private field
        public int BooksCheckedOut {get; private set;} // Property: Public get, private set


        // Methods
        public void CheckoutBook(string bookName) {
            if (BooksCheckedOut < 5) {
                BooksCheckedOut++;
                Console.WriteLine($"Patron {PatronId} has checked out {bookName}\n");
            } else {
                Console.WriteLine($"Patron {PatronId} cannot check out more than 5 books\n");
            }    
        }

        // Note: Since this is a simplified example, we are not specifying any particular book being returned
        public void ReturnBook() {
            if (BooksCheckedOut > 0) {
                BooksCheckedOut--;
            } else {
                Console.WriteLine("Patron has no books to return.\n");
            }
        }

        public void AddOverdueCharge() {
            // Note: Assume there is a set fine amount of 1.60 that gets incurred
            FinesOwing += 1.60;
            Console.WriteLine($"Patron {PatronId} has incurred a fine\n");
        }

        public void PayFine(double amountPaid) {
            if (amountPaid >= FinesOwing) {
                double change = amountPaid - FinesOwing;
                FinesOwing = 0;
                // Note: ToString("N2") allows us to display a string with 2 numbers after the decimal
                Console.WriteLine($"Fines are all paid. Your change is {change.ToString("N2")}\n");
            } else {
                FinesOwing -= amountPaid;
                Console.WriteLine($"${amountPaid.ToString("N2")} has been paid towards the total fine\n");
            }
        }

        public void PrintDetails() {
            Console.WriteLine($"\n--- Patron {PatronId} ---");
            Console.WriteLine($"Books out: {BooksCheckedOut}/5");
            Console.WriteLine($"Fees: ${FinesOwing.ToString("N2")}");
            Console.WriteLine("-----------------\n");
        }
    }

}