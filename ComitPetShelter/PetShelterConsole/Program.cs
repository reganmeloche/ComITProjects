using System;

using PetShelterLib;
using PetShelterList;

namespace PetShelterConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var cat1 = new Cat("Aya", 1, true, false, "white");
            var dog1 = new Dog("Jaina", 1, true, 'M',"Blue Heeler");
            var dog2 = new Dog("Spot", 1, true, 'S',"Chihuahua");
            var mouse1 = new Mouse("Ron", 1, false);

            // Instantiate a PetStorageList and "inject" it into the PetShelter
            var petStorage = new PetStorageList();
            var adoptionStorage = new AdoptionStorageList();
            var consolePrinter = new ConsolePrinter();

            var shelter = new Shelter(10, petStorage, adoptionStorage, consolePrinter);

            shelter.ReceiveNewPet(cat1);
            shelter.ReceiveNewPet(dog1);
            shelter.ReceiveNewPet(dog2);
            shelter.ReceiveNewPet(mouse1);

            var allPets = shelter.GetAllPets();
            Console.WriteLine("\n----- ALL PETS -----");
            foreach (var pet in allPets) {
                Console.WriteLine(pet.ToString());
            }
            Console.WriteLine("----------------\n");

            Console.WriteLine("Enter your name: ");
            string adopterName = Console.ReadLine();

            Console.WriteLine("Enter your phone number: ");
            string adopterPhone = Console.ReadLine();

            while (true) {
                Console.WriteLine("\nEnter the name of the pet you want to adopt. Enter 'q' to exit: ");
                string petNameInput = Console.ReadLine();

                if (petNameInput == "q") { break; }

                shelter.AdoptAPet(petNameInput, adopterName, adopterPhone);
                
                allPets = shelter.GetAllPets();
                Console.WriteLine("\n----- ALL PETS -----");
                foreach (var pet in allPets) {
                    Console.WriteLine(pet.ToString());
                }
                Console.WriteLine("----------------\n");
            }

            var allAdoptions = shelter.GetAllAdoptions();

            Console.WriteLine("\n----- ALL ADOPTIONS -----");
            foreach (var adoption in allAdoptions) {
                Console.WriteLine(adoption.ToString());
            }
            Console.WriteLine("----------------\n");
        }
    }
}
