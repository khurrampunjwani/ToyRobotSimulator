namespace ToyRobotSimulator.Core.RobotCommands
{
    public class CommandFactory
    {
        public static ICommand Create(params string[] commandArguments)
        {
            if (commandArguments.Length == 0
                || string.IsNullOrWhiteSpace(commandArguments[0]))
            {
                throw new InvalidOperationException($"Please enter valid command");
            }

            var command = commandArguments[0].ToUpper();

            return command switch
            {
                "PLACE" => new PlaceCommand(commandArguments[1]),
                "REPORT" => new ReportCommand(),
                "RIGHT" => new RightCommand(),
                "LEFT" => new LeftCommand(),
                "MOVE" => new MoveCommand(),
                _ => throw new InvalidOperationException($"Invalid command {command}"),
            };
        }
    }
}

