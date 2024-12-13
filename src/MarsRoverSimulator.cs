namespace MarRobotNavigation
{
    using MarRobotNavigation.Commands;
    using MarRobotNavigation.Model;
    using System;

    public class MarsRoverSimulator
    {
        private readonly CommandFactory _commandFactory;
        private Robot _robot;
        private Grid _grid;

        public MarsRoverSimulator(Robot robot, Grid grid, CommandFactory factory)
        {
            _robot = robot;
            _grid = grid;
            _commandFactory = factory;
        }

        public void Run(string commandString)
        {
            foreach (var command in commandString)
            {
                if (_robot.IsLost)
                    break;

                var executableCommand = _commandFactory.GetCommand(command.ToString());
                executableCommand?.Execute(_robot, _grid);
            }

            Console.WriteLine(_robot);
        }
    }
}
