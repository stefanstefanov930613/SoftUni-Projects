using System;
using System.Collections.Generic;
using System.Linq;

namespace Space_Station_Establishment
{
    class Program
    {
        static void Main(string[] args)
        {
            var biggness = int.Parse(Console.ReadLine());
            var universe = new char[biggness][];
            var blackHoles = new List<int[]>();
            var indexOneStephen = 0;
            var indexTwoStephen = 0;
            var starPower = 0;

            for (int i = 0; i < universe.Length; i++)
            {
                var input = Console.ReadLine().ToCharArray();
                universe[i] = new char[input.Length];
                for (int j = 0; j < input.Length; j++)
                {
                    universe[i][j] = input[j];
                    if (universe[i][j] == 'O')
                    {
                        blackHoles.Add(new int[] { i, j });
                    }
                    if (universe[i][j] == 'S')
                    {
                        indexOneStephen = i;
                        indexTwoStephen = j;

                        universe[indexOneStephen][indexTwoStephen] = '-';
                    }
                }
            }

            while (true)
            {
                var command = Console.ReadLine().ToLower();

                var moveIndexes = Move(universe, indexOneStephen, indexTwoStephen, command, blackHoles);

                indexOneStephen = moveIndexes[0];
                indexTwoStephen = moveIndexes[1];

                if (IsInside(universe, indexOneStephen, indexTwoStephen))
                {
                    if (char.IsDigit(universe[indexOneStephen][indexTwoStephen]))
                    {
                        var num = char.GetNumericValue(universe[indexOneStephen][indexTwoStephen]);
                        starPower += Convert.ToInt32(num);
                        universe[indexOneStephen][indexTwoStephen] = '-';
                        if (starPower >= 50)
                        {
                            Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                            universe[indexOneStephen][indexTwoStephen] = 'S';
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Bad news, the spaceship went to the void.");
                    break;
                }
            }

            

            Console.WriteLine($"Star power collected: {starPower}");

            foreach (var items in universe)
            {
                foreach (var item in items)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
            }
        }

        private static int[] Move(char[][] universe, int indexOneStephen, int indexTwoStephen, string command, List<int[]> blackHoles)
        {
            switch (command)
            {
                case "up": indexOneStephen--; break;
                case "down": indexOneStephen++; break;
                case "left": indexTwoStephen--; break;
                case "right": indexTwoStephen++; break;
                default:
                    break;
            }

            if (IsInside(universe, indexOneStephen, indexTwoStephen) && blackHoles.Count > 1)
            {
                if (universe[indexOneStephen][indexTwoStephen] == 'O')
                {
                    if (indexOneStephen == blackHoles[0][0] && indexTwoStephen == blackHoles[0][1] && universe[indexOneStephen][indexTwoStephen] == 'O')
                    {
                        indexOneStephen = blackHoles[1][0];
                        indexTwoStephen = blackHoles[1][1];

                        universe[blackHoles[1][0]][blackHoles[1][1]] = '-';
                        universe[blackHoles[0][0]][blackHoles[0][1]] = '-';
                    }
                    if (indexOneStephen == blackHoles[1][0] && indexTwoStephen == blackHoles[1][1] && universe[indexOneStephen][indexTwoStephen] == 'O')
                    {
                        indexOneStephen = blackHoles[0][0];
                        indexTwoStephen = blackHoles[0][1];
                        universe[blackHoles[1][0]][blackHoles[1][1]] = '-';
                        universe[blackHoles[0][0]][blackHoles[0][1]] = '-';
                    }
                }
            }

            var newMove = new int[] { indexOneStephen, indexTwoStephen };

            return newMove;
        }

        private static bool IsInside(char[][] universe, int indexOneStephen, int indexTwoStephen)
        {
            return indexOneStephen >= 0 && indexTwoStephen <= universe.Length - 1 && indexTwoStephen >= 0 && indexTwoStephen <= universe[indexOneStephen].Length - 1;
        }
    }
}
