namespace ToyRobotSimulator.Tests
{
    public class RightCommandTests
    {
        private readonly TableTop _tableTop = new();


        [Fact]
        public void Turn_RightWithoutPlacing_ThrowsInvalidOperationException()
        {
            var result = () => CommandHelper.CreateRightCommand().Execute(_tableTop);

            Assert.Throws<InvalidOperationException>(result);
        }


        [Fact]
        public void Turn_RightWhiteFacingNorth_TurnsEast()
        {
            CommandHelper.CreateAndExecutePlaceCommand(
                _tableTop,
                1,
                3,
                Direction.North);
            CommandHelper.CreateAndExecuteRightCommand(_tableTop);

            Assert.Equal(Direction.East, _tableTop.ToyRobot.Direction);
        }


        [Fact]
        public void Turn_RightWhiteFacingEast_TurnsSouth()
        {
            CommandHelper.CreateAndExecutePlaceCommand(
                _tableTop,
                1,
                3,
                Direction.East);
            CommandHelper.CreateAndExecuteRightCommand(_tableTop);

            Assert.Equal(Direction.South, _tableTop.ToyRobot.Direction);
        }


        [Fact]
        public void Turn_RightWhiteFacingSouth_TurnsWest()
        {
            CommandHelper.CreateAndExecutePlaceCommand(
                _tableTop,
                1,
                3,
                Direction.South);
            CommandHelper.CreateAndExecuteRightCommand(_tableTop);

            Assert.Equal(Direction.West, _tableTop.ToyRobot.Direction);
        }


        [Fact]
        public void Turn_RightWhiteFacingWest_TurnsNorth()
        {
            CommandHelper.CreateAndExecutePlaceCommand(
                _tableTop,
                1,
                3,
                Direction.West);
            CommandHelper.CreateAndExecuteRightCommand(_tableTop);

            Assert.Equal(Direction.North, _tableTop.ToyRobot.Direction);
        }
    }
}

