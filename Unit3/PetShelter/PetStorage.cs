using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShelter
{
    interface IPetStorage {
        int NumberOfPets();

        void Save(Pet pet);

        void Remove(Pet pet);

        List<Pet> GetAll(); 

    }

    class PetStorageList : IPetStorage {
        List<Pet> _petList;

        public PetStorageList() {
            _petList = new List<Pet>();
        }

        public int NumberOfPets() {
            return _petList.Count;
        }

        public void Save(Pet pet) {
            _petList.Add(pet);
        }

        public void Remove(Pet petToRemove) {
            for (int i = 0; i < _petList.Count; i++) {
                var pet = _petList[i];
                if (pet.Name == petToRemove.Name) {
                    _petList.RemoveAt(i);
                    break;
                }
            }

            // Shorter way:
            // var petIndex = _petList.FindIndex(x => x.Name == pet.Name);
            // _petList.RemoveAt(petIndex);
        }

        public List<Pet> GetAll() {
            return _petList;
        }
    }

    // Note: This is a valid implementation. It fulfills the contract set out by the interface, so it will compile
    // But it does not behave properly. We will look at DB implementations in unit 4 and 5
    class PetStorageDB : IPetStorage {
        public int NumberOfPets() {
            return 1;
        }

        public void Save(Pet pet) {
        }

        public void Remove(Pet petToRemove) {
        }

        public List<Pet> GetAll() {
            return new List<Pet>();
        }
    }
}