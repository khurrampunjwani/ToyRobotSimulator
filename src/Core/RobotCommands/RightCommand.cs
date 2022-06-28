namespace ToyRobotSimulator.Core.RobotCommands
{
    public class RightCommand : ICommand
    {
        public void Execute(TableTop tableTop)
        {
            var toyRobot = tableTop.ToyRobot;

            if (toyRobot is null || toyRobot.Direction is null)
                throw new InvalidOperationException("Please place the robot on the table first by using the pace command.");

            var directions = (int[])Enum.GetValues(typeof(Direction));

            var currentDirectionIndex = (int)toyRobot.Direction;
            var newDirectionIndex = (currentDirectionIndex + 1) % directions.Length;

            var newDirection = Enum.Parse<Direction>(newDirectionIndex.ToString());

            toyRobot.Direction = newDirection;
        }
    }
}

