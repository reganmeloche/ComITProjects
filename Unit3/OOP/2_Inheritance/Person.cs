using System;

namespace Unit3
{
    // abstract class - cannot instantiate it
    public class Person
    {
        public string FirstName {get; private set;}
        public string LastName {get; private set;}
        public string FullName {
            get {
                return FirstName + " " + LastName;
            }
        }

        public DateTime DateOfBirth { get; private set; }

        public int Age {
            get {
                int result = DateTime.Now.Year - DateOfBirth.Year;
                if (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear) {
                    result -= 1;
                }
                return result;
            }
        }

        public Person(string firstName, string lastName, DateTime dateOfBirth) {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public override string ToString() {
            return $"Name: {FullName}\nDOB: {DateOfBirth} ({Age})";
        }

        // Not allowed to have abstract method in non-abstract class
        // The class would be incomplete
        //public abstract string GenerateResume();
    }

    public class Programmer : Person {
        public string FavouriteLanguage {get; private set;}
        public string ComputerType {get;set;}
        public int YearsExperience {get; private set;}

        public Programmer(
            string firstName, string lastName, DateTime dateOfBirth,
            string favouriteLanguage, string computerType, int yearsExperience
            ) :base(firstName, lastName, dateOfBirth) 
        {
            // Cannot set FirstName in here, since it is private. Need to change to protected
            YearsExperience = yearsExperience;
            FavouriteLanguage = favouriteLanguage;
            ComputerType = computerType;
        }

        public string GenerateResume() {
            return $@"
Name: {FullName}
Years Experience: {YearsExperience}
Computer Type: {ComputerType}
Favourite Language: {FavouriteLanguage}
            ";
        }
    }

    public class Author : Person {

        public string Publisher {get; private set;}
        public int NumBooks {get; private set;}

        public Author(
            string firstName, 
            string lastName, 
            DateTime dateOfBirth, 
            string publisher, 
            int numBooks) : base(firstName, lastName, dateOfBirth) 
        {
            Publisher = publisher;
            NumBooks = numBooks;
        }

        public void PublishABook() {
            Console.WriteLine($"{FullName} published a book under {Publisher}");
            NumBooks++;
        }

        
    }

}
