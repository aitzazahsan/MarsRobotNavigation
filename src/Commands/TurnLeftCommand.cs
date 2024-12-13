namespace MarRobotNavigation.Commands
{
    using MarRobotNavigation.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TurnLeftCommand : BaseCommand
    {
        public TurnLeftCommand() : base("L") { }

        public override void Execute(Robot robot, Grid grid)
        {
            robot.TurnLeft();
        }
    }
}
