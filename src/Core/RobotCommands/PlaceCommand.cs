namespace ToyRobotSimulator.Core.RobotCommands
{
    public class PlaceCommand : ICommand
    {
        public Position? Position { get; set; }

        public PlaceCommand(string[] commandArguments)
        {
            if(commandArguments.Length<1)
                throw new ArgumentException("Invalid X and Y values");

            var args = new string[commandArguments.Length - 1];
            commandArguments.CopyTo(args, 1);

            if (!int.TryParse(args[0], out int x))
                throw new ArgumentException($"Invalid X value {x}");

            if (!int.TryParse(args[0], out int y))
                throw new ArgumentException($"Invalid Y value {y}");

            Position = new Position(x, y);
        }


        public void Execute(ToyRobot toyRobot)
        {
            toyRobot.Position = Position;
        }
    }
}

