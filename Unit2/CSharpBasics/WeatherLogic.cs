using System;

namespace unit2
{
    class WeatherLogic
    {    
        public static void CheckWeather() {
            bool isSunny = false;
            decimal temperature = 12m; // degrees celsius
            int x = 5;

            if (isSunny && (temperature > 4)) 
            {
                Console.WriteLine("I will go outside");
                x = 10;

                if (temperature > 15) {
                    Console.WriteLine("I will wear a t-shirt");
                    x = 100;
                } 
                if (temperature > 30)
                {
                    Console.WriteLine("It is really hot out!");
                    x = 1000;
                } 
                if (temperature > 50) {
                    x = 3000;
                }
            } 
            else 
            {
                Console.WriteLine("I will NOT go outside");
                x = -2;
            }

            Console.WriteLine(x);
        }
    }
}


