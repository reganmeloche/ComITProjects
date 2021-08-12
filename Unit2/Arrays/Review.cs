using System; 

class ArrayReview
    {
        static void Run()
        {
            // Change an array element in a function
            int[] arr0 = { 1, 2, 3 };
            ChangeValueInArray(arr0);
            PrintArray(arr0);

            // Change a single array element
            int[] arr1 = { 1, 2, 3 };
            ChangeArrayIndexValue(arr1[0]);
            PrintArray(arr1);

            // Change the whole array in a function
            int[] arr2 = {1, 2, 3};
            ChangeArray(arr2);
            PrintArray(arr2);

            // More array operations
            int[] arr3 = { 1, 2, 3 };
            int[] arr4 = new int[3];
            PrintArray(arr3);
            PrintArray(arr4);
            for (int i = 0; i < 3; i++) {
                arr4[i] = arr3[i];
            }
            PrintArray(arr4);

            Console.WriteLine($"arrays equal?: {arr3 == arr4}\n");

            for (int i = 0; i < 3; i++) {
                arr4[i] *= 2;
            }

            arr3 = arr4;
            PrintArray(arr3);
            PrintArray(arr4);

            // More advanced operations
            int[] arr5 = {10, 9, 8, -5, -6, -7, 0};
            Array.Reverse(arr5);
            PrintArray(arr5);

            arr5 = new int[]{10, 9, 8, -5, -6, -7, 0};
            Array.Sort(arr5);
            PrintArray(arr5);

            arr5 = new int[]{10, 9, 8, -5, -6, -7, 0};
            bool allPositive = Array.TrueForAll(arr5, x => x > 0);
            Console.WriteLine(allPositive);
        }
        static void PrintArray(int[] arr) {
            for (int i = 0; i < arr.Length; i++) {
                Console.WriteLine(i + ": " + arr[i]);
            }
            Console.WriteLine();
        }
        static void ChangeValueInArray(int[] arr) {
            arr[0] = -10;
        }
        static void ChangeArrayIndexValue(int arrayElement) {
            arrayElement = -10;
        }
        static void ChangeArray(int[] arr) {
            arr = new int[]{ -30, -50, -70 };
        }
    }