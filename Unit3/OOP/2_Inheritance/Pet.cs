using System;

namespace Unit3
{
    // abstract class - cannot instantiate it
    public abstract class Pet
    {
        public bool isAdopted {get; private set;}
        public string Name {get; private set;}
        public DateTime DateOfBirth { get; private set; }

        public int Age {
            get {
                int result = DateTime.Now.Year - DateOfBirth.Year;
                if (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear) {
                    result -= 1;
                }
                return result;
            }
        }

        public Pet(string name, DateTime dateOfBirth) {
            Name = name;
            DateOfBirth = dateOfBirth;
            isAdopted = false;
        }

        // abstract: Makes no sense
        public abstract void Speak();

        public void Adopt() {
            Console.WriteLine($"You've adopted {Name}!");
            isAdopted = true;
            this.Speak();
        }
    }

    public class Dog : Pet {
        public string Breed {get; private set;}
        public string Size {get; private set;}

        public Dog(string name, DateTime dateOfBirth, string breed, string size) : base(name, dateOfBirth) {
            Breed = breed;
            Size = size;
        }

        public override void Speak() {
            if (Size == "large") {
                Console.WriteLine($"{Name}: \"WOOF!\"");
            } else {
                Console.WriteLine($"{Name}: \"woof...\"");
            }
        }
    }

    public class Cat : Pet {
        public string Color {get;set;}
        public bool IsOutdoorCat {get;set;}

        public Cat(string name, DateTime dateOfBirth, string color, bool isOutdoorCat) : base(name, dateOfBirth) {
            Color = color;
            IsOutdoorCat = isOutdoorCat;
        }

        public override void Speak() {
            Console.WriteLine($"{Name}: \"Meow\"");
        }

        public void WhereAmI() {
            if (IsOutdoorCat) {
                Console.WriteLine($"{Name} is outside");
            } else {
                Console.WriteLine($"{Name} is inside");
            }
        }
    }

}
