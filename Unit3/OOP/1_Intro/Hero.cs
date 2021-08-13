using System;
using System.Collections.Generic;

namespace Unit3
{
    // Everything is public
    // Pros: Easy to work with 
    // Cons: Easy to break. No security or encapsulation
    public class Hero1 
    {
        public string Name;
        public int Ammo;
        public decimal Health;

        public Hero1(string name){
            Name = name;
            Ammo = 10;
            Health = 100m;
        }

        public void Fire() {
            if (Ammo > 0) {
                Console.WriteLine("Pew pew pew");
                Ammo--;
            } else {
                Console.WriteLine($"{Name} is out of ammo!");
            }
        }

        public void TakeDamage(decimal damage) {
            Health -= damage;
            if (Health < 0) {
                Console.WriteLine($"{Name} has fainted!");
            }
        }


    }


    // Just use private variables
    // Pros: Encapsulated and tightly controlled
    // Cons: Tedious and some code repetition
    public class Hero2
    {
        private string _name;

        private int _ammo;

        private decimal _health;

        public Hero2(string name) {
            _name = name;
            _ammo = 10;
            _health = 100m;
        }

        public string GetName() {
            return _name;
        }

        public int GetAmmo() {
            return _ammo;
        }

        public void AddAmmo(int value) {
            _ammo += value;
        }

        public void TakeDamage(decimal damage) {
            _health -= damage;
            if (_health < 0) {
                Console.WriteLine($"{_name} has fainted!");
            }
        }

        public void Fire() {
            if (_ammo > 0) {
                Console.WriteLine("Pew pew pew");
                _ammo--;
            } else {
                Console.WriteLine($"{_name} is out of ammo!");
            }
        }

    }

    // Hero3
    // Use properties with care
    // We control the access in an easier-to-write way
    // Bonus: Minmax the ammo and health. Set as consts
    public class Hero3 {
        public string Name { get; private set; } 
        public int Ammo {get; private set;}
        public decimal Health {get; private set;}

        public Hero3(string name) {
            // private set
            Name = name;
            Ammo = 10;
            Health = 100m;
        }

        public void AddAmmo(int amount) {
            Ammo += amount;
        }

        public void Fire() {
            if (Ammo > 0) {
                Console.WriteLine("Pew pew pew");
                Ammo--;
            } else {
                Console.WriteLine($"{Name} is out of ammo!");
            }
        }

        public void TakeDamage(decimal damage) {
            Health -= damage;
            if (Health < 0) {
                Console.WriteLine($"{Name} has fainted!");
            }
        }


    }

    
}
