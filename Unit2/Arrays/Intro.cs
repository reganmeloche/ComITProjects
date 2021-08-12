using System;

namespace unit2
{
    class ArraysIntro
    {
        public static void SumArrayNoArray() {
            double student1Grade = 87;
            double student2Grade = 60.5;
            double student3Grade = 95.3;
            double student4Grade = 58.9;
            double sum = student1Grade + student2Grade + student3Grade + student4Grade;

            double average = sum / 4;
            Console.WriteLine(average);
        }

        public static void SumArray() {

            
            double[] studentGrades = { 87, 60.5, 95.3, 58.9, 64, 89, 43, 23, 88, 98.6, 98.6 };
            
            //// Alternative initialization
            // double[] studentGrades = new double[5];
            // studentGrades[0] = 87;
            // studentGrades[1] = 60.5;
            // studentGrades[2] = 95.3;
            // studentGrades[3] = 58.9;
            // studentGrades[4] = 64;

            double sum = 0;

            for (int i = 0; i < studentGrades.Length; i++) {
                Console.WriteLine($"value {i} is: {studentGrades[i]}");
                sum += studentGrades[i];
            }
            double average = sum / studentGrades.Length;
            Console.WriteLine(average);
        }
    }
}