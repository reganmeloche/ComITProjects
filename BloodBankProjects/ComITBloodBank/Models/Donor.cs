using System;

namespace BloodClinic.Models
{
    public class Donor : Member
    {
        public Donor(string firstName, string lastName, DateTime dateOfBirth, BloodType memberBloodType, string email) 
            : base(firstName, lastName, dateOfBirth, memberBloodType, email) {
            LastDonatedDate = DateTime.MinValue;
            NumTimesDonated = 0;
        }

        public Donor(Guid id, string firstName, string lastName, BloodType bloodType) 
            : base(firstName, lastName, new DateTime(), bloodType, "") {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            MemberBloodType = bloodType;
        }

        public DateTime LastDonatedDate { get; private set; }
        public int NumTimesDonated { get; private set; }

        public void Donate() {
            if ((DateTime.Now - LastDonatedDate).Days < 40) {
                throw new Exception("Donor cannot donate yet.");
            }

            LastDonatedDate = DateTime.Now;
            NumTimesDonated++;
        }

        public override string ToString() {
            string details = "----- DONOR -----\n";
            details += $"Id: {Id}\n";
            details += $"Name: {FullName}\n";
            details += $"Blood Type: {MemberBloodType.Letter}{MemberBloodType.Sign}\n";
            details += $"Last Donation Date: {LastDonatedDate}\n"; 
            return details;
        }
    }
}