using System;

namespace PetShelter
{
    abstract class Pet {
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

        public virtual void PrintDetails() {
            Console.WriteLine($"Name: {Name}\n");
        }

        public void Greet() {
            Console.WriteLine($"Hello {Name}");
        }

        public abstract void Adopt();

        public abstract void Speak();
    }

    class Cat : Pet {
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

        public override void PrintDetails() {
            Console.WriteLine($"Name of cat: {Name}");
            Console.WriteLine($"Colour: {Colour}\n");
        }

        public override void Adopt() {
            if (IsAdopted) {
                throw new Exception("This cat is already adopted");
            }

            if (IsOutdoor && Age < 1) {
                throw new Exception("Cannot adopt this cat yet");
            }

            IsAdopted = true;
            Console.WriteLine($"Cat ({Name}) was adopted!");
        }

        public override void Speak() {
            Console.WriteLine("Meow");
        }

    }

    class Dog : Pet {
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

        public override void PrintDetails() {
            Console.WriteLine($"Name of dog: {Name}");
            Console.WriteLine($"Breed: {DogBreed}\n");
        }

        public override void Adopt() {
            if (IsAdopted) {
                throw new Exception("Dog is already adopted");
            }

            if (Size == 'S' && Age < 2) {
                throw new Exception("Cannot adopt this dog yet");
            }

            IsAdopted = true;
            Console.WriteLine($"Dog ({Name}) was adopted!");
        }

        public override void Speak() {
            Console.WriteLine("Woof");
        }

    }

    class Mouse : Pet {

        public Mouse(string nameArg, int ageArg, bool snArg): base(nameArg, ageArg, snArg) {
        }

        public override void Speak() {
            Console.WriteLine("Squeak");
        }

        public override void Adopt() {
            if (IsAdopted) {
                throw new Exception("Dog is already adopted");
            }
            Console.WriteLine("Mouse is adopted");
            IsAdopted = true;
        }
    }

}