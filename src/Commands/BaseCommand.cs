namespace MarRobotNavigation.Commands
{
    using MarRobotNavigation.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class BaseCommand : IRobotCommand
    {
        private readonly string _commandChar;
        public BaseCommand(string commandChar)  => _commandChar = commandChar;

        public bool CanExecute(string instChar) => _commandChar == instChar;

        public virtual void Execute(Robot robot, Grid grid) { }
    }
}
