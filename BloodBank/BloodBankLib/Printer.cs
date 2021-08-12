using System;

namespace BloodBankLib
{
    public interface IPrint {
        void Print(string message);
    }
    public class FilePrinter : IPrint
    {
        public void Print(string message) {

        }
    }

    public class ConsolePrinter : IPrint
    {
        public void Print(string message) {
            Console.WriteLine(message);
        }
    }
}
