using System;

namespace LibraryLogic
{
    public class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName { get { return FirstName + " " + LastName; } }
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
            return $"\nName: {FullName}\nDoB: {DateOfBirth}";
        }

    }
}
 