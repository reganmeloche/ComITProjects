using System;
using System.Collections.Generic;

namespace PetShelterLib
{
    public class Shelter {
        IPetStorage _petStorage;
        IAdoptionStorage _adoptionStorage;
        IPrinter _printer;
        int _capacity;

        public Shelter(int capacityArg, IPetStorage myPetStorage, IAdoptionStorage myAdoptionStorage, IPrinter myPrinter) {
            _petStorage = myPetStorage;
            _adoptionStorage = myAdoptionStorage;
            _printer = myPrinter;
            _capacity = capacityArg;
        }

        public void ReceiveNewPet(Pet newPet) {
            if (_petStorage.NumberOfPets() < _capacity) {
                _petStorage.Save(newPet);
                _printer.Print("Received new Pet!");
            } else {
                throw new Exception("Sorry, shelter is full.");
            }
        }


        public List<Pet> GetAllPets() {
            return _petStorage.GetAll();
        }

        public List<Adoption> GetAllAdoptions() {
            return _adoptionStorage.GetAll();
        }



        public void AdoptAPet(string nameRequested, string nameOfAdopter, string phoneOfAdopter) {
            bool foundPet = false;

            var allPets = _petStorage.GetAll();
            foreach (var pet in allPets) {
                if (nameRequested == pet.Name) {
                    foundPet = true;
                    pet.Adopt();
                    var newAdoptionRecord = new Adoption(nameOfAdopter, phoneOfAdopter, pet);
                    _adoptionStorage.Save(newAdoptionRecord);
                    _petStorage.Remove(pet);
                    _printer.Print("Adopted a pet");
                    break;
                }
            }

            if (foundPet == false) {
                _printer.Print("No pet by that name was found");
            }
            
        }

    }
}