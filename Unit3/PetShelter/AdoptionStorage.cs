using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShelter
{
    interface IAdoptionStorage {
        // Define the methods here

    }

    class AdoptionStorageList : IAdoptionStorage {
        List<Adoption> _adoptionList;

        public AdoptionStorageList() {
            _adoptionList = new List<Adoption>();
        }

        // Implementations of the interface functions go here

    }
}