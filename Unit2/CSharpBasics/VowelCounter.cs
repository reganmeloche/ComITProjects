using System;

namespace unit2
{
    class VowelCounter
    {    
        public static void CountVowels() {
            string str;
            
            int i, len, vowel;

            Console.Write("Input the string : ");
            str = Console.ReadLine().ToLower();

            vowel = 0;
            len = str.Length;
            Console.WriteLine("Length:" + len);
		
		    for(i=0; i<len; i++) {
                if(str[i] =='a' || str[i]=='e' || str[i]=='i' || str[i]=='o' || str[i]=='u')
                {
                    vowel++;
                }
            }
            Console.Write("\nThe total number of vowels in the input is : {0}\n", vowel);
        }


    }
}


