using System;

namespace Unit3
{
    // abstract class - cannot instantiate it
    public abstract class Instrument
    {
        protected string Material;

        public Instrument(string material) {
            Material = material;
            Console.WriteLine("Instrument constructed");
        }

        public abstract void MakeNoise(); // no body allowed

    }

    public class Horn : Instrument {

        // Inherits the Material, but inaccessible...
        private string _hornType;

        public Horn(string material, string hornType) : base(material) {
            _hornType = hornType;
            Console.WriteLine("Horn constructed");
        }

        // must be marked override in derived classes
        public override void MakeNoise() {
            Console.WriteLine("Toot");
        }

        // Allows access to the material
        public string GetMaterial() {
            return Material;
        }
    }

}
