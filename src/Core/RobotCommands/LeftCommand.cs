namespace ToyRobotSimulator.Core.RobotCommands
{
    public class LeftCommand : ICommand
    {
        public void Execute(ToyRobot toyRobot)
        {
            if (toyRobot is null || toyRobot.Position is null)
                throw new InvalidOperationException("Robot is null");

            if (toyRobot.Position.X <= 0)
                throw new InvalidOperationException("No space on the left");

            toyRobot.Position = toyRobot.Position with
            {
                X = toyRobot.Position.X - 1
            };
        }
    }
}

