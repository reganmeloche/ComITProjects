using System;

namespace PetShelterLib
{
    public abstract class Pet {
        public string Name {get; private set;}
        protected int Age;
        protected bool IsAdopted;
        protected bool IsSpayedNeutered;

        public Pet(string nameArg, int ageArg, bool snArg) {
            Name = nameArg;
            Age = ageArg;
            IsSpayedNeutered = snArg;
            IsAdopted = false;
        }

        internal abstract void Adopt();
    }

    public class Cat : Pet {
        bool IsOutdoor;
        string Colour;   

        public Cat(
            string nameArg, 
            int ageArg, 
            bool snArg, 
            bool isOutdoorArg,
            string colourArg
        ) : base(nameArg, ageArg, snArg) {
            IsOutdoor = isOutdoorArg;
            Colour = colourArg;
        }

        public override string ToString() {
            string result = $"Name of cat: {Name}\n";
            result += $"Colour: {Colour}\n";
            return result;
        }

        internal override void Adopt() {
            if (IsAdopted) {
                throw new Exception("This cat is already adopted");
            }

            if (IsOutdoor && Age < 1) {
                throw new Exception("Cannot adopt this cat yet");
            }

            IsAdopted = true;
        }
    }

    public class Dog : Pet {
        char Size; // L, M, S
        string DogBreed;

        public Dog(
            string nameArg, 
            int ageArg, 
            bool snArg, 
            char sizeArg, 
            string dogBreedArg
        ) : base(nameArg, ageArg, snArg) {
            if (sizeArg != 'L' && sizeArg != 'M' && sizeArg != 'S') {
                throw new Exception("Invalid dog size");
            }
            Size = sizeArg;
            DogBreed = dogBreedArg;
        }

        public override string ToString() {
            string result = $"Name of dog: {Name}\n";
            result += $"Breed: {DogBreed}\n";
            return result;
        }

        internal override void Adopt() {
            if (IsAdopted) {
                throw new Exception("Dog is already adopted");
            }

            if (Size == 'S' && Age < 2) {
                throw new Exception("Cannot adopt this dog yet");
            }

            IsAdopted = true;
        }
    }

    public class Mouse : Pet {

        public Mouse(string nameArg, int ageArg, bool snArg): base(nameArg, ageArg, snArg) {
        }

        internal override void Adopt() {
            if (IsAdopted) {
                throw new Exception("Mouse is already adopted");
            }
            IsAdopted = true;
        }

         public override string ToString() {
            string result = $"Name of Mouse: {Name}\n";
            return result;
        }
    }

}