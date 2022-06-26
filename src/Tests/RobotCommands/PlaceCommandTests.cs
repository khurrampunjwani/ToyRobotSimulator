using ToyRobotSimulator.Core.RobotCommands;

namespace ToyRobotSimulator.Tests
{

    public class PlaceCommandTests
    {
        [Fact]
        public void Create_EmptyXCommand_ThrowsArgumentException()
        {
            var command = new string[] { "PLACE", string.Empty, "P" };
            var actual = () => CommandFactory.Create(command);

            Assert.Throws<ArgumentException>(actual);
        }


        [Fact]
        public void Create_EmptyYCommand_ArgumentException()
        {
            var command = new string[] { "PLACE", "1", string.Empty };
            var actual = () => CommandFactory.Create(command);

            Assert.Throws<ArgumentException>(actual);
        }


        [Theory]
        [InlineData(-1, 1)]
        [InlineData(-2, 2)]
        [InlineData(2, -3)]
        public void Create_NegativeXY_ReturnsCommand(int x, int y)
        {
            var command = new string[] { "PLACE", x.ToString(), y.ToString() };
            var actual = () => CommandFactory.Create(command);

            Assert.Throws<ArgumentException>(actual);
        }


        [Theory]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        public void Create_ValidXY_ReturnsCommand(int x, int y)
        {
            var command = new string[] { "PLACE", x.ToString(), y.ToString() };

            var place = CommandFactory.Create(command);
            var toyRobot = new ToyRobot();
            place.Execute(toyRobot);

            Assert.Equal(x, toyRobot?.Position?.X);
            Assert.Equal(y, toyRobot?.Position?.Y);

        }
    }
}

