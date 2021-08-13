using System;
using System.Collections.Generic;
using LibraryLogic;
using FakeItEasy;

namespace LibraryConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            /*** SETUP ***/
            #region Setup
            // Create the fake books
            var books = MockBuilder.BuildBooks();
            var libraryBooks = MockBuilder.BuildLibraryBooks(books);
            Console.WriteLine($"Library Books: ({libraryBooks.Count})");
            foreach (var lb in libraryBooks) {
                Console.Write(lb.ToString());
            }

            Console.WriteLine("------------------------");
            Console.WriteLine("------------------------");

            // Create a fake patron
            var patrons = MockBuilder.BuildPatrons();
            Console.WriteLine($"Patrons: ({patrons.Count})");
            foreach (var p in patrons) {
                Console.Write(p.ToString());
            }

            // Set up the patrons
            var patron1 = patrons[0];
            var patron2 = patrons[1];
            var patron3 = patrons[2];

            // Set up the library books
            var lb1 = libraryBooks[0];
            var lb2 = libraryBooks[1];
            var lb3 = libraryBooks[2];
            var lb4 = libraryBooks[3];

            #endregion


 

            /*** ACTIONS ***/

            // p1 checkout book1 -> success
            var loan1 = patron1.CheckOut(lb1);

            loan1.Renew();

            // p2 checkout book2 -> success
            var loan2 = patron2.CheckOut(lb2);

            // p1 checkout book2 -> Fails since book already checked out
            try {
                var loan3 = patron1.CheckOut(lb2);
            } catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }

            // p1 checkout book3 - success
            var loan4 = patron1.CheckOut(lb3);

            // p2 return book2 -> success
            patron2.Return(lb2);

            // p2 return book2 again -> fail - book not checked out
            try {
                patron2.Return(lb2);
            } catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }

            // p2 return book1 -> fail - book belongs to another patron
            try {
                patron2.Return(lb2);
            } catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }

            // p1 renew lb1
            patron1.Renew(lb1);

            Console.WriteLine("Finished!");

            foreach (var p in patrons) {
                Console.Write(p.ToString());
            }

            var loans = new List<Loan>() { loan1, loan2, loan4 };
            foreach (var loan in loans) {
                Console.Write(loan.ToString());
            }
            
        }

    }
}
