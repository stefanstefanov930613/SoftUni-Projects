using System;

namespace Helen_s_Abduction
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int rowsCount = int.Parse(Console.ReadLine());
            char[][] field = new char[rowsCount][];
            int parisRow = 0;
            int parisCol = 0;
            int helenRow = 0;
            int helenCol = 0;

            InitializeMatrix(field);

            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'P')
                    {
                        parisRow = row;
                        parisCol = col;
                    }
                    if (field[row][col] == 'H')
                    {
                        helenRow = row;
                        helenCol = col;
                    }
                }
            }
             
            while (true)
            {


                var commands = Console.ReadLine().Split(" ");

                string direction = commands[0];
                int spartanRow = int.Parse(commands[1]);
                int spartanCol = int.Parse(commands[2]);

                field[spartanRow][spartanCol] = 'S';

                field[parisRow][parisCol] = '-';

                switch (direction)
                {
                    case "up": if (parisRow - 1 >= 0) parisRow--; break;
                    case "down": if (parisRow + 1 < field.Length) parisRow++; break;
                    case "left": if (parisCol - 1 >= 0) parisCol--; break;
                    case "right": if (parisCol + 1 < field[parisRow].Length) parisCol++; break;

                    default:
                        break;

                }

                energy--;

                if (energy <= 0)
                {
                    field[parisRow][parisCol] = 'X';
                    Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
                    break;
                }

                if (field[parisRow][parisCol] == 'S')
                {
                    energy -= 2;

                    if (energy <= 0)
                    {
                        field[parisRow][parisCol] = 'X';
                        Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
                        break;
                    }

                }
                else if (field[parisRow][parisCol] == 'H')
                {
                    field[parisRow][parisCol] = '-';
                    Console.WriteLine();
                    Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
                    break;
                }


                field[parisRow][parisCol] = 'P';

            }
            
            PrintArray(field);
        }

        private static void PrintArray(char[][] field)
        {
            for (int i = 0; i < field.Length; i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    Console.Write(field[i][j]);
                }

                Console.WriteLine();
            }
        }

        private static void InitializeMatrix(char[][] field)
        {
            for (int row = 0; row < field.Length; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < currentRow.Length; col++)
                {
                    char currentSymbol = currentRow[col];
                }

                field[row] = currentRow;
            }
        }
    }
}
