using System;
using System.Collections.Generic;
using System.Linq;

namespace DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            var drumSet = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            var oldDrumSet = new List<int>();

            foreach (var drum in drumSet)
            {
                oldDrumSet.Add(drum);
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Hit it again, Gabsy!")
                {
                    break;
                }

                int hitPower = int.Parse(input);

                for (int drum = 0; drum < drumSet.Count; drum++)
                {
                     
                    drumSet[drum] -= hitPower;

                    if (drumSet[drum] <= 0)
                    {
                        int index = drum;
                        var newDrum = oldDrumSet.ElementAt(index);
                        double price = newDrum * 3;

                        if (savings >= price)
                        {
                            savings -= price;
                            drumSet.RemoveAt(index);
                            drumSet.Insert(index, newDrum);
                        }
                        else
                        {
                            drumSet.Remove(drumSet[drum]);
                            oldDrumSet.Remove(newDrum);
                            drum--;
                        }

                    }

                }
            }

            Console.WriteLine(string.Join(" ", drumSet));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
