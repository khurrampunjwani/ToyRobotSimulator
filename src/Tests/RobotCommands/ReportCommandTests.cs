using ToyRobotSimulator.Core.RobotCommands;

namespace ToyRobotSimulator.Tests
{

    public class ReportCommandTests
    {
        public void Report_Valid_ReturnsCommand(int x, int y)
        {
            var command = new string[] { "REPORT" };

            var report = CommandFactory.Create(command);
            var toyRobot = new ToyRobot();
            report.Execute(toyRobot);

            Assert.IsType<ReportCommand>(report);
        }
    }
}

