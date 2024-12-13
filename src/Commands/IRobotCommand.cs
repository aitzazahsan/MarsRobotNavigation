namespace MarRobotNavigation.Commands
{
    using MarRobotNavigation.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRobotCommand
    {
        void Execute(Robot robot, Grid grid);
        bool CanExecute(string instChar);

    }
}
