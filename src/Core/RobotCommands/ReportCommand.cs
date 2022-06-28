namespace ToyRobotSimulator.Core.RobotCommands
{
    public class ReportCommand : ICommand
    {
        public void Execute(TableTop tableTop)
        {
            var toyRobot = tableTop.ToyRobot;

            if (!toyRobot.IsPlaced)
                throw new InvalidOperationException("Please place the robot on the table first by using the pace command.");

            Console.WriteLine($"{toyRobot.Position?.X}, " +
                $"{toyRobot.Position?.Y}, " +
                $"{toyRobot.Direction}");
        }
    }
}

