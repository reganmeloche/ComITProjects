using System;
using Xunit;

using PetShelterLib;
using PetShelterList;

namespace PetShelterTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
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

            var petsAtShelter = shelter.GetAllPets();
            // petsAtShelter should have 4 elements

            var count = petsAtShelter.Count;

            Assert.Equal(4, count);
        }
    }
}
