using System;

namespace PetShelterLib
{
    public class Adoption {
        public string AdopterName {get;}
        public string AdopterPhone {get;}
        public DateTime AdoptionDate {get;}
        public Pet AdoptedPet {get;}

        public Adoption(string adopterName, string adopterPhone, Pet adoptedPet) {
            AdopterName = adopterName;
            AdopterPhone = adopterPhone;
            AdoptionDate = DateTime.Now;
            AdoptedPet = adoptedPet;
        }

        public override string ToString() {
            string result = "\n------ Adoption Record ------\n";
            result += $"Adopter: {AdopterName} (ph: {AdopterPhone})\n";
            result += $"Adopted {AdoptedPet.Name} on {AdoptionDate}\n\n";
            return result;
        }
    }
}