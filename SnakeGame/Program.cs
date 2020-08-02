using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace SnakeGame
{
    struct Position
    {
        public int row;
        public int col;

        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            byte right = 0;
            byte left = 1;
            byte up = 3;
            byte down = 2;

            Position[] positions = new Position[]
            {
                new Position(0,1), //right
                new Position(0,-1), //left
                new Position(1,0), //down
                new Position(-1,0), //up
            };

            int sleepTime = 100;
            int direction = right;
            int foodEaten = 0;
            Random randomNumberGenerator = new Random();
            Console.BufferHeight = Console.WindowHeight;
            Position food = new Position(randomNumberGenerator.Next(0, Console.WindowHeight),
            randomNumberGenerator.Next(0, Console.WindowWidth));
            Console.SetCursorPosition(food.col, food.row);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("@");
            Position counter = new Position(Console.WindowTop, Console.WindowLeft);
            Console.SetCursorPosition(counter.row, counter.col);
            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("0");

            Queue<Position> snakeElements = new Queue<Position>();

            for (int i = 0; i <= 5; i++)
            {
                snakeElements.Enqueue(new Position(0, i));
            }

            foreach (Position position in snakeElements)
            {
                Console.SetCursorPosition(position.col, position.row);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("*");

            }

            while (true)
            {
                if (Console.KeyAvailable)
                {

                    ConsoleKeyInfo userInput = Console.ReadKey();

                    if (userInput.Key == ConsoleKey.LeftArrow)
                    {
                        if (direction != right)
                        {
                            direction = left;
                        }

                    }
                    if (userInput.Key == ConsoleKey.RightArrow)
                    {
                        if (direction != left)
                        {
                            direction = right;
                        }

                    }
                    if (userInput.Key == ConsoleKey.DownArrow)
                    {
                        if (direction != up)
                        {
                            direction = down;
                        }

                    }
                    if (userInput.Key == ConsoleKey.UpArrow)
                    {
                        if (direction != down)
                        {
                            direction = up;
                        }
                    }
                    if (userInput.Key == ConsoleKey.Spacebar)
                    {
                        Console.ReadKey();
                    }

                }

                Position snakeHead = snakeElements.Last();
                Position nextDirection = positions[direction];
                Position snakeNewHead = new Position(snakeHead.row + nextDirection.row, snakeHead.col + nextDirection.col);

                if (snakeNewHead.row < 0 ||
                    snakeNewHead.col < 0 ||
                    snakeNewHead.row >= Console.WindowHeight ||
                    snakeNewHead.col >= Console.WindowWidth ||
                    snakeElements.Contains(snakeNewHead))
                {
                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Game over!");
                    Console.WriteLine("Press ESC to exit the game: ");
                    ConsoleKeyInfo pressAnyKey;

                    do
                    {
                        pressAnyKey = Console.ReadKey();

                        if (pressAnyKey.Key == ConsoleKey.Escape)
                        {
                            return;
                        }
                        else
                        {

                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Wrong key!");

                        }
                    }
                    while (pressAnyKey.Key != ConsoleKey.Escape);


                }
 
                snakeElements.Enqueue(snakeNewHead);
                Console.SetCursorPosition(snakeNewHead.col, snakeNewHead.row);

                if (direction == right)
                {
                    Console.Write(">");
                }
                if (direction == left)
                {
                    Console.Write("<");
                }
                if (direction == up)
                {
                    Console.Write("^");

                }
                if (direction == down)
                {
                    Console.Write("V");
                }



                if (snakeNewHead.col == food.col && snakeNewHead.row == food.row)
                {
                    food = new Position(randomNumberGenerator.Next(0, Console.WindowHeight),
                    randomNumberGenerator.Next(0, Console.WindowWidth));
                    foodEaten++;
                    sleepTime--;

                }
                else
                {
                    snakeElements.Dequeue();
                }

                Console.Clear();

                foreach (Position position in snakeElements)
                {
                    Console.SetCursorPosition(position.col, position.row);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("*");
                }

                Console.SetCursorPosition(food.col, food.row);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("@");
                Console.SetCursorPosition(counter.row, counter.col);
                Console.Write(foodEaten);

                Thread.Sleep(sleepTime);
            }

        }

    }
}
