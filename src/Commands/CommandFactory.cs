namespace MarRobotNavigation.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public class CommandFactory
    {
        private readonly List<IRobotCommand> _commandMap;

        public CommandFactory()
        {
            _commandMap = new List<IRobotCommand>();
        }

        public IRobotCommand? GetCommand(string instChar)
        {
            return _commandMap.FirstOrDefault(x => x.CanExecute(instChar));
        }
        public void RegisterCommands()
        {
            var commandTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(IRobotCommand).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            foreach (var type in commandTypes)
            {
                var command = Activator.CreateInstance(type) as IRobotCommand;
                if(command != null)
                _commandMap.Add(command);
            }
        }
    }
}
