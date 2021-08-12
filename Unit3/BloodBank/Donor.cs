using System;
using System.Collections.Generic;

namespace BloodBankTest
{
   
    class Donor : Person {
        BloodType _bloodType;
        DateTime _lastDonationDate;
        int _numTimesDonated;

        public Donor(
            string firstNameArg, 
            string lastNameArg, 
            DateTime dateOfBirthArg, 
            BloodType bloodTypeArg
        ) : base(firstNameArg, lastNameArg, dateOfBirthArg) {
            _bloodType = bloodTypeArg;
            _numTimesDonated = 0;
        }

        public void TryToDonateTo(Receiver receiver) {
            
            // Check if donor is eligible
            if (IsEligibleToDonate()) {
                // Check if donor blood type is compatible with receiver blood type
                bool canDonate = _bloodType.CanDonateTo(receiver._bloodType);
                if (canDonate) {
                    // Performing the donation
                    _numTimesDonated++;
                    _lastDonationDate = DateTime.Now;
                    Console.WriteLine($"Donation made by {_firstName} to {receiver._firstName}");
                }

            } else {
                throw new Exception("Donor is ineligible to donate");
            }
            
            
            // Update the donor values accordingly
            // Bonus: If this is the donor's fifth donation, then print a "Congrats" message

        }

        // Donor is eligible to donate if its been at least 56 days since last donation
        public bool IsEligibleToDonate() {
            if ((DateTime.Now - _lastDonationDate).Days > 56) {
                return true;
            } else {
                return false;
            }
        }


        public void PrintDetails() {
            Console.WriteLine($"------Donor-------");
            Console.WriteLine($"Name: {_firstName} {_lastName}");
            Console.WriteLine($"DOB: {_dateOfBirth}");
            Console.WriteLine($"NumTimes Donated: {_numTimesDonated}\n");
        }

    }
}