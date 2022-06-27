using ToyRobotSimulator.Core.RobotCommands;

namespace ToyRobotSimulator.Tests
{
    public class PlaceCommandTests
    {
        private readonly TableTop _tableTop = new();

        [Fact]
        public void Create_EmptyXCommand_ThrowsArgumentException()
        {
            var command = new string[]
            {
                "PLACE",
                string.Empty,
                "P",
                Direction.North.ToString()
            };
            var actual = () => CommandFactory.Create(command);

            Assert.Throws<ArgumentException>(actual);
        }


        [Fact]
        public void Create_EmptyYCommand_ArgumentException()
        {
            var command = new string[]
            {
                "PLACE",
                "1",
                string.Empty,
                Direction.South.ToString()
            };

            var actual = () => CommandFactory.Create(command);

            Assert.Throws<ArgumentException>(actual);
        }


        [Fact]
        public void Create_EmptyDirectionCommand_ArgumentException()
        {
            var command = new string[]
            {
                "PLACE",
                "1",
                "2",
                string.Empty
            };

            var actual = () => CommandFactory.Create(command);

            Assert.Throws<ArgumentException>(actual);
        }


        [Theory]
        [InlineData(-1, 1)]
        [InlineData(-2, 2)]
        [InlineData(2, -3)]
        public void Create_NegativeXY_ReturnsCommand(int x, int y)
        {
            var command = new string[]
            {
                "PLACE",
                x.ToString(),
                y.ToString(),
                Direction.East.ToString()
            };

            var actual = () => CommandFactory.Create(command);

            Assert.Throws<ArgumentException>(actual);
        }


        [Theory]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        public void Create_ValidXY_ReturnsCommand(int x, int y)
        {
            var command = new string[]
            {
                "PLACE",
                x.ToString(),
                y.ToString(),
                Direction.West.ToString()
            };

            var place = CommandFactory.Create(command);
            place.Execute(_tableTop);

            Assert.Equal(x, _tableTop.ToyRobot.Position?.X);
            Assert.Equal(y, _tableTop.ToyRobot.Position?.Y);
        }
    }
}

