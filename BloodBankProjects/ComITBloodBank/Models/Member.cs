using System;

namespace BloodClinic.Models
{
    public abstract class Member
    {
        public Member(string firstName, string lastName, DateTime dateOfBirth, BloodType memberBloodType, string email) {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            MemberBloodType = memberBloodType;
            Email = email;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth {get;set;}
        public BloodType MemberBloodType { get; set; }
        public string Email { get; set; } 


        public string FullName {
            get {
                return LastName + ", "  + FirstName;
            }
        }
    }
}