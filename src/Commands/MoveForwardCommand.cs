namespace MarRobotNavigation.Commands
{
    using MarRobotNavigation.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MoveForwardCommand : BaseCommand
    {
        public MoveForwardCommand() : base("F") { }

        public override void Execute(Robot robot, Grid grid)
        {
            robot.Move(grid);
        }
    }
}
