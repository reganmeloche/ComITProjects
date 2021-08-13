using System;

namespace BloodBankLib
{
    public class Donor : Person {
        static readonly int MAX_DAYS_TO_DONATE = 56;
        public BloodType BloodType {get; private set;}
        public Guid CardId {get;}

        public DateTime LastDonationDate {get;private set;}
        public int TimesDonated {get; private set;}

        public Donor(string firstName, string lastName, DateTime dateOfBirth, BloodType bloodType) 
            : base(firstName, lastName, dateOfBirth) 
        {
            CardId = Guid.NewGuid();
            BloodType = bloodType;
        }

        public Donation Donate() {
            if ((DateTime.Now - LastDonationDate).Days > MAX_DAYS_TO_DONATE) {
                LastDonationDate = DateTime.Now;
                TimesDonated++;
                return new Donation(this);
            } else {
                throw new Exception("Donations can only be made every 56 days");
            }
        }


    }
}
