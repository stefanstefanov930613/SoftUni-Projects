using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_A_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\Chefo1993\Desktop\Words.txt");

            int counter = 0;
            int words = 1;

            while (counter <= text.Length - 1)
            {
                if (text[counter] == ' ' || text[counter] == '\n' || text[counter] == '\t')
                {
                    words++;
                }

                counter++;
            }

            Console.WriteLine($"Words in the string are: {words}");
        }


    }
}
