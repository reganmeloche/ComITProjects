using System;
using System.Collections.Generic;

namespace Unit3
{
    public class Greeter1
    {
        public void SayHi(string language) {
            string result = "";

            if (language == "en") {
                result = "Hello";
            }

            if (language == "fr") {
                result = "Bonjour";
            }

            if (language == "th") {
                result = "Sawat-dii";
            }

            Console.WriteLine(result);
        }

        public void SayBye(string language) {
            string result = "";

            if (language == "en") {
                result = "Goodbye";
            }

            if (language == "fr") {
                result = "Au revoir";
            }

            if (language == "th") {
                result = "Sawat-dii";
            }

            Console.WriteLine(result);
        }
    }

    public class Greeter2
    {
        private readonly string _language;
        public Greeter2(string language) {
            _language = language;
        }

        public void SayHi() {
            string result = "";

            if (_language == "en") {
                result = "Hello";
            }

            if (_language == "fr") {
                result = "Bonjour";
            }

            if (_language == "th") {
                result = "Sawat-dii";
            }

            Console.WriteLine(result);
        }

        public void SayBye() {
            string result = "";

            if (_language == "en") {
                result = "Goodbye";
            }

            if (_language == "fr") {
                result = "Au revoir";
            }

            if (_language == "th") {
                result = "Sawat-dii";
            }

            Console.WriteLine(result);
        }
    }

    ///////////////////////////////////////////////////
    ///////////////////////////////////////////////////
    ///////////////////////////////////////////////////

    public class GreeterToInherit {
        public void SayHi() {
            Console.WriteLine("Hello");
        }
    }

    public class Greeter3 : GreeterToInherit {
        public void SayBye() {
            Console.WriteLine("Goodbye");
        }
    }

    ///////////////////////////////////////////////////
    ///////////////////////////////////////////////////
    ///////////////////////////////////////////////////
    ///////////////////////////////////////////////////

    public class Greeter4 {
        public virtual void SayHi() {
            Console.WriteLine("Hello");
        }

        public virtual void SayBye() {
            Console.WriteLine("Goodbye");
        }
    }

    public class FrenchGreeter4 : Greeter4 {
        public override void SayHi() {
            Console.WriteLine("Bonjour");
        }

        public override void SayBye() {
            Console.WriteLine("Au revoir");
        }
    }

    public class ItalianGreeter4 : Greeter4 {
        public override void SayHi() {
            Console.WriteLine("Ciao");
        }

        public override void SayBye() {
            Console.WriteLine("Arrivederci");
        }
    }

    public class EnglishGreeter4 : Greeter4 {
    }

    ///////////////////////////////////////////////////
    ///////////////////////////////////////////////////
    ///////////////////////////////////////////////////


    public abstract class Greeter5 {

        // Abstract: no implementation. MUST be overridden by derived class
        public abstract void SayHi();

        // Virtual: CAN be overridden by derived class. Otherwise, use default
        public virtual void SayBye() {
            Console.WriteLine("Goodbye");
        }
    }

    public class FrenchGreeter5 : Greeter5 {
        public override void SayHi() {
            Console.WriteLine("Bonjour");
        }

        public override void SayBye() {
            Console.WriteLine("Au revoir");
        }
    }


    ///////////////////////////////////////////////////
    ///////////////////////////////////////////////////
    ///////////////////////////////////////////////////

    // Fully abstract (essentially the same as an interface)
    // Still need to use override in the derived class
    public abstract class Greeter6 {
        public abstract void SayHi();

        public abstract void SayBye();
    }

    public class FrenchGreeter6 : Greeter6 {
        public override void SayHi() {
            Console.WriteLine("Bonjour");
        }

        public override void SayBye() {
            Console.WriteLine("Au revoir");
        }
    }

    public class EnglishGreeter6 : Greeter6 {
        public override void SayHi() {
            Console.WriteLine("Hello");
        }

        public override void SayBye() {
            Console.WriteLine("Goodbye");
        }
    }

    ///////////////////////////////////////////////////
    ///////////////////////////////////////////////////
    ///////////////////////////////////////////////////

    // Interface
    // purely abstract class
    // No need to override
    public interface IGreet {
        void SayHi();

        void SayBye();
    }

    public class FrenchGreeter7 : IGreet {
        public void SayHi() {
            Console.WriteLine("Bonjour");
        }

        public void SayBye() {
            Console.WriteLine("Au revoir");
        }
    }

    public class EnglishGreeter7 : IGreet {
        public void SayHi() {
            Console.WriteLine("Hello");
        }

        public void SayBye() {
            Console.WriteLine("Goodbye");
        }
    }
}
