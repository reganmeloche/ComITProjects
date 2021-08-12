using System;
using System.Collections.Generic;

namespace BloodBankLib
{
    public class BloodType
    {
        static readonly List<string> _validTypes = new List<string>() {"A", "B", "AB", "O"};
        public string Abo {get; private set;}
        public char Sign {get; private set;}


        public BloodType(string str) {
            Sign =  str[str.Length - 1];
            Abo = str.Substring(0, str.Length - 1);
        }
        
        public BloodType(string abo, char sign) {
            if (!_validTypes.Contains(abo)) {
                throw new Exception("Invalid blood type");
            }

            if (sign != '+' && sign != '-') {
                throw new Exception("Invalid blood type sign");
            }

            Abo = abo;
            Sign = sign;
        }

        public bool CanDonateTo(BloodType other) {
            // O- can donate to anyone/ O+ can donate to any +
            if (Abo == "O") {
                return (Sign == '-' || other.Sign == '+');
            }

            if (Abo == "A" || Abo == "B") {
                if (other.Abo == Abo || other.Abo == "AB") {
                    return (Sign == '-' || other.Sign == '+');
                }
            }

            if (Abo == "AB") {
                if (other.Abo == Abo) {
                    return (Sign == '-' || other.Sign == '+');
                }
            }
            
            return false;
        }

        public bool CanReceiveFrom(BloodType other) {
            return other.CanDonateTo(this);
        }
    
        public override string ToString() {
            return $"{Abo}{Sign}";
        }

        public static Dictionary<string, BloodType> GetBloodTypeDict() {
            var result = new Dictionary<string, BloodType>();

            foreach (string abo in _validTypes) {
                var a = new BloodType(abo, '+');
                var b = new BloodType(abo, '-');

                result.Add(a.ToString(), a);
                result.Add(b.ToString(), b);
            }
            return result;
        }
    }
}
