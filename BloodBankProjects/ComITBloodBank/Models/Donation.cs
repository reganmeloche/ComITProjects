using System;

namespace BloodClinic.Models
{
    public class Donation
    {
        public Guid Id { get; set; }
        public Donor Donor { get; set; }
        public DateTime DonationDate { get; set; }


        public override string ToString()
        {
            string details = "----- DONATION -----\n";
            details += $"Donor: {Donor.Id}\n";
            details += $"Blood Type: {Donor.MemberBloodType.ToString()}\n";
            details += $"Donation Date: {DonationDate}\n"; 
            return details;
        }
    }
}