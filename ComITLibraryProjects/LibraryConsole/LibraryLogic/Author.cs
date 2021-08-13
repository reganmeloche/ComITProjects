using System;

namespace LibraryLogic
{
    public class Author : Person
    {
        public Author(string firstName, string lastName, DateTime dateOfBirth) 
            : base(firstName, lastName, dateOfBirth) {}

    }
}
