using System.Text.RegularExpressions;

namespace ToyRobotSimulator.Core.RobotCommands
{
    public class PlaceCommand : ICommand
    {
        private const int MINIMUM_COMMAND_ARGUMENTS_LENGTH = 2;
        private const int X_ARGUMENT_POSITION = 0;
        private const int Y_ARGUMENT_POSITION = 1;
        private const int DIRECTION_ARGUMENT_POSITION = 2;

        private readonly Position _position;
        private readonly Direction? _direction;

        public PlaceCommand(string command)
        {
            if (!IsCommandValid(command))
                throw new ArgumentException("Please enter place command in the proper format");

            var commandArguments = command.Split(",");

            var x = int.Parse(commandArguments[X_ARGUMENT_POSITION]);
            var y = int.Parse(commandArguments[Y_ARGUMENT_POSITION]);
            _position = new Position(x, y);

            if (commandArguments.Length > MINIMUM_COMMAND_ARGUMENTS_LENGTH)
                _direction = Enum.Parse<Direction>(commandArguments[DIRECTION_ARGUMENT_POSITION], true);
        }


        public void Execute(TableTop tableTop)
        {
            var toyRobot = tableTop.ToyRobot;

            if (_position.X > tableTop.Columns || _position.Y > tableTop.Rows)
                throw new InvalidOperationException("Robot cannot placed outside the table");

            if (!toyRobot.IsPlaced && _direction is null)
                throw new InvalidOperationException("Robot needs direction for initial placement");

            toyRobot.Position = _position;

            if (_direction is not null)
                toyRobot.Direction = _direction;
        }


        private bool IsCommandValid(string command)
        {
            var commandSyntax = $@"^\d+\s*,\s*\d+\s*(,\s*({string.Join("|", Enum.GetNames<Direction>())}))?$";

            return new Regex(commandSyntax, RegexOptions.IgnoreCase)
                .IsMatch(command);
        }
    }
}

