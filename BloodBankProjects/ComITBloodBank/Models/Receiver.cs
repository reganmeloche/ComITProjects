using System;

namespace BloodClinic.Models
{
    public class Receiver : Member
    {
        public Receiver(string firstName, string lastName, DateTime dateOfBirth, BloodType memberBloodType, string email)
            : base(firstName, lastName, dateOfBirth, memberBloodType, email) 
        {
            LastReceivedDate = DateTime.MinValue;
        }

        public DateTime LastReceivedDate { get; set; }


        public override string ToString() {
            string details = "----- RECEIVER -----\n";
            details += $"Id: {Id}\n";
            details += $"Name: {FullName}\n";
            details += $"Blood Type: {MemberBloodType.Letter}{MemberBloodType.Sign}\n";
            details += $"Last Received Date: {LastReceivedDate}\n"; 
            return details;
        }
    }
}