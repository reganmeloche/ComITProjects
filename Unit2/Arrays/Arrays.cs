using System;
using System.Collections.Generic; // Required for List<>

namespace unit2
{
    class Arrays
    {
        public static void Run() {

        }

        static void ArrayEquality() {
            int[] arrA = {1, 2, 3};
            int[] arrB = {7, 14};

            PrintArray(arrA);
            PrintArray(arrB);

            // Assigning 
            arrB = arrA;

            PrintArray(arrA);
            PrintArray(arrB);

            // Changing a value
            arrB[0] = 10;
            arrA[2] = 50;

            PrintArray(arrA);
            PrintArray(arrB);
        }

        static void ArrayPassing() {
            int a = 2;
            ChangeInt(a);
            Console.WriteLine(a);

            int[] arr = { 50, 60, 70 };
            PrintArray(arr);
            ChangeArrayIndexValue(arr);
            PrintArray(arr);
        }

        static int GetMax(int[] arr) {
            int max = arr[0];
            for (int i = 0; i < arr.Length; i++) {
                int currentValue = arr[i];
                if (currentValue > max) {
                    max = currentValue;
                }
            }
            return max;
        }
    

        static void BuildArrayFromInput() {
            string[] stringArray = new string[5];
            int i = 0;
            while(true) {
                Console.WriteLine("Enter next value");
                string userInput = Console.ReadLine();
                if (userInput == "exit") {
                    break;
                }

                stringArray[i] = userInput;
                i++;
            }
            Console.WriteLine("The length is " + stringArray.Length);
        }

        static void BuildListFromInput(){
            List<string> myList = new List<string>();

            while(true) {
                Console.WriteLine("Enter next value");
                string userInput = Console.ReadLine();
                if (userInput == "exit") {
                    break;
                }
                myList.Add(userInput);
            }
            Console.WriteLine("The length is " + myList.Count);
        }

        static void ChangeInt(int x) {
            x = 10;
        }

        static void ChangeArrayIndexValue(int[] arr) {
            arr[0] = -4;
        }

        static void PrintArray(int[] x) {
            for (int i = 0; i < x.Length; i++) {
                Console.WriteLine(i + ": " + x[i]);
            }
            Console.WriteLine();
        }
    }
}