using System;
using System.Linq;

namespace Searching_Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int keyForBinary = int.Parse(Console.ReadLine());
            int keyForLinear = int.Parse(Console.ReadLine());

            var number = BinarySearch(inputNumbers, keyForBinary);
            var number2 = LinearSearch(inputNumbers, keyForLinear);
            Console.WriteLine(number);
            Console.WriteLine(number2);
        }

        private static int BinarySearch(int[] inputNumbers, int key)
        {
            Array.Sort(inputNumbers);

            int left = 0;
            int right = inputNumbers.Length - 1;

            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (inputNumbers[middle] == key)
                {
                    return inputNumbers[middle];
                }

                if (key < inputNumbers[middle])
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return -1;
        }

        private static int LinearSearch(int[] inputNumbers, int key)
        {
            for (int i = 0; i < inputNumbers.Length; i++)
            {
                if (inputNumbers[i] == key)
                {
                    return key;
                }
            }

            return 0;
        }
    }
}
