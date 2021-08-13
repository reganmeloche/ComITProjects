using System;

namespace Unit3Examples
{
    /*
    Challenge: Implement the Fire() and TakeDamage() methods. 
    You will need to decide which new data members will be required and add them in. 
    Complete the 3 constructors
    */
    public class Hero
    {
        /*** Constructors ***/
        // 1. Empty Constructor - set default values for all data

        // 2. Constructor that only takes in an argument for the name. Set others to reasonable defaults
        Hero(string nameArg) {
            Name = nameArg;
            isFlying = false; 
        }

        // 3. Constructor that takes in arguments for all data


        /*** Data Members ***/
        public string Name { get; set; }
        private bool isFlying;


        /*** Methods ****/
        public void Fire() {
            // Note: Can only fire if not flying

        }

        public void TakeDamage() {

        }

        public void StartFlying() {
            if (!isFlying) {
                isFlying = true;
                Console.WriteLine($"{Name} starts flying!");
            }
        }

        public void Land() {
            if (isFlying) {
                isFlying = false;
                Console.WriteLine($"{Name} has landed!");
            }
        }
    
    }
}