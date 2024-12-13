namespace MarRobotNavigation.Commands
{
    using MarRobotNavigation.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TurnRightCommand : BaseCommand
    {
        public TurnRightCommand() : base("R") { }

        public override void Execute(Robot robot, Grid grid)
        {
            robot.TurnRight();
        }
    }
}
