namespace ToyRobotSimulator.Core.RobotCommands
{
    public class ReportCommand : ICommand
    {
        public void Execute(ToyRobot toyRobot)
        {
            Console.WriteLine($"{toyRobot.Position?.X}, " +
                $"{toyRobot.Position?.Y}, " +
                $"{toyRobot.Direction}");
        }
    }
}

