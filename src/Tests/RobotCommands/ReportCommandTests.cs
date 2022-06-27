namespace ToyRobotSimulator.Tests
{
    public class ReportCommandTests
    {
        private readonly TableTop _tableTop = new();

        public void Report_Valid_ReturnsCommand()
        {
            var report = CommandHelper.CreateReportCommand();
            report.Execute(_tableTop);

            Assert.IsType<ReportCommand>(report);
        }
    }
}

