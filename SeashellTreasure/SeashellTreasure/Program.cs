using System;
using System.Collections.Generic;
using System.Linq;

namespace SeashellTreasure
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            var beach = new char[rows][];
            var collectedSeashells = new List<char>();
            var stolenSeashells = 0;

            //Initialize matrix(jagged array):
            for (int row = 0; row < beach.Length; row++)
            {
                var inputData = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();

                for (int col = 0; col < inputData.Length; col++)
                {
                    beach[row] = inputData;
                }
            }

            while (true)
            {

                var commands = Console.ReadLine().Split(" ");

                if (commands[0] == "Collect")
                {
                    int row = int.Parse(commands[1]);
                    int col = int.Parse(commands[2]);

                    if (row >= 0 && row < beach.Length && col >= 0 && col < beach[row].Length)
                    {

                        if (char.IsLetter(beach[row][col]))
                        {
                            collectedSeashells.Add(beach[row][col]);
                            beach[row][col] = '-';
                        }

                    }
                }
                else if (commands[0] == "Steal")
                {
                    int gullyRow = int.Parse(commands[1]);
                    int gullyCol = int.Parse(commands[2]);
                    int[] gullyCoordinates = new int[2];
                    gullyCoordinates[0] = gullyRow;
                    gullyCoordinates[1] = gullyCol;
                    string direction = commands[3];
                    int move = 0;

                    if (gullyRow >= 0 && gullyRow < beach.Length && gullyCol >= 0 && gullyCol < beach[gullyRow].Length)
                    {

                        if (char.IsLetter(beach[gullyRow][gullyCol]))
                        {
                            beach[gullyRow][gullyCol] = '-';
                            stolenSeashells++;
                        }


                        if (gullyCoordinates[0] + 3 < beach.Length && direction == "down")
                        {

                            while (move < 3)
                            {

                                MoveGully(gullyCoordinates, move, direction, beach);

                                if (char.IsLetter(beach[gullyCoordinates[0]][gullyCoordinates[1]]))
                                {
                                    beach[gullyCoordinates[0]][gullyCoordinates[1]] = '-';
                                    stolenSeashells++;
                                }

                                move++;
                            }
                        }
                        else if (gullyCoordinates[0] - 3 >= 0 && direction == "up")
                        {

                            while (move < 3)
                            {

                                MoveGully(gullyCoordinates, move, direction, beach);

                                if (char.IsLetter(beach[gullyCoordinates[0]][gullyCoordinates[1]]))
                                {
                                    beach[gullyCoordinates[0]][gullyCoordinates[1]] = '-';
                                    stolenSeashells++;
                                }

                                move++;
                            }
                        }
                        else if (gullyCoordinates[1] + 3 < beach[gullyRow].Length && direction == "right")
                        {
                            while (move < 3)
                            {

                                MoveGully(gullyCoordinates, move, direction, beach);

                                if (char.IsLetter(beach[gullyCoordinates[0]][gullyCoordinates[1]]))
                                {
                                    beach[gullyCoordinates[0]][gullyCoordinates[1]] = '-';
                                    stolenSeashells++;
                                }

                                move++;
                            }

                        }
                        else if (gullyCoordinates[1] - 3 >= 0 && direction == "left")
                        {

                            while (move < 3)
                            {

                                MoveGully(gullyCoordinates, move, direction, beach);

                                if (char.IsLetter(beach[gullyCoordinates[0]][gullyCoordinates[1]]))
                                {
                                    beach[gullyCoordinates[0]][gullyCoordinates[1]] = '-';
                                    stolenSeashells++;
                                }

                                move++;
                            }
                        }

                    }
                }
                else
                {
                    break;
                }

            }

            PrintArray(beach);

            if (collectedSeashells.Count == 0)
            {
                Console.WriteLine($"Collected seashells: {collectedSeashells.Count}");
            }
            else
            {
                Console.WriteLine($"Collected seashells: {collectedSeashells.Count} -> {string.Join(", ", collectedSeashells)}");
            }

            Console.WriteLine($"Stolen seashells: {stolenSeashells}");

        }

        private static int[] MoveGully(int[] gullyCoordinates, int move, string direction, char[][] beach)
        {

            switch (direction)
            {

                case "up":

                    gullyCoordinates[0]--;

                    break;

                case "down":

                    gullyCoordinates[0]++;

                    break;

                case "left":

                    gullyCoordinates[1]--;

                    break;

                case "right":

                    gullyCoordinates[1]++;

                    break;

                default:
                    break;
            }

            return gullyCoordinates;
        }

        private static void PrintArray(char[][] beach)
        {
            for (int row = 0; row < beach.Length; row++)
            {
                Console.WriteLine(string.Join(" ", beach[row]));
            }
        }
    }
}
