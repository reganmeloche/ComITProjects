using System;

namespace unit2
{
    class Problems
    {
        public static void Run() {
            Console.WriteLine("Running...");
        }

        // 1. Write a function that checks if a number is both greater than 0 AND a multiple of 3.
        static bool Q1(int n) {
            return n > 0 && n%3 == 0;
        }

        // 2. Write a function that checks if a string contains the substring "abc".
        static bool Q2(string s) {

            for (int i = 2; i < s.Length; i++) {
                if (s[i] == 'c' && s[i-1] == 'b' && s[i-2] == 'a') {
                    return true;
                }
            }
            return false;

            // Easier way: return s.Contains("abc");
        }

        // 3. Write a function that takes a string as input and removes the vowels from the string.
        static string Q3(string s) {
            string result = "";
            s = s.ToLower();
            for (int i = 0; i < s.Length; i++) {
                if (!(s[i] == 'a' || s[i] == 'e' || s[i] == 'i' || s[i] == 'o' || s[i] == 'u')) {
                    result += s[i];
                }
            }
            return result;
        }

        // 4. Write a function that takes in two numbers and returns the sum of the squares of the two numbers.
        static double Q4(int a, int b) {
            return Math.Pow(a, 2) + Math.Pow(b, 2);
        }

        // 5. Write a function that takes in two numbers, and returns the sum of all the numbers between them.
        static int Q5(int a, int b) {
            int min = Math.Min(a, b);
            int max = Math.Max(a, b);
            int sum = 0;

            for (int i = min; i <= max; i++) {
                sum += i;
            }
            return sum;
        }

        // 6. Write a function that "weaves" two strings of equal length with dashes between each letter. Make one string uppercase and one lowercase.
        // Example: Input is "Hello" and "World". Result should be "H-w-E-o-L-r-L-l-O-d"
        static string Q6(string s1, string s2) {
            s1 = s1.ToUpper();
            s2 = s2.ToLower();

            string result = "";

            for (int i = 0; i < s1.Length; i++) {
                result += s1[i] + "-" + s2[i];
                if (i != s1.Length - 1) {
                    result += "-";
                }
            }

            return result;
        }

        // 7. Write a function that takes in a number, and adds together all numbers between 1 and 50 that are multiples of that number.
        // Example: Input is 12 -> Result = 12 + 24 + 36 + 48 = 120
        static int Q7(int n) {
            int sum = 0;
            for (int i = 1; i <= 50; i++) {
                if (i%n == 0) {
                    sum +=i;
                }
            }
            return sum;
        }

        // 8. Write a function to check if a given year is a leap year. You may need to look up the rules for what counts as a leap year.
        static bool Q8(int year) {
            if (year < 0 || year > 10000) {
                throw new Exception("Year is invalid");
            }

            if (year % 4 == 0) {
                if (year % 100 != 0 || year % 400 == 0) {
                    return true;
                }
            }
            return false;

            // Easier way: return DateTime.IsLeapYear(year);
        }

        // 9. Write a function that takes in the price of an item and a "discount" flag. Apply a 15% tax to the price. If the discount flag is toggled, then take $2 off the price.
        static decimal Q9(decimal price, bool isDiscount) {
            decimal newPrice = price + price*0.15m;

            if (isDiscount) {
                newPrice -= 2m;
            }

            return newPrice;

            // One line: return price * 1.15m + (isDiscount ? -2m : 0);
        }

        // 10. Write a function that takes in a temperature (Celsius) and a string listing one of 5 substances: Water, Helium, Mercury, Ethanol, and Carbon Dioxide. Return the "state" of the given substance at that temperature ("Solid", "Liquid", "Gas")
        // Example: Input is 250 and "Water" -> Output is "Gas"
        static string Q10(double temperature, string substance) {
            if (temperature < -273.15) {
                Console.WriteLine("Invalid temperature");
                return "";
            }

            string result = "";

            if (substance == "water") {
                if (temperature < 0) {
                    result = "solid";
                } else if (temperature < 100) {
                    result = "liquid";
                } else {
                    result = "gas";
                }

            } else if (substance == "helium") {
                if (temperature < -272.2) {
                    result = "solid";
                } else if (temperature < -268.9) {
                    result = "liquid";
                } else {
                    result = "gas";
                }

            } else if (substance == "carbon dioxide") {
                if (temperature < -78.5) {
                    result = "solid";
                } else if (temperature < -56.6) {
                    result = "liquid";
                } else {
                    result = "gas";
                }

            } else if (substance == "mercury") {
                if (temperature < -38.8) {
                    result = "solid";
                } else if (temperature < 356.7) {
                    result = "liquid";
                } else {
                    result = "gas";
                }

            } else if (substance == "ethanol") {
                if (temperature < -114.1) {
                    result = "solid";
                } else if (temperature < 78.37) {
                    result = "liquid";
                } else {
                    result = "gas";
                }

            } else {
                Console.WriteLine("Invalid input");
            }

            return result;
        }

        // 11. Write a function that takes in a number and a string. Return a substring of the original string of the size of the number.
        // If the number is greater than then length of the string, pad the string with dots so that it matches the length
        // Example: Input is "Hello world" and 7. Output should be "Hello w".
        // Example: Input is "Hello" and 10. Output should be "Hello....."
        static string Q11(int n, string s) {
            string result = "";

            if (s.Length > n) {
                for (int i = 0; i < n; i++) {
                    result += s[i];
                }
            } else {
                for (int i = 0; i < n; i++) {
                    if (i < s.Length) {
                        result += s[i];
                    } else {
                        result += ".";
                    }
                }
            }
            return result;
        }

        // 12. Write some code where the user enters two floating point "types" as strings (e.g. decimal, double, float).
        // Convert the value 1.234567890 from the first type to the second type. Output the result as a string.
        static void Q12() {
            string result = "";

            Console.Write("Enter the first type (float, double, decimal): ");
            string input1 = Console.ReadLine();
            Console.Write("Enter the second type (float, double, decimal): ");
            string input2 = Console.ReadLine();

            if (input1 == "float") {
                float value = 1.234567890f;
                if (input2 == "double") {
                    double dRes = value;
                    result = dRes.ToString();
                }
                if (input2 == "decimal") {
                    decimal decRes = Convert.ToDecimal(value);
                    result = decRes.ToString();
                }     
            }

            if (input1 == "double") {
                double value = 1.234567890;
                if (input2 == "float") {
                    float fRes = Convert.ToSingle(value);
                    result = fRes.ToString();
                }
                if (input2 == "decimal") {
                    decimal decRes = Convert.ToDecimal(value);
                    result = decRes.ToString();
                } 
            }

            if (input1 == "decimal") {
                decimal value = 1.234567890m;
                if (input2 == "float") {
                    float fRes = Convert.ToSingle(value);
                    result = fRes.ToString();
                }
                if (input2 == "double") {
                    double dRes = Convert.ToDouble(value);
                    result = dRes.ToString();
                } 
            }

            Console.WriteLine(result);
        }

        /*
        13. Write a function similar to our cat-buying algorithm from unit 1. 
        Input parameters: colour of the cat, gender of the cat, is the cat neutered/spayed
        Return value: boolean - true if we will buy the cat, false if not
        Rules: Cat must be one of the following
        - A male cat that is neutered, and either white or orange
        - A female cat that is neutered (spayed), any color but white
        */
        static bool Q13(string color, char gender, bool isNeutered) {
            // condition1: A male cat that is neutered, and either white or orange
            bool condition1 = gender == 'M' && isNeutered == true && (color == "white" || color == "orange");

            // condition2: A female cat that is neutered (spayed), any color but white
            bool condition2 = gender == 'F' && isNeutered == true && color != "white";

            return condition1 || condition2;

        }

        // 14. Write some code that accepts numbers from user input and adds it to a running sum. The program exits when the user enters a '0'.
        static void Q14() {

            int sum = 0;

            while(true) {
                Console.WriteLine($"The sum is {sum}");
                Console.Write("Enter a number: ");
                string input = Console.ReadLine();
                int intVal = Convert.ToInt32(input);

                if (intVal == 0) {
                    break;
                }

                sum += intVal;
            }
            Console.WriteLine($"The final value is {sum}");
        }

        //15. Extend our binary-decimal conversion functionality to verify that the user enters a valid positive integer.
        // If they do not, you can either exit out of the code, or continue to prompt them until they enter something valid.
        // <See the Base10Binary class for the answer>


    }
}

