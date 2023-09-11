using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter size array: ");
            int size = int.Parse(Console.ReadLine());

            int[] array1 = { 2, 4, 6, 8, 10 };
            int[] array2 = new int[size];

            Console.WriteLine("Enter elements of the second array: ");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Element {i + 1}: ");
                array2[i] = int.Parse(Console.ReadLine());
            }

            int product = 1;
            for (int i = 0; i < size; i++)
            {
                product *= array1[i] * array2[i];
            }

            Console.WriteLine($"Product array: {product}");

            Console.WriteLine("Enter the number of rows: ");
            int rows = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the number of columns: ");
            int columns = int.Parse(Console.ReadLine());

            int[,] uninitializedArray = new int[rows, columns];
            Console.WriteLine("Enter elements of the uninitialized array:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"Element [{i}, {j}]: ");
                    uninitializedArray[i, j] = int.Parse(Console.ReadLine());
                }
            }

            int[,] initializedArray =
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            Console.WriteLine(" ");

            Console.WriteLine("Initialized Array:");
            PrintArray(initializedArray);
            Console.WriteLine(" ");

            Console.WriteLine("Uninitialized Array:");
            PrintArray(uninitializedArray);
            Console.WriteLine(" ");

            int sumInitialized = SumArray(initializedArray);
            int sumUninitialized = SumArray(uninitializedArray);
            Console.WriteLine(" ");

            Console.WriteLine($"Sum of odd columns in initialized array: {sumInitialized}");
            Console.WriteLine($"Sum of odd columns in uninitialized array: {sumUninitialized}");
            Console.WriteLine(" ");

            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[] { 1, 2, 3 };
            jaggedArray[1] = new int[] { 4, 5 };
            jaggedArray[2] = new int[] { 6, 7, 8, 9 };

            Console.WriteLine("Two-dimensional unaligned array:");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++) 
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }

            int sumOddColumns = 0;
            for (int j = 0; j < jaggedArray[0].Length; j++)
            {
                if (j % 2 != 0)
                {
                    for (int i = 0; i < jaggedArray.Length; i++)
                    {
                        if (j < jaggedArray[i].Length)
                        {
                            sumOddColumns += jaggedArray[i][j];
                        }
                    }
                }
            }
            Console.WriteLine($"Sum of odd columns in the jagged array: {sumOddColumns}");

            Console.WriteLine("Enter a value to count in array: ");
            int valueToCount = int.Parse(Console.ReadLine());

            int countArray1 = CountValueInArray(array1, valueToCount);
            int countArray2 = CountValueInArray(array2, valueToCount);
            int countInitializedArray = CountValueInTwoDimensionalArray(initializedArray, valueToCount);
            int countUninitializedArray = CountValueInTwoDimensionalArray(uninitializedArray, valueToCount);
            int countJaggedArray = CountValueInJaggedArray(jaggedArray, valueToCount);

            Console.WriteLine($"Count of {valueToCount} in array1: {countArray1}");
            Console.WriteLine($"Count of {valueToCount} in array2: {countArray2}");
            Console.WriteLine($"Count of {valueToCount} in initializedArray: {countInitializedArray}");
            Console.WriteLine($"Count of {valueToCount} in uninitializedArray: {countUninitializedArray}");
            Console.WriteLine($"Count of {valueToCount} in jaggedArray {countJaggedArray}");

            Console.ReadLine();
        }
        static void PrintArray(int[,] arr)
        {
            int rows = arr.GetLength(0);
            int columns = arr.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static int SumArray(int[,] arr)
        {
            int rows = arr.GetLength(0);
            int columns = arr.GetLength(1);
            int sum = 0;

            for (int j = 0; j < columns; j++)
            {
                if (j % 2 != 0)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        sum += arr[i, j];
                    }
                }
            }
            return sum;
        }
        static int CountValueInArray(int[] arr, int value) 
        {
            int count = 0;
            foreach (var element in arr)
            {
                if (element == value)
                {
                    count++;
                }
            }
            return count;
        }
        static int CountValueInTwoDimensionalArray(int[,] arr, int value)
        {
            int count = 0;
            int rows = arr.GetLength(0);
            int columns = arr.GetLength(1);

            foreach (var element in arr)
            {
                if (element == value)
                {
                    count++;
                }
            }
            return count;
        }
        static int CountValueInJaggedArray(int[][] arr, int value)
        {
            int count = 0;
            foreach (var row in arr)
            {
                foreach (var element in row)
                {
                    if (element == value)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}