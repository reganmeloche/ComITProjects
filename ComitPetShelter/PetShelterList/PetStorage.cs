using System;
using System.Collections.Generic;
using PetShelterLib;

namespace PetShelterList {

    public class PetStorageList : IPetStorage {
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

}