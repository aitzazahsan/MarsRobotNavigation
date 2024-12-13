namespace MarRobotNavigation.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Grid
    {
        public int MaxX { get; }
        public int MaxY { get; }
        private HashSet<Position> scents;

        public Grid(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
            scents = new HashSet<Position>();
        }

        public bool IsOffGrid(int x, int y) => x < 0 || x > MaxX || y < 0 || y > MaxY;

        public bool CheckScent(Position pos) => scents.Contains(pos);

        public void MarkScent(Position pos) => scents.Add(pos);
    }
}
