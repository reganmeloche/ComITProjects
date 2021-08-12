using System;

namespace PetShelter
{
    class Adoption {
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

        public void PrintDetails() {
            Console.WriteLine("\n------ Adoption Record ------");
            Console.WriteLine($"Adopter: {AdopterName} (ph: {AdopterPhone})");
            Console.WriteLine($"Adopted {AdoptedPet.Name} on  {AdoptionDate}\n");
        }
    }
}