using System;

namespace SnakeGame
{
    public class Position
    {
        public int row;
        public int col;
        public Position()
        {
        }

        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   row == position.row &&
                   col == position.col;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(row, col);
        }
    }
}

