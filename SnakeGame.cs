using System;
using System.Collections.Generic;
using System.Media;
using System.Threading;

namespace SnakeGame
{
    class SnakeGame
    {
        private Food food;
        private Snake snake;
        private Obstacles obstacles;
        private Level level;

        private byte right = 0;
        private byte left = 1;
        private byte down = 2;
        private byte up = 3;

        private int negativePoints = 0;
        private double sleepTime = 100;

        private Random randomNumbersGenerator = new Random();


        public void Run()
        {
            startBackgroundMusic();

            Console.BufferHeight = Console.WindowHeight;
            Console.CursorVisible = false;

            snake = new Snake();
            snake.Show();

            obstacles = new Obstacles();
            obstacles.Show();

            food = new Food(snake, obstacles);
            food.Create();
            food.Show();

            level = new Level();

            int direction = right;

            try
            {
                while (true)
                {
                    //negativePoints++;

                    direction = updateDirection(direction);
                    snake.Advance(direction, food, obstacles);

                    if (food.IsTimeToMove())
                    {
                        food.Hide();
                        food.Create();
                        food.Show();
                    }
                    
                    level.UpdatePoints(snake);

                    if (level.LevelChanged)
                    {
                        level.ShowLevel();
                        obstacles.AddMore(snake,food);
                        sleepTime -= 2;

                    }
                    sleepTime -= 0.01;
                    Thread.Sleep((int)sleepTime);
                }
            }
            catch (Exception e)
            {

                level.UpdatePoints(snake);
                level.ShowGameOver();

                //int userPoints = ((snakeElements.Count - 6) * 100);// - negativePoints;
                /*
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Game over!");

                userPoints = Math.Max(userPoints, 0);
                Console.WriteLine("Your points are :{0}", userPoints);
                */

            }
        }

        private int updateDirection(int direction)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();
                if (userInput.Key == ConsoleKey.LeftArrow)
                {
                    if (direction != right) direction = left;
                }
                if (userInput.Key == ConsoleKey.RightArrow)
                {
                    if (direction != left) direction = right;
                }
                if (userInput.Key == ConsoleKey.UpArrow)
                {
                    if (direction != down) direction = up;
                }
                if (userInput.Key == ConsoleKey.DownArrow)
                {
                    if (direction != up) direction = down;
                }
            }

            return direction;
        }

        private static void startBackgroundMusic()
        {
            SoundPlayer player = new SoundPlayer
            {
                SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "snake_music.wav"
            };
            player.PlayLooping();
        }
    }
}
