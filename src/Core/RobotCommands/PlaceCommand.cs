namespace ToyRobotSimulator.Core.RobotCommands
{
    public class PlaceCommand : ICommand
    {
        private const int COMMAND_ARGUMENTS_LENGTH = 4;
        private const int X_ARGUMENT_POSITION = 1;
        private const int Y_ARGUMENT_POSITION = 2;
        private const int DIRECTION_ARGUMENT_POSITION = 3;

        private readonly Position _position;
        private readonly Direction? _direction;

        public PlaceCommand(string[] commandArguments)
        {
            if (commandArguments.Length < COMMAND_ARGUMENTS_LENGTH)
                throw new ArgumentException("Invalid place arguments");

            if (!int.TryParse(commandArguments[X_ARGUMENT_POSITION], out int x))
                throw new ArgumentException($"Invalid X value {x}");

            if (!int.TryParse(commandArguments[Y_ARGUMENT_POSITION], out int y))
                throw new ArgumentException($"Invalid Y value {y}");

            string intendedDirection = commandArguments[DIRECTION_ARGUMENT_POSITION];

            if (!string.IsNullOrWhiteSpace(intendedDirection))
            {
                if (!Enum.TryParse<Direction>(intendedDirection, out var direction))
                    throw new ArgumentException($"Invalid direction " +
                        $"{commandArguments[DIRECTION_ARGUMENT_POSITION]}");
                else
                    _direction = direction;
            }

            if (x < 0)
                throw new ArgumentException($"Invalid X value {x}");

            if (y < 0)
                throw new ArgumentException($"Invalid Y value {y}");

            _position = new Position(x, y);
        }


        public void Execute(TableTop tableTop)
        {
            var toyRobot = tableTop.ToyRobot;

            if (!toyRobot.IsPlaced && _direction is null)
                throw new InvalidOperationException("Robot needs direction for initial placement");

            toyRobot.Position = _position;

            if(_direction is not null)
                toyRobot.Direction = _direction;
        }
    }
}

