namespace ToyRobotSimulator.Core.RobotCommands
{
    public class PlaceCommand : ICommand
    {
        private const int COMMAND_ARGUMENTS_LENGTH = 3;
        private const int X_ARGUMENT_POSITION = 1;
        private const int Y_ARGUMENT_POSITION = 2;

        public Position? Position { get; set; }

        public PlaceCommand(string[] commandArguments)
        {
            if(commandArguments.Length < COMMAND_ARGUMENTS_LENGTH)
                throw new ArgumentException("Invalid X and Y values");

            if (!int.TryParse(commandArguments[X_ARGUMENT_POSITION], out int x))
                throw new ArgumentException($"Invalid X value {x}");

            if (!int.TryParse(commandArguments[Y_ARGUMENT_POSITION], out int y))
                throw new ArgumentException($"Invalid Y value {y}");

            if (x < 0)
                throw new ArgumentException($"Invalid X value {x}");

            if (y < 0)
                throw new ArgumentException($"Invalid Y value {y}");

            Position = new Position(x, y);
        }


        public void Execute(ToyRobot toyRobot)
        {
            toyRobot.Position = Position;
        }
    }
}

