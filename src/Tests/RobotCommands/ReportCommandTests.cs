using ToyRobotSimulator.Core.RobotCommands;

namespace ToyRobotSimulator.Tests
{
    public class ReportCommandTests
    {
        private readonly TableTop _tableTop = new();

        public void Report_Valid_ReturnsCommand(int x, int y)
        {
            var command = new string[] { "REPORT" };

            var report = CommandFactory.Create(command);
            report.Execute(_tableTop);

            Assert.IsType<ReportCommand>(report);
        }
    }
}

