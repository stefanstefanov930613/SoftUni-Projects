using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {

            int fieldSize = int.Parse(Console.ReadLine());
            char[,] tiktaktoeField = new char[fieldSize, fieldSize];
            int[] playerCoordinates = new int[4];
            int turn = 1;
            int count = 0;

            InitializeField(tiktaktoeField);

            PrintArray(tiktaktoeField);

            while (true)
            {

                var inputKey = Console.ReadKey();

                Array.Clear(playerCoordinates, 0, playerCoordinates.Length);

                while (true)
                {

                    Console.Clear();

                    ClearMatrix(tiktaktoeField);

                    if (turn % 2 != 0)
                    {
                        MoveAroundFirstPlayer(playerCoordinates, tiktaktoeField, inputKey);

                        if (playerCoordinates[0] >= 0 && playerCoordinates[0] < tiktaktoeField.GetLength(0)
                        && playerCoordinates[1] >= 0 && playerCoordinates[1] < tiktaktoeField.GetLength(1))
                        {
                            if (tiktaktoeField[playerCoordinates[0], playerCoordinates[1]] != 'O' && tiktaktoeField[playerCoordinates[0], playerCoordinates[1]] != 'X')
                            {

                                tiktaktoeField[playerCoordinates[0], playerCoordinates[1]] = '1';

                                if (inputKey.Key == ConsoleKey.Enter)
                                {
                                    tiktaktoeField[playerCoordinates[0], playerCoordinates[1]] = 'X';

                                    break;

                                }

                            }

                        }
                        else
                        {

                            if (playerCoordinates[0] < 0)
                            {
                                playerCoordinates[0] = 0;
                            }
                            else if (playerCoordinates[0] > tiktaktoeField.GetLength(0) - 1)
                            {
                                playerCoordinates[0] = tiktaktoeField.GetLength(0) - 1;
                            }
                            else if (playerCoordinates[1] < 0)
                            {
                                playerCoordinates[1] = 0;
                            }
                            else if (playerCoordinates[1] > tiktaktoeField.GetLength(1) - 1)
                            {
                                playerCoordinates[1] = tiktaktoeField.GetLength(1) - 1;
                            }

                            if (tiktaktoeField[playerCoordinates[0], playerCoordinates[1]] != 'X' && tiktaktoeField[playerCoordinates[0], playerCoordinates[1]] != 'O')
                            {

                                tiktaktoeField[playerCoordinates[0], playerCoordinates[1]] = '1';

                            }

                        }

                    }
                    else if (turn % 2 == 0)
                    {

                        MoveAroundSecondPlayer(playerCoordinates, tiktaktoeField, inputKey);

                        if (playerCoordinates[2] >= 0 && playerCoordinates[2] < tiktaktoeField.GetLength(0)
                        && playerCoordinates[3] >= 0 && playerCoordinates[3] < tiktaktoeField.GetLength(1))
                        {

                            if (tiktaktoeField[playerCoordinates[2], playerCoordinates[3]] != 'X' && tiktaktoeField[playerCoordinates[2], playerCoordinates[3]] != 'O')
                            {
                                tiktaktoeField[playerCoordinates[2], playerCoordinates[3]] = '2';

                                if (inputKey.Key == ConsoleKey.Enter)
                                {
                                    tiktaktoeField[playerCoordinates[2], playerCoordinates[3]] = 'O';

                                    break;

                                }

                            }

                        }
                        else
                        {

                            if (playerCoordinates[2] < 0)
                            {
                                playerCoordinates[2] = 0;
                            }
                            else if (playerCoordinates[2] > tiktaktoeField.GetLength(0) - 1)
                            {
                                playerCoordinates[2] = tiktaktoeField.GetLength(0) - 1;
                            }
                            else if (playerCoordinates[3] < 0)
                            {
                                playerCoordinates[3] = 0;
                            }
                            else if (playerCoordinates[3] > tiktaktoeField.GetLength(1) - 1)
                            {
                                playerCoordinates[3] = tiktaktoeField.GetLength(1) - 1;
                            }

                            if (tiktaktoeField[playerCoordinates[2], playerCoordinates[3]] != 'X' && tiktaktoeField[playerCoordinates[2], playerCoordinates[3]] != 'O')
                            {

                                tiktaktoeField[playerCoordinates[2], playerCoordinates[3]] = '2';

                            }

                        }
                    }

                    PrintArray(tiktaktoeField);
                    inputKey = Console.ReadKey();

                }

                if ((tiktaktoeField[0, 0] == 'X' && tiktaktoeField[0, 1] == 'X' && tiktaktoeField[0, 2] == 'X') ||
                    (tiktaktoeField[1, 0] == 'X' && tiktaktoeField[1, 1] == 'X' && tiktaktoeField[1, 2] == 'X') ||
                     (tiktaktoeField[2, 0] == 'X' && tiktaktoeField[2, 1] == 'X' && tiktaktoeField[2, 2] == 'X') ||
                    (tiktaktoeField[0, 0] == 'X' && tiktaktoeField[1, 0] == 'X' && tiktaktoeField[2, 0] == 'X') ||
                    (tiktaktoeField[0, 1] == 'X' && tiktaktoeField[1, 1] == 'X' && tiktaktoeField[2, 1] == 'X') ||
                    (tiktaktoeField[0, 2] == 'X' && tiktaktoeField[1, 2] == 'X' && tiktaktoeField[2, 2] == 'X') ||
                        (tiktaktoeField[0, 0] == 'X' && tiktaktoeField[1, 1] == 'X' && tiktaktoeField[2, 2] == 'X') ||
                        (tiktaktoeField[0, 2] == 'X' && tiktaktoeField[1, 1] == 'X' && tiktaktoeField[2, 0] == 'X'))

                {
                    Console.WriteLine("First Player Won! :)");
                    break;
                }
                else if ((tiktaktoeField[0, 0] == 'O' && tiktaktoeField[0, 1] == 'O' && tiktaktoeField[0, 2] == 'O') ||
                    (tiktaktoeField[1, 0] == 'O' && tiktaktoeField[1, 1] == 'O' && tiktaktoeField[1, 2] == 'O') ||
                     (tiktaktoeField[2, 0] == 'O' && tiktaktoeField[2, 1] == 'O' && tiktaktoeField[2, 2] == 'O') ||
                    (tiktaktoeField[0, 0] == 'O' && tiktaktoeField[1, 0] == 'O' && tiktaktoeField[2, 0] == 'O') ||
                    (tiktaktoeField[0, 1] == 'O' && tiktaktoeField[1, 1] == 'O' && tiktaktoeField[2, 1] == 'O') ||
                    (tiktaktoeField[0, 2] == 'O' && tiktaktoeField[1, 2] == 'O' && tiktaktoeField[2, 2] == 'O') ||
                        (tiktaktoeField[0, 0] == 'O' && tiktaktoeField[1, 1] == 'O' && tiktaktoeField[2, 2] == 'O') ||
                        (tiktaktoeField[0, 2] == 'O' && tiktaktoeField[1, 1] == 'O' && tiktaktoeField[2, 0] == 'O'))

                {
                    Console.WriteLine("Second Player Won! :)");
                    break;
                }
                 
                PrintArray(tiktaktoeField);

                turn++;

                if (CheckIfDraw(tiktaktoeField, count))
                {
                    Console.WriteLine("Draw! Let's go again? Y/N :)");

                    char answer = char.Parse(Console.ReadLine());

                    if (answer == 'Y')
                    {
                        InitializeField(tiktaktoeField);
                        PrintArray(tiktaktoeField);
                        turn = 1;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("End of game, see ya!");
                        return;
                    }

                }
            }

        }

        private static void InitializeField(char[,] tiktaktoeField)
        {
            for (int row = 0; row < tiktaktoeField.GetLength(0); row++)
            {

                for (int col = 0; col < tiktaktoeField.GetLength(1); col++)
                {
                    tiktaktoeField[row, col] = '-';
                }

            }
        }

        private static bool CheckIfDraw(char[,] tiktaktoeField, int count)
        {
            for (int i = 0; i < tiktaktoeField.GetLength(0); i++)
            {
                for (int j = 0; j < tiktaktoeField.GetLength(1); j++)
                {
                    if (tiktaktoeField[i, j] == '-')
                    {
                        count++;
                    }
                }
            }

            if (count == 0)
            {
                return true;
            }

            return false;
        }

        private static int[] MoveAroundFirstPlayer(int[] playerCoordinates, char[,] tiktaktoeField, ConsoleKeyInfo inputKey)
        {

            if (inputKey.Key == ConsoleKey.LeftArrow)
            {
                playerCoordinates[1]--;
            }
            else if (inputKey.Key == ConsoleKey.RightArrow)
            {
                playerCoordinates[1]++;
            }
            else if (inputKey.Key == ConsoleKey.UpArrow)
            {
                playerCoordinates[0]--;
            }
            else if (inputKey.Key == ConsoleKey.DownArrow)
            {
                playerCoordinates[0]++;
            }

            return playerCoordinates;
        }

        private static int[] MoveAroundSecondPlayer(int[] playerCoordinates, char[,] tiktaktoeField, ConsoleKeyInfo inputKey)
        {

            if (inputKey.Key == ConsoleKey.LeftArrow)
            {
                playerCoordinates[3]--;
            }
            else if (inputKey.Key == ConsoleKey.RightArrow)
            {
                playerCoordinates[3]++;
            }
            else if (inputKey.Key == ConsoleKey.UpArrow)
            {
                playerCoordinates[2]--;
            }
            else if (inputKey.Key == ConsoleKey.DownArrow)
            {
                playerCoordinates[2]++;
            }

            return playerCoordinates;
        }

        private static void ClearMatrix(char[,] tiktaktoeField)
        {
            for (int i = 0; i < tiktaktoeField.GetLength(0); i++)
            {
                for (int j = 0; j < tiktaktoeField.GetLength(1); j++)
                {
                    if (tiktaktoeField[i, j] == '1' || tiktaktoeField[i, j] == '2')
                    {
                        tiktaktoeField[i, j] = '-';
                    }
                }
            }
        }

        private static void PrintArray(char[,] tiktaktoeField)
        {
            for (int i = 0; i < tiktaktoeField.GetLength(0); i++)
            {
                for (int j = 0; j < tiktaktoeField.GetLength(1); j++)
                {
                    Console.Write(tiktaktoeField[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }

}
