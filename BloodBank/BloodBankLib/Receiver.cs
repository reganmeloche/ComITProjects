using System;

namespace BloodBankLib
{
    public class Receiver : Person
    {
        public BloodType BloodType {get; private set;}
        public Guid CardId {get;}

        public Receiver(string firstName, string lastName, DateTime dateOfBirth, BloodType bloodType) 
            : base(firstName, lastName, dateOfBirth) 
        {
            BloodType = bloodType;
            CardId = Guid.NewGuid();
        }
    }
}
