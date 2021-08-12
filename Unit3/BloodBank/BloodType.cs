using System;
using System.Collections.Generic;

namespace BloodBankTest

{
    class BloodType {
        string _abo;
        char _sign;

        public BloodType(string abo, char sign) {
            // abo must be one of A, B, AB, O
            abo = abo.ToUpper();
            if (abo != "AB" && abo != "A" && abo != "B" && abo != "O") {
                throw new Exception($"Blood type {abo} is invalid");
            }
            // sign must be - or +
            if (sign != '-' && sign != '+') {
                throw new Exception($"Blood type sign {sign} is invalid");
            }

            _abo = abo;
            _sign = sign;
        }

        public bool CanDonateTo(BloodType receiverType) {
            // Console.WriteLine("Donating type:");
            // PrintDetails(); //donor1 bloodType
            // Console.WriteLine("Receiving type:");
            // receiverType.PrintDetails();


            /*** O ***/
            if (_abo == "O" && _sign == '-') {
                return true;
            }

            if (_abo == "O" && _sign == '+') {
                if (receiverType._sign == '+') {
                    return true;
                } else {
                    return false;
                }
            }

            /*** B ***/
            if (_abo == "B" && _sign == '-') {
                if (receiverType._abo == "B" || receiverType._abo == "AB") {
                    return true;
                }
            }

            if (_abo == "B" && _sign == '+') {
                if (receiverType._abo == "B" || receiverType._abo == "AB") {
                    if (receiverType._sign == '+') {
                        return true;
                    } else {
                        return false;
                    }
                }
            }

            /*** A ***/
            if (_abo == "A" && _sign == '-') {
                if (receiverType._abo == "A" || receiverType._abo == "AB") {
                    return true;
                }
            }

            if (_abo == "A" && _sign == '+') {
                if (receiverType._abo == "A" || receiverType._abo == "AB") {
                    if (receiverType._sign == '+') {
                        return true;
                    } else {
                        return false;
                    }
                }
            }

            /*** AB ***/
            if (_abo == "AB" && _sign == '-') {
                if (receiverType._abo == "AB") {
                    return true;
                }
            }

            if (_abo == "AB" && _sign == '+') {
                if (receiverType._abo == "AB" && receiverType._sign == '+') {
                    return true;
                } else {
                    return false;
                }
            }

            return false;
        }

        public void PrintDetails() {
            Console.WriteLine($"BloodType is {_abo}{_sign}");
        }
    }
}