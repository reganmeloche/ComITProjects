using System;

namespace unit2
{
    class FizzBuzz
    {    
        public static void Run()
        {

            for (int i = 1; i<= 100; i++) {
                Console.WriteLine(i);
                if (i % 15 == 0) 
                {
                    Console.WriteLine("Fizzbuzz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
            }
        }

    }
}


