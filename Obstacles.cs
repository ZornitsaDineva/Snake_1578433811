using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    class Obstacles
    {
        private List<Position> obstacles;
        private Random randomNumbersGenerator = new Random();

        public Obstacles()
        {
            obstacles = new List<Position>()
            {
                new Position(12,12),
                new Position(14,20),
                new Position(7,7),
                new Position(22,22),
                new Position(6,9),
             };
        }

        public void Show()
        {
            foreach (Position obstacle in obstacles)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(obstacle.col, obstacle.row);
                Console.Write("=");
            }
        }

        public bool Contains(Position p)
        {
            return obstacles.Contains(p);
        }

        public void AddOne(Snake snake, Food food)
        {
            Position obstacle = new Position();
            do
            {
                obstacle = new Position(randomNumbersGenerator.Next(0, Console.WindowHeight), randomNumbersGenerator.Next(0, Console.WindowWidth));
            }
            while (snake.Contains(obstacle) || obstacles.Contains(obstacle) || food.Position.Equals(obstacle));
            obstacles.Add(obstacle);

            // show
            Console.SetCursorPosition(obstacle.col, obstacle.row);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("=");
        }

        internal void AddMore(Snake snake, Food food)
        {
            for(int i=0; i < 10; i++)
            {
                AddOne(snake, food);
            }
        }
    }
}

