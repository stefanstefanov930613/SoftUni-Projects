using System;
using System.Linq;

namespace MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialHealth = 100;
            int bitcoins = 0;

            var dungeonsRooms = Console.ReadLine().Split("|").ToArray();

            for (int room = 0; room < dungeonsRooms.Length; room++)
            {

                var inputData = dungeonsRooms[room].Split(" ");

                string monsterOrAction = inputData[0];
                int points = int.Parse(inputData[1]);

                if (monsterOrAction == "potion")
                {
                     
                    if (initialHealth == 100)
                    {
                        Console.WriteLine($"You healed for 0 hp.");
                        Console.WriteLine($"Current health: {initialHealth} hp.");
                    }
                    else if (initialHealth + points > 100)
                    {
                        Console.WriteLine($"You healed for {100 - initialHealth} hp.");
                        initialHealth = 100;
                        Console.WriteLine($"Current health: {initialHealth} hp.");
                    }
                    else
                    {

                        initialHealth += points;

                        Console.WriteLine($"You healed for {points} hp.");
                        Console.WriteLine($"Current health: {initialHealth} hp.");

                    }

                }
                else if (monsterOrAction == "chest")
                {
                    bitcoins += points;
                    Console.WriteLine($"You found {points} bitcoins.");
                }
                else
                {
                    initialHealth -= points;

                    if (initialHealth <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {monsterOrAction}.");
                        Console.WriteLine($"Best room: {room + 1}");
                        return;
                    }

                    Console.WriteLine($"You slayed {monsterOrAction}.");
                }

            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {initialHealth}");

        }
    }
}
