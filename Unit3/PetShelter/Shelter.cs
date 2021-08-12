using System;
using System.Collections.Generic;

namespace PetShelter
{
    class Shelter {
        IPetStorage _petStorage;
    
        // Replace this with IAdoptionStorage
        // Will need to be replaced everywhere in the class
        List<Adoption> _adoptionList;


        int _numAdoptions;
        int _capacity;

        public Shelter(int capacityArg, IPetStorage myPetStorage) {
            _petStorage = myPetStorage;
            // Pass an IAdoptionStorage object into the constructor
            _adoptionList = new List<Adoption>();
            _numAdoptions = 0;
            _capacity = capacityArg;
        }

        public void ReceiveNewPet(Pet newPet) {
            if (_petStorage.NumberOfPets() < _capacity) {
                _petStorage.Save(newPet);
                Console.WriteLine("Received a new pet!");
            } else {
                throw new Exception("Sorry, shelter is full.");
            }
        }

        public void ListAllPets() {
            Console.WriteLine("\n----- ALL PETS -----");
            foreach (var pet in _petStorage.GetAll()) {
                pet.PrintDetails();
            }
            Console.WriteLine("----------------\n");
        }

        public void ListAllAdoptions() {
            Console.WriteLine("\n----- ALL ADOPTIONS -----");
            foreach (var adoption in _adoptionList) {
                adoption.PrintDetails();
            }
            Console.WriteLine("----------------\n");
        }

        public void AdoptAPet(string nameRequested, string nameOfAdopter, string phoneOfAdopter) {
            bool foundPet = false;

            var allPets = _petStorage.GetAll();
            foreach (var pet in allPets) {
                if (nameRequested == pet.Name) {
                    foundPet = true;
                    pet.Adopt();
                    var newAdoptionRecord = new Adoption(nameOfAdopter, phoneOfAdopter, pet);
                    _adoptionList.Add(newAdoptionRecord);
                    _petStorage.Remove(pet);
                    break;
                }
            }

            if (foundPet == false) {
                Console.WriteLine("No pet by that name was found");
            }

        }

    }
}