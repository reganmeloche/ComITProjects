using System;
using System.Collections.Generic;

namespace BloodClinic.Models
{
    public class BloodType
    {
        public string Letter {get; private set;}
        public char Sign {get; private set;}
        static readonly List<string> _validTypes = new List<string>() {"A", "B", "AB", "O"};

        public BloodType(string str) {
            Sign =  str[str.Length - 1];
            Letter = str.Substring(0, str.Length - 1);
        }
        
        public BloodType(string letter, char sign) {
            if (!_validTypes.Contains(letter)) {
                throw new Exception("Invalid blood type");
            }

            if (sign != '+' && sign != '-') {
                throw new Exception("Invalid blood type sign");
            }
            
            Letter = letter;
            Sign = sign;
        }

        public bool CanDonateTo(BloodType other) {
            // O- can donate to anyone/ O+ can donate to any +
            if (Letter == "O") {
                return (Sign == '-' || other.Sign == '+');
            }

            if (Letter == "A" || Letter == "B") {
                if (other.Letter == Letter || other.Letter == "AB") {
                    return (Sign == '-' || other.Sign == '+');
                }
            }

            if (Letter == "AB") {
                if (other.Letter == Letter) {
                    return (Sign == '-' || other.Sign == '+');
                }
            }
            
            return false;
        }

        public bool CanReceiveFrom(BloodType other) {
            return other.CanDonateTo(this);
        }
    
        public override string ToString() {
            return $"{Letter}{Sign}";
        }
    }
}