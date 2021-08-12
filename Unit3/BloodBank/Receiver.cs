using System;
using System.Collections.Generic;

namespace BloodBankTest
{
    class Receiver : Person {
        public BloodType _bloodType { get; private set; }

        public Receiver(
            string firstNameArg, 
            string lastNameArg, 
            DateTime dateOfBirthArg, 
            BloodType bloodTypeArg
        ) : base(firstNameArg, lastNameArg, dateOfBirthArg) {
            _bloodType = bloodTypeArg;
        }

        public void PrintDetails() {
            Console.WriteLine($"------Receiver-------");
            Console.WriteLine($"Name: {_firstName} {_lastName}");
            Console.WriteLine($"DOB: {_dateOfBirth}");
        }
    }

}