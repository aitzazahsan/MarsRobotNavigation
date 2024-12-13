namespace MarRobotNavigation.Services
{
    using MarRobotNavigation.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IInputParsingService
    {
        void ParseInputs(string[] args, out Grid grid, out List<Robot> robots, out List<string> commandStrings);
    }
}
