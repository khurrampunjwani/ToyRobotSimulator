using ToyRobotSimulator.Core.RobotCommands;

namespace ToyRobotSimulator.Tests
{
    public class PlaceCommandTests
    {
        private readonly TableTop _tableTop = new();

        [Fact]
        public void Create_EmptyXCommand_ThrowsArgumentException()
        {
            var result = () => CommandFactory.Create(
                "PLACE",
                string.Empty,
                "P",
                Direction.North.ToString());

            Assert.Throws<ArgumentException>(result);
        }


        [Fact]
        public void Create_EmptyYCommand_ThrowsArgumentException()
        {
            var result = () => CommandFactory.Create(
                "PLACE",
                "1",
                string.Empty,
                Direction.South.ToString());

            Assert.Throws<ArgumentException>(result);
        }


        [Fact]
        public void Create_EmptyDirectionCommandBeforePlacing_ThrowsInvalidOperationException()
        {
            var place = CommandHelper.CreatePlaceCommand(1, 2);
            var result = () => place.Execute(_tableTop);

            Assert.Throws<InvalidOperationException>(result);
        }


        [Theory]
        [InlineData(-1, 1)]
        [InlineData(-2, 2)]
        [InlineData(2, -3)]
        public void Create_NegativeXY_ReturnsCommand(int x, int y)
        {
            var result = () => CommandHelper.CreateAndExecutePlaceCommand(
                _tableTop,
                x,
                y,
                Direction.East);

            Assert.Throws<ArgumentException>(result);
        }


        [Theory]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        public void Create_ValidXY_ReturnsCommand(int x, int y)
        {
            CommandHelper.CreateAndExecutePlaceCommand(
                _tableTop,
                x,
                y,
                Direction.West);

            Assert.Equal(x, _tableTop.ToyRobot.Position?.X);
            Assert.Equal(y, _tableTop.ToyRobot.Position?.Y);
        }
    }
}

