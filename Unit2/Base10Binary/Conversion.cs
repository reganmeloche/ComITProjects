using System;

namespace unit2
{
    class Base10BinaryConvert
    {    
        public static void Run() {
            
            // While loop so that the program runs over and over
            while (true) {
                // Read in user input
                Console.WriteLine("Enter a positive integer to convert to binary, or enter 'exit' to exit the program.");
                string userInput = Console.ReadLine();

                // If user inputs the text "exit", then break out of the loop
                if (userInput == "exit") {
                    break;
                }

                int base10Int = 0;
                try {
                    // Try to convert the input to an int
                    base10Int = Convert.ToInt32(userInput);
                    if (base10Int < 0) {
                        throw new Exception("Invalid integer");
                    }
                } catch (Exception) {
                    // If the int is less than 0 or the input was not a valid integer, then retry
                    Console.WriteLine("Invalid input. Please enter a valid positive integer");
                    continue;
                }

                // Perform the conversion
                string result = ConvertBase10ToBinary(base10Int);

                // Print out the result
                Console.WriteLine($"Result: {result}\n");
            }
            
            // Goodbye!
            Console.WriteLine("Thanks for playing!");
        }

        public static int ConvertBinaryToBase10(string binary) {
            string reverseString = ReverseAString(binary);
            int sum = 0;

            int len = reverseString.Length;
            for (int i = 0; i < len; i++) {
                double nextPowerOfTwo = Math.Pow(2, i);
                int nextPowerOfTwoInt = Convert.ToInt32(nextPowerOfTwo);
                
                if (reverseString[i] == '1') {
                    sum += nextPowerOfTwoInt;
                }
            }

            return sum;
        }

        public static string ConvertBase10ToBinary(int myNumber) {
            string result = "";

            if (myNumber == 0) {
                return "0";
            }

            while (myNumber > 0) {
                int remainder = myNumber % 2;
                myNumber = myNumber / 2;
                result += remainder;
            }

            // Reverses a string
            string finalResult = ReverseAString(result);
            return finalResult;
        }

        public static string ReverseAString(string stringToReverse) {
            string finalResult = "";
            for (int i = stringToReverse.Length - 1; i >= 0; i--) {
                finalResult += stringToReverse[i];
            }

            return finalResult;
        }
    }
}


