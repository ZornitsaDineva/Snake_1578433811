using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    class Food
    {
        private int foodCreationTime;
        private int foodMoveTime = 8000;
        Position position;
        private Random randomNumbersGenerator = new Random();
        private Snake snake;
        private Obstacles obstacles;

        public Food(Snake snake, Obstacles obstacles)
        {
            this.snake = snake;
            this.obstacles = obstacles;
        }

        public Position Position { get => position; set => position = value; }

        public void Create()
        {
            foodCreationTime = Environment.TickCount;

            do
            {
                position = new Position(randomNumbersGenerator.Next(0, Console.WindowHeight), randomNumbersGenerator.Next(0, Console.WindowWidth));
            }
            while (snake.Contains(position) || obstacles.Contains(position));
        }

        public void Show()
        {
            Console.SetCursorPosition(position.col, position.row);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@");
        }

        public bool IsTimeToMove()
        {
            return Environment.TickCount - foodCreationTime >= foodMoveTime;
        }

        public void Hide()
        {
            Console.SetCursorPosition(position.col, position.row);
            Console.Write(" ");
        }
    }
}
