using ToyRobotSimulator.Core.RobotCommands;

namespace ToyRobotSimulator.Tests
{

    public class RightCommandTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(9, 3)]
        public void Create_ValidX_TurnsRight(int x, int y)
        {
            var command = new string[] { "PLACE", x.ToString(), y.ToString() };

            var toyRobot = new ToyRobot();

            var place = CommandFactory.Create(command);
            place.Execute(toyRobot);

            var right = CommandFactory.Create(new string[] { "RIGHT" });
            right.Execute(toyRobot);

            Assert.Equal(x + 1, toyRobot?.Position?.X);
            Assert.Equal(y, toyRobot?.Position?.Y);

        }
    }
}

