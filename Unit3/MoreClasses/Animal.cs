using System;

namespace Unit3Examples
{
    public class Animal
    {
        // Id, name, species, breed, dateOfBirth, sex, isAdopted, intakeDate,
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public DateTime DateOfBirth { get; set; }
        public char Sex { get; set; }
        public bool IsAdopted { get; set; }
        public DateTime IntakeDate { get; set; }
        public bool SpayedNeutered { get; set; }
        
    }
}