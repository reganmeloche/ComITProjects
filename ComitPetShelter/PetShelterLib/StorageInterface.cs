using System;
using System.Collections.Generic;

namespace PetShelterLib {

    public interface IPetStorage {
        int NumberOfPets();

        void Save(Pet pet);

        void Remove(Pet pet);

        List<Pet> GetAll(); 

    }

    public interface IAdoptionStorage {
        List<Adoption> GetAll();

        void Save(Adoption adoptionRecord);
    }
}