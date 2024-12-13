using MarRobotNavigation.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarRobotNavigation.Services
{
    public class InputParsingService : IInputParsingService
    {
        public void ParseInputs(string[] commands, out Grid grid, out List<Robot> robots, out List<string> commandStrings)
        {
            if (commands == null || commands.Length < 2)
            {
                throw new ArgumentException("Input commands are insufficient.");
            }

            grid = ParseGridDimensions(commands[0]);
            robots = new List<Robot>();
            commandStrings = new List<string>();

            for (int i = 1; i < commands.Length; i += 2)
            {
                if (i + 1 >= commands.Length)
                {
                    throw new ArgumentException($"Mismatch in robot position and command at index {i}. Missing command string.");
                }

                var robot = ParseRobotDetails(commands[i]);
                robots.Add(robot);
                commandStrings.Add(commands[i + 1]);
            }
        }

        private Grid ParseGridDimensions(string gridDimensions)
        {
            var parts = gridDimensions.Split();

            if (parts.Length != 2 ||
                !int.TryParse(parts[0], out var width) ||
                !int.TryParse(parts[1], out var height) ||
                width < 0 || width > 50 ||
                height < 0 || height > 50)
            {
                throw new ArgumentException("Grid dimensions are invalid. Max values are 50.");
            }

            return new Grid(width, height);
        }

        private Robot ParseRobotDetails(string robotDetails)
        {
            var parts = robotDetails.Split();

            if (parts.Length != 3 ||
                !int.TryParse(parts[0], out var x) ||
                !int.TryParse(parts[1], out var y))
            {
                throw new ArgumentException($"Invalid robot details: {robotDetails}");
            }

            if (!Enum.TryParse(typeof(Direction), parts[2], true, out var direction))
            {
                throw new ArgumentException($"Invalid direction: {parts[2]}");
            }

            return new Robot(x, y, (Direction)direction);
        }
    }
}