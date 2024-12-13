namespace MarRobotNavigation.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Robot
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Direction Orientation { get; private set; }
        public bool IsLost { get; private set; } = false;

        public Robot(int x, int y, Direction orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }

        public void Move(Grid grid)
        {
            var (dx, dy) = GetDirectionDelta();
            var newX = X + dx;
            var newY = Y + dy;

            if (grid.IsOffGrid(newX, newY))
            {
                var currentPosition = new Position(X, Y);
                if (!grid.CheckScent(currentPosition))
                {
                    IsLost = true;
                    grid.MarkScent(currentPosition);
                }
            }
            else
            {
                X = newX;
                Y = newY;
            }
        }
        private (int dx, int dy) GetDirectionDelta()
        {
            return Orientation switch
            {
                Direction.N => (0, 1),
                Direction.E => (1, 0),
                Direction.S => (0, -1),
                Direction.W => (-1, 0),
                _ => (0, 0),
            };
        }
        public void TurnLeft()
        {
            Orientation = Orientation switch
            {
                Direction.N => Direction.W,
                Direction.W => Direction.S,
                Direction.S => Direction.E,
                Direction.E => Direction.N,
                _ => Orientation,
            };
        }

        public void TurnRight()
        {
            Orientation = Orientation switch
            {
                Direction.N => Direction.E,
                Direction.E => Direction.S,
                Direction.S => Direction.W,
                Direction.W => Direction.N,
                _ => Orientation,
            };
        }

        public override string ToString()
        {
            return $"{X} {Y} {Orientation}" + (IsLost ? " LOST" : "");
        }
    }
}
