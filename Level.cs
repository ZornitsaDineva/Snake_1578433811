using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SnakeGame
{
    class Level
    {
        private int userPoints;
        bool levelChanged;

        public int UserPoints { get => userPoints; set => userPoints = value; }
        public bool LevelChanged { get => levelChanged; set => levelChanged = value; }

        internal void UpdatePoints(Snake snake)
        {
            int NewUserPoints = (snake.GetSize() - 6) * 100;// - negativePoints;
            NewUserPoints = Math.Max(NewUserPoints, 0);
            levelChanged = UserPoints < 200 && NewUserPoints >= 200;
            UserPoints = NewUserPoints;
        }

        internal void ShowGameOver()
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Game over!");
            Console.WriteLine("Your points are: {0}", userPoints);
        }

        public int GetLevelNumber()
        {
            if (userPoints >= 200)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        internal void ShowLevel()
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Level 2 !");
            Console.WriteLine("Your points are: {0}", userPoints);

            Thread.Sleep(2000);


        }
    }
}



