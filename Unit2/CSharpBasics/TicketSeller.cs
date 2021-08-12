using System;

namespace unit2
{
    class TicketSeller
    {    
        public static void SellTicket() {
            Console.WriteLine("What is the age of the buyer? ");

            string stringAge = Console.ReadLine();
            int age = Convert.ToInt32(stringAge);
            decimal price = 0m;

            if (age <= 5) {
                price = 0m;
            }
            else if (age >= 6 && age <= 14) {
                price = 8.99m;
            } 
            else if (age > 14 && age <= 65) {
                price = 12.99m;
            }
            else {
                price = 7.99m;
            }

            Console.WriteLine("Ticket Price: " + price);
        }

    
        public static void SellTickets2() {
            Console.WriteLine("What is the age of the buyer? ");

            int age = Convert.ToInt32(Console.ReadLine());


            if(age>=0 && age<=5)
            {
                Console.WriteLine(" We dont charge for children below 5");
            }
            else if(age>=6 && age <=14)
            {
                Console.WriteLine(" The price is: $8.99 ");
            }
            else if(age>=15 && age<=65)
            {
                Console.WriteLine(" The price is: $12.99 ");
            }
            else if(age>65 && age <=150)
            {
                Console.WriteLine(" The price is: $7.99 ");
            }
            else
            {
                Console.WriteLine(" Please enter a valid value");
            }
        }
    }
}


