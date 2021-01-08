using System;
using System.Linq;
using System.Text;

namespace BookWorm
{
    class Program
    {
        static void Main(string[] args)
        {

            string inputString = Console.ReadLine();
            var sb = new StringBuilder(inputString);
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] field = new char[matrixSize, matrixSize];
            int playerRow = 0;
            int playerCol = 0;

            InitializeMatrix(field, ref playerRow, ref playerCol);

            while (true)
            {

                string direction = Console.ReadLine();
                field[playerRow, playerCol] = '-';

                if (direction == "end")
                {
                    field[playerRow, playerCol] = 'P';
                    break;
                }

                MovePlayer(ref playerRow, ref playerCol, direction);

                if (playerRow >= 0 && playerRow < field.GetLength(0)
                && playerCol >= 0 && playerCol < field.GetLength(1))
                {

                    if (char.IsLetter(field[playerRow, playerCol]))
                    {
                        sb.Append(field[playerRow, playerCol]);

                    }

                    field[playerRow, playerCol] = 'P';
                }
                else
                {

                    if (sb.Length > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }

                    if (playerRow < 0)
                    {
                        playerRow = 0;
                    }
                    else if (playerRow > field.GetLength(0) - 1)
                    {
                        playerRow = field.GetLength(0) - 1;
                    }
                    else if (playerCol < 0)
                    {
                        playerCol = 0;
                    }
                    else if (playerCol > field.GetLength(1) - 1)
                    {
                        playerCol = field.GetLength(1) - 1;
                    }

                    field[playerRow, playerCol] = 'P';

                }

            }

            Console.WriteLine(sb.ToString());
            PrintArray(field);
        }

        private static void MovePlayer(ref int playerRow, ref int playerCol, string direction)
        {
            if (direction == "right")
            {
                playerCol++;
            }
            else if (direction == "left")
            {
                playerCol--;
            }
            else if (direction == "up")
            {
                playerRow--;
            }
            else if (direction == "down")
            {
                playerRow++;
            }
        }

        private static void InitializeMatrix(char[,] field, ref int playerRow, ref int playerCol)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                var inputData = Console.ReadLine().ToCharArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = inputData[col];

                    if (field[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }

            }
        }

        private static void PrintArray(char[,] field)
        {

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }

                Console.WriteLine();
            }

        }
    }
}
