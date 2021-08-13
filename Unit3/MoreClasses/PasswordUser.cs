using System;
using PasswordGenerator;

namespace Unit3Examples
{
    public class PasswordUser
    {
        public static void Run()
        {
            var passwordGenerator = new Password(false, false, true, false);

            for (int i = 0; i < 10; i++) {
                string randomPassword = passwordGenerator.Next();
                Console.WriteLine(randomPassword);
            }
        }        

        
    }
}