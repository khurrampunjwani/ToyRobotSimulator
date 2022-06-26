using ToyRobotSimulator.Core.RobotCommands;

namespace ToyRobotSimulator.Tests
{

    public class LeftCommandTests
    {
        [Theory]
        [InlineData(0, 1)]
        public void Create_NegativeX_ThrowsInvalidOperationException(int x, int y)
        {
            var command = new string[] { "PLACE", x.ToString(), y.ToString() };

            var toyRobot = new ToyRobot();

            var place = CommandFactory.Create(command);
            place.Execute(toyRobot);

            var left = CommandFactory.Create(new string[] { "LEFT" });

            var leftExecution = () => left.Execute(toyRobot);

            Assert.Throws<InvalidOperationException>(leftExecution);
        }


        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(9, 3)]
        public void Create_ValidX_TurnsLeft(int x, int y)
        {
            var command = new string[] { "PLACE", x.ToString(), y.ToString() };

            var toyRobot = new ToyRobot();

            var place = CommandFactory.Create(command);
            place.Execute(toyRobot);

            var left = CommandFactory.Create(new string[] { "LEFT" });
            left.Execute(toyRobot);

            Assert.Equal(x - 1, toyRobot?.Position?.X);
            Assert.Equal(y, toyRobot?.Position?.Y);

        }
    }
}

