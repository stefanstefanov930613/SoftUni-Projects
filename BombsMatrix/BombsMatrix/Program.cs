using System;
using System.Linq;

namespace BombsMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            var bombsField = new int[matrixSize, matrixSize];
            InitializeMatrix(bombsField);
            var coordinates = Console.ReadLine().Split(" ").ToArray();
            int aliveCells = 0;
            int aliveCellsSum = 0;

            for (int i = 0; i < coordinates.Length; i++)
            {
                var coordinatesData = coordinates[i].Split(",");

                int currentRow = int.Parse(coordinatesData[0]);
                int currentCol = int.Parse(coordinatesData[1]);

                int damage = bombsField[currentRow, currentCol];

                int up = currentRow - 1;
                int down = currentRow + 1;
                int left = currentCol - 1;
                int right = currentCol + 1;
                ExplodeBombs(bombsField, currentRow, currentCol, damage, up, down, left, right);

            }
             
            BombsClear(bombsField, coordinates);
            CheckForAliveCells(bombsField, ref aliveCells, ref aliveCellsSum);
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {aliveCellsSum}");
            PrintMatrix(bombsField);
        }

        private static void ExplodeBombs(int[,] bombsField, int currentRow, int currentCol, int damage, int up, int down, int left, int right)
        {
            if (up >= 0)
            {
                if (bombsField[currentRow - 1, currentCol] > 0)
                {
                    bombsField[currentRow - 1, currentCol] -= damage;
                }
            }
            if (down < bombsField.GetLength(0))
            {
                if (bombsField[currentRow + 1, currentCol] > 0)
                {
                    bombsField[currentRow + 1, currentCol] -= damage;
                }
            }
            if (right < bombsField.GetLength(1))
            {
                if (bombsField[currentRow, currentCol + 1] > 0)
                {
                    bombsField[currentRow, currentCol + 1] -= damage;
                }
            }
            if (left >= 0)
            {
                if (bombsField[currentRow, currentCol - 1] > 0)
                {
                    bombsField[currentRow, currentCol - 1] -= damage;
                }
            }
            if (currentRow - 1 >= 0 && currentCol + 1 < bombsField.GetLength(1))
            {
                if (bombsField[currentRow - 1, currentCol + 1] > 0)
                {
                    bombsField[currentRow - 1, currentCol + 1] -= damage;
                }
            }
            if (currentRow + 1 < bombsField.GetLength(0) && currentCol + 1 < bombsField.GetLength(1))
            {
                if (bombsField[currentRow + 1, currentCol + 1] > 0)
                {
                    bombsField[currentRow + 1, currentCol + 1] -= damage;
                }
            }
            if (currentRow + 1 < bombsField.GetLength(0) && currentCol - 1 >= 0)
            {
                if (bombsField[currentRow + 1, currentCol - 1] > 0)
                {
                    bombsField[currentRow + 1, currentCol - 1] -= damage;
                }
            }
            if (currentRow - 1 >= 0 && currentCol - 1 >= 0)
            {
                if (bombsField[currentRow - 1, currentCol - 1] > 0)
                {
                    bombsField[currentRow - 1, currentCol - 1] -= damage;
                }
            }
        }

        private static void CheckForAliveCells(int[,] bombsField, ref int aliveCells, ref int aliveCellsSum)
        {
            foreach (var bomb in bombsField)
            {
                if (bomb > 0)
                {
                    aliveCells++;
                    aliveCellsSum += bomb;
                }
            }
        }

        private static void BombsClear(int[,] bombsField, string[] coordinates)
        {
            for (int i = 0; i < coordinates.Length; i++)
            {
                var inputData = coordinates[i].Split(",");

                int row = int.Parse(inputData[0]);
                int col = int.Parse(inputData[1]);

                bombsField[row, col] = 0;

            }
        }

        private static void InitializeMatrix(int[,] bombsField)
        {
            for (int row = 0; row < bombsField.GetLength(0); row++)
            {
                var inputData = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < bombsField.GetLength(1); col++)
                {
                    bombsField[row, col] = inputData[col];
                }
            }
        }

        private static void PrintMatrix(int[,] bombsField)
        {
            for (int i = 0; i < bombsField.GetLength(0); i++)
            {

                for (int j = 0; j < bombsField.GetLength(1); j++)
                {
                    Console.Write(bombsField[i, j] + " ");

                }

                Console.WriteLine();
            }
        }
    }
}
