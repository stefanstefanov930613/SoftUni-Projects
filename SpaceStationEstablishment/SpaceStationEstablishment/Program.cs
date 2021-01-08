using System;
using System.Collections.Generic;

namespace SpaceStationEstablishment
{
    class Program
    {
        static void Main(string[] args)
        {

            int matrixSize = int.Parse(Console.ReadLine());
            var galaxy = new char[matrixSize, matrixSize];
            var stephenCoordinates = new int[2];
            var blackHolesCoordinates = new List<int[]>();
            blackHolesCoordinates.Add(new int[2]);
            blackHolesCoordinates.Add(new int[2]);
            int count = 0;
            int starPower = 0;
             

            for (int row = 0; row < galaxy.GetLength(0); row++)
            {

                var inputData = Console.ReadLine().ToCharArray();

                for (int col = 0; col < galaxy.GetLength(1); col++)
                {

                    galaxy[row, col] = inputData[col];

                    if (galaxy[row, col] == 'S')
                    {
                        stephenCoordinates[0] = row;
                        stephenCoordinates[1] = col;
                    }
                    else if (galaxy[row, col] == 'O')
                    {

                        if (count > 0)
                        {
                            blackHolesCoordinates[1][0] = row;
                            blackHolesCoordinates[1][1] = col;
                        }
                        else
                        {
                            blackHolesCoordinates[0][0] = row;
                            blackHolesCoordinates[0][1] = col;
                            count++;
                        }

                    }

                }

            }

            while (true)
            {

                string direction = Console.ReadLine();

                galaxy[stephenCoordinates[0], stephenCoordinates[1]] = '-';

                MoveStephen(direction, stephenCoordinates);

                if (stephenCoordinates[0] >= 0 && stephenCoordinates[0] < galaxy.GetLength(0)
                 && stephenCoordinates[1] >= 0 && stephenCoordinates[1] < galaxy.GetLength(1))
                {

                    if (char.IsDigit(galaxy[stephenCoordinates[0], stephenCoordinates[1]]))
                    {
                        starPower += (int)char.GetNumericValue(galaxy[stephenCoordinates[0], stephenCoordinates[1]]);
                    }
                    else if (galaxy[stephenCoordinates[0], stephenCoordinates[1]] == 'O')
                    {

                        if (stephenCoordinates[0] == blackHolesCoordinates[0][0] && stephenCoordinates[1] == blackHolesCoordinates[0][1])
                        {
                            galaxy[stephenCoordinates[0], stephenCoordinates[1]] = '-';
                            stephenCoordinates[0] = blackHolesCoordinates[1][0];
                            stephenCoordinates[1] = blackHolesCoordinates[1][1];
                            galaxy[stephenCoordinates[0], stephenCoordinates[1]] = 'S';
                        }
                        else if (stephenCoordinates[0] == blackHolesCoordinates[1][0] && stephenCoordinates[1] == blackHolesCoordinates[1][1])
                        {
                            galaxy[stephenCoordinates[0], stephenCoordinates[1]] = '-';
                            stephenCoordinates[0] = blackHolesCoordinates[0][0];
                            stephenCoordinates[1] = blackHolesCoordinates[0][1];
                            galaxy[stephenCoordinates[0], stephenCoordinates[1]] = 'S';

                        }

                    }

                    galaxy[stephenCoordinates[0], stephenCoordinates[1]] = 'S';

                }
                else
                {

                    if (stephenCoordinates[0] > galaxy.GetLength(0) - 1)
                    {
                        stephenCoordinates[0] = galaxy.GetLength(0) - 1;
                    }
                    else if (stephenCoordinates[0] < 0)
                    {
                        stephenCoordinates[0] = 0;
                    }
                    else if (stephenCoordinates[1] > galaxy.GetLength(1) - 1)
                    {
                        stephenCoordinates[1] = galaxy.GetLength(1) - 1;
                    }
                    else if (stephenCoordinates[1] < 0)
                    {
                        stephenCoordinates[1] = 0;
                    }

                    galaxy[stephenCoordinates[0], stephenCoordinates[1]] = '-';
                    Console.WriteLine("Bad news, the spaceship went to the void.");
                    break;

                }

                if (starPower >= 50)
                {
                    Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                    break;
                }
                   
            }

            PrintArray(galaxy);
            Console.WriteLine($"Star power collected: {starPower}");
        }

        private static int[] MoveStephen(string direction, int[] stephenCoordinates)
        {
            switch (direction)
            {
                case "up": stephenCoordinates[0]--; break;
                case "down": stephenCoordinates[0]++; break;
                case "right": stephenCoordinates[1]++; break;
                case "left": stephenCoordinates[1]--; break;

                default:
                    Console.WriteLine("Non existent direction!");
                    break;
            }

            return stephenCoordinates;
        }

        private static void PrintArray(char[,] galaxy)
        {
            for (int row = 0; row < galaxy.GetLength(0); row++)
            {

                for (int col = 0; col < galaxy.GetLength(1); col++)
                {
                    Console.Write(galaxy[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
