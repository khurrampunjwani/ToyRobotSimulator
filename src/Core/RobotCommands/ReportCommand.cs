namespace ToyRobotSimulator.Core.RobotCommands
{
    public class ReportCommand : ICommand
    {
        public void Execute(TableTop tableTop)
        {
            var toyRobot = tableTop.ToyRobot;

            Console.WriteLine($"{toyRobot.Position?.X}, " +
                $"{toyRobot.Position?.Y}, " +
                $"{toyRobot.Direction}");
        }
    }
}

