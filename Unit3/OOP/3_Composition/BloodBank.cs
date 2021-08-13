using System;
using System.Collections.Generic;

namespace Unit3
{
    public class BloodType
    {
        private readonly List<string> _validTypes = new List<string>() {"A", "B", "AB", "O"};
        public string Abo {get; private set;}
        public char Sign {get; private set;}

        public BloodType(string abo, char sign) {
            if (!_validTypes.Contains(abo)) {
                throw new Exception("Invalid blood type");
            }

            if (sign != '+' && sign != '-') {
                throw new Exception("Invalid blood type sign");
            }

            Abo = abo;
            Sign = sign;
        }

        public bool CanDonateTo(BloodType other) {
            // O- can donate to anyone/ O+ can donate to any +
            if (Abo == "O") {
                return (Sign == '-' || other.Sign == '+');
            }

            if (Abo == "A" || Abo == "B") {
                if (other.Abo == Abo || other.Abo == "AB") {
                    return (Sign == '-' || other.Sign == '+');
                }
            }

            if (Abo == "AB") {
                if (other.Abo == Abo) {
                    return (Sign == '-' || other.Sign == '+');
                }
            }
            
            return false;
        }

        public bool CanReceiveFrom(BloodType other) {
            return other.CanDonateTo(this);
        }
    }

    public class Donor : Person {
        public BloodType BloodType {get; private set;}

        public DateTime LastDonationDate {get;private set;}
        public int TimesDonated {get; private set;}

        public Donor(string firstName, string lastName, DateTime dateOfBirth, BloodType bloodType) 
            : base(firstName, lastName, dateOfBirth) 
        {
            BloodType = bloodType;
        }

        public StoredBlood Donate() {
            LastDonationDate = DateTime.Now;
            TimesDonated++;
            return new StoredBlood(this);
        }

    }

    public class StoredBlood {
        public Donor Donor {get; private set;}
        public DateTime DateTaken {get;private set;}
        public int DaysOld {
            get {
                return (DateTime.Now - DateTaken).Days;
            }
        }
        public bool Verified {get;private set;}

        public StoredBlood(Donor donor) {
            Donor = donor;
            DateTaken = DateTime.Now;
            Verified = false;
        }
    }
}
