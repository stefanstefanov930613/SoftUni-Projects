using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            var legendaryItem = new SortedDictionary<string, int>();
            var junkItems = new SortedDictionary<string, int>();
            legendaryItem.Add("Shadowmourne", 0);
            legendaryItem.Add("Valanyr", 0);
            legendaryItem.Add("Dragonwrath", 0);

            while (true)
            {
                var input = Console.ReadLine().ToLower().Split(" ").ToArray();

                for (int i = 0; i < input.Length; i += 2)
                {

                    string item = input[i + 1];
                    int value = int.Parse(input[i]);

                    switch (item)
                    {
                        case "shards": legendaryItem["Shadowmourne"] += value; break;
                        case "fragments": legendaryItem["Valanyr"] += value; break;
                        case "motes": legendaryItem["Dragonwrath"] += value; break;

                        default:

                            if (!junkItems.ContainsKey(item))
                            {
                                junkItems.Add(item, value);
                            }
                            else
                            {
                                junkItems[item] += value;
                            }
                            break;
                    }

                }

                if (legendaryItem.Values.Any(x => x >= 250))
                {
                    var legendary = legendaryItem.FirstOrDefault(x => x.Value >= 250).Key;
                    Console.WriteLine($"{legendaryItem.FirstOrDefault(x => x.Value >= 250).Key} obtained!");
                    legendaryItem[legendary] -= 250;
                    break;
                }
                 
            }


        }
    }
}
