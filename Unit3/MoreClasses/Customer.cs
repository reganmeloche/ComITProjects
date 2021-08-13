using System;

namespace Unit3Examples
{
    public class Customer {
        /*** Data Members ***/
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string FullName {
            get {
                string fullName = $"{FirstName} {LastName}";
                return fullName;
            }
        }

        public long Id {get;set;}
        public string Email {get;set;}
        public DateTime DateOfBirth {get;set;}

        public int Age { 
            get {
                DateTime currentDate = DateTime.Now;

                int age = currentDate.Year - DateOfBirth.Year;

                if (currentDate.DayOfYear < DateOfBirth.DayOfYear) {
                    age--;
                }

                return age;
            } 
        }

        /*** Methods ***/
        public void PrintGreeting() {
            Console.WriteLine($"Hello {FullName}!");
        }

        public void SendEmail(string subject, string bodyText) {
            Console.WriteLine($"Email was sent to {Email}");
            // Generates an email 
        }


    }


}
