namespace ToyRobotSimulator.Core.RobotCommands
{
    public class CommandFactory
    {
        public static ICommand Create(string[] commandArguments)
        {
            if(commandArguments.Length == 0
                || string.IsNullOrWhiteSpace(commandArguments[0]))
            {
                throw new InvalidOperationException($"Please enter valid command");
            }

            var command = commandArguments[0];

            return command switch
            {
                "PLACE" => new PlaceCommand(commandArguments),
                "REPORT" => new ReportCommand(),
                _ => throw new InvalidOperationException("Invalid command"),
            };
        }
    }
}

