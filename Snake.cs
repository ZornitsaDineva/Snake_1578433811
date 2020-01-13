using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    class Snake
    {
        private Queue<Position> snakeElements;

        private byte right = 0;
        private byte left = 1;
        private byte down = 2;
        private byte up = 3;

        private Position[] directions = new Position[]
        {
            new Position(0, 1), //right
            new Position(0, -1), //left
            new Position(1, 0), //down
            new Position(-1, 0), //up
        };

        public Snake()
        {
            snakeElements = new Queue<Position>();
            for (int i = 0; i <= 5; i++)
            {
                snakeElements.Enqueue(new Position(0, i));
            }
        }

        public bool Contains(Position p)
        {
            return snakeElements.Contains(p);
        }

        public void Show()
        {
            foreach (Position position in snakeElements)
            {
                Console.SetCursorPosition(position.col, position.row);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("*");
            }
        }

        public void Advance(int direction, Food food, Obstacles obstacles)
        {
            Position snakeHead = snakeElements.ToArray()[snakeElements.Count - 1];
            Position nextDirection = directions[direction];
            Position snakeNewHead = new Position(snakeHead.row + nextDirection.row, snakeHead.col + nextDirection.col);

            if (snakeNewHead.col < 0) snakeNewHead.col = Console.WindowWidth - 1;
            if (snakeNewHead.row < 0) snakeNewHead.row = Console.WindowHeight - 1;
            if (snakeNewHead.row >= Console.WindowHeight) snakeNewHead.row = 0;
            if (snakeNewHead.col >= Console.WindowWidth) snakeNewHead.col = 0;


            if (snakeElements.Contains(snakeNewHead) || obstacles.Contains(snakeNewHead))
            {
                /*
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Game over!");

                int userPoints = ((snakeElements.Count - 6) * 100);// - negativePoints;

                userPoints = Math.Max(userPoints, 0);
                Console.WriteLine("Your points are :{0}", userPoints);
                */
                throw new Exception("finished");
            }

            Console.SetCursorPosition(snakeHead.col, snakeHead.row);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("*");

            snakeElements.Enqueue(snakeNewHead);
            Console.SetCursorPosition(snakeNewHead.col, snakeNewHead.row);
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (direction == right) Console.Write(">");
            if (direction == left) Console.Write("<");
            if (direction == down) Console.Write("v");
            if (direction == up) Console.Write("^");

            if (snakeNewHead.Equals(food.Position))
            {
                food.Create();
                food.Show();
                //sleepTime--;
                obstacles.AddOne(this, food);
            }
            else
            {
                //moving
                Position last = snakeElements.Dequeue();
                Console.SetCursorPosition(last.col, last.row);
                Console.Write(" ");
            }
        }
        public int GetSize()
        {
            return snakeElements.Count;
        }

    }
}
