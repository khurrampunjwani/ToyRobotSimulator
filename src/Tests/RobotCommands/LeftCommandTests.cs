namespace ToyRobotSimulator.Tests
{
    public class LeftCommandTests
    {
        private readonly TableTop _tableTop = new();


        [Fact]
        public void Turn_LeftWithoutPlacing_ThrowsInvalidOperationException()
        {
            var leftExecution = () => CommandHelper.CreateAndExecuteLeftCommand(_tableTop);

            Assert.Throws<InvalidOperationException>(leftExecution);
        }


        [Fact]
        public void Turn_LeftWhiteFacingNorth_TurnsWest()
        {
            CommandHelper.CreateAndExecutePlaceCommand(
                _tableTop,
                1,
                3,
                Direction.North);
            CommandHelper.CreateAndExecuteLeftCommand(_tableTop);

            Assert.Equal(Direction.West, _tableTop.ToyRobot.Direction);
        }


        [Fact]
        public void Turn_LeftWhiteFacingWest_TurnsSouth()
        {
            CommandHelper.CreateAndExecutePlaceCommand(
                _tableTop,
                1,
                3,
                Direction.West);
            CommandHelper.CreateAndExecuteLeftCommand(_tableTop);


            Assert.Equal(Direction.South, _tableTop.ToyRobot.Direction);
        }


        [Fact]
        public void Turn_LeftWhiteFacingSouth_TurnsEast()
        {
            CommandHelper.CreateAndExecutePlaceCommand(
                _tableTop,
                1,
                3,
                Direction.South);
            CommandHelper.CreateAndExecuteLeftCommand(_tableTop);

            Assert.Equal(Direction.East, _tableTop.ToyRobot.Direction);
        }


        [Fact]
        public void Turn_LeftWhiteFacingEast_TurnsNorth()
        {
            CommandHelper.CreateAndExecutePlaceCommand(
                _tableTop,
                1,
                3,
                Direction.East);
            CommandHelper.CreateAndExecuteLeftCommand(_tableTop);

            Assert.Equal(Direction.North, _tableTop.ToyRobot.Direction);
        }
    }
}

