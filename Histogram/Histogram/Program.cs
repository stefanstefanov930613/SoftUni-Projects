using System;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberCount = int.Parse(Console.ReadLine());

            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;

            for (int i = 0; i < numberCount; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number < 200)
                {
                    p1++;
                }
                else if (number >= 200 && number <= 399)
                {
                    p2++;
                }
                else if (number >= 400 && number <= 599)
                {
                    p3++;
                }
                else if (number >= 600 && number <= 799)
                {
                    p4++;
                }
                else if (number >= 800)
                {
                    p5++;
                }
            }

            Console.WriteLine($"{p1 / numberCount * 100:f2}%");
            Console.WriteLine($"{p2 / numberCount * 100:f2}%");
            Console.WriteLine($"{p3 / numberCount * 100:f2}%");
            Console.WriteLine($"{p4 / numberCount * 100:f2}%");
            Console.WriteLine($"{p5 / numberCount * 100:f2}%");

        }
    }
}
