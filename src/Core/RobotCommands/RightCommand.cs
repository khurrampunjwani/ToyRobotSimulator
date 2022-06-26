namespace ToyRobotSimulator.Core.RobotCommands
{
    public class RightCommand : ICommand
    {
        public void Execute(ToyRobot toyRobot)
        {
            if (toyRobot is null || toyRobot.Position is null)
                throw new InvalidOperationException("Robot is null");

            toyRobot.Position = toyRobot.Position with
            {
                X = toyRobot.Position.X + 1
            };
        }
    }
}

