using System;

namespace PetShelterLib {

    public interface IPrinter {
        void Print(string message);
    }

    public class ConsolePrinter : IPrinter {
        public void Print(string message) {
            Console.WriteLine(message);
        }
    }

}