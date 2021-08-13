using System;
using System.Text;

namespace BloodBankLib
{
    public class Donation {
        public Guid DonationId { get; }
        public Donor Donor {get; private set;}
        public DateTime DateTaken {get;private set;}
        public int DaysOld {
            get {
                return (DateTime.Now - DateTaken).Days;
            }
        }
        public bool Verified {get;private set;}

        public Donation(Donor donor) {
            DonationId = Guid.NewGuid();
            Donor = donor;
            DateTaken = DateTime.Now;
            Verified = false;
        }

        public Donation(Guid donationId, Donor donor, DateTime donationDate, bool verified) {
            DonationId = donationId;
            Donor = donor;
            DateTaken = donationDate;
            Verified = verified;
        }

        public void Verify() {
            Verified = true;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append($"\n----Donation----");
            sb.Append($"\nDonor: {Donor.FullName}");
            sb.Append($"\nBlood Type: {Donor.BloodType.ToString()}");
            sb.Append($"\nDate Taken: {DateTaken}");
            sb.Append($"\n----------------");
            return sb.ToString();
        }
    }
}

