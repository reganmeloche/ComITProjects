using System;
using System.Collections.Generic;

namespace BloodBankTest
{
    class Person {
        public string _firstName {get; private set;}
        protected string _lastName;
        protected DateTime _dateOfBirth;

        // Base constructor
        public Person(string firstName, string lastName, DateTime dateOfBirth) {
            if (firstName.Length > 50) {
                throw new Exception("First name is too long!");
            }

            if (lastName.Length > 50) {
                throw new Exception("First name is too long!");
            }

            _firstName = firstName;
            _lastName = lastName;
            _dateOfBirth = dateOfBirth;
        }

    }


}