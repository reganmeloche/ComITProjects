using System;

namespace unit2
{
    class OtherExamples
    {
        public static void ExContinue() {
            for (int i = 1; i < 50; i++) {               
                // if i is divisible by 3. 
                Console.WriteLine("---i: " + i);
                if (i%3 == 0) {
                    Console.WriteLine("i is divisible by 3");
                    continue;
                    //Console.WriteLine("Hello!");
                }
                Console.WriteLine("end of iteration");
            }

        }

        public static void WritingExamples() {
             int a = 10;
            string b = "hello";
            float c = 7.88f;
            bool d = true;

            Console.WriteLine("Here are my variables: a: " + a + ", b: " + b + ", c: " + c + ", d: " + d);

            Console.WriteLine("Here are my variables: a: {0}, b: {1}, c: {2}, d: {3}", a, b, c, d);

            Console.WriteLine($"Here are my variables: a: {a}, b: {b}, c: {c}, d: {d}");
            
        }

        public static void Max3() {
            Console.WriteLine("What is your firs number? ");
            string firstNumber = Console.ReadLine();
            int firstNumberInt = Convert.ToInt32(firstNumber);

            Console.WriteLine("What is your second number? ");
            string secondNumber = Console.ReadLine();
            int secondNumberInt = Convert.ToInt32(secondNumber);

            Console.WriteLine("What is your third number? ");
            string thirdNumber = Console.ReadLine();
            int thirdNumberInt = Convert.ToInt32(thirdNumber);

            
            if (firstNumberInt >= secondNumberInt && firstNumberInt >= thirdNumberInt)
            {
                Console.WriteLine($"First number is the largest.");
            }
            else if (secondNumberInt >= firstNumberInt && secondNumberInt >= thirdNumberInt)
            {
                Console.WriteLine("Second number is the largest.");
            }
            else if (thirdNumberInt >= firstNumberInt && thirdNumberInt >= secondNumberInt)
            {
                Console.WriteLine("Third number is the largest.");
            }
            else
            {
                Console.WriteLine("All three number are equal.");
            }
        }
    }
}

