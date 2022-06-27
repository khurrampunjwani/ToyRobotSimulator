using ToyRobotSimulator.Core.RobotCommands;

namespace ToyRobotSimulator.Tests
{
    public class LeftCommandTests
    {
        private readonly TableTop _tableTop = new();


        [Fact]
        public void Turn_LeftWithoutPlacing_ThrowsInvalidOperationException()
        {
            var left = CommandFactory.Create(new string[] { "LEFT" });
            var leftExecution = () => left.Execute(_tableTop);

            Assert.Throws<InvalidOperationException>(leftExecution);
        }


        [Fact]
        public void Turn_LeftWhiteFacingNorth_TurnsWest()
        {
            var left = Create(1, 3, Direction.North);
            left.Execute(_tableTop);

            Assert.Equal(Direction.West, _tableTop.ToyRobot.Direction);
        }


        [Fact]
        public void Turn_LeftWhiteFacingWest_TurnsSouth()
        {
            var left = Create(1, 3, Direction.West);
            left.Execute(_tableTop);

            Assert.Equal(Direction.South, _tableTop.ToyRobot.Direction);
        }


        [Fact]
        public void Turn_LeftWhiteFacingSouth_TurnsEast()
        {
            var left = Create(1, 3, Direction.South);
            left.Execute(_tableTop);

            Assert.Equal(Direction.East, _tableTop.ToyRobot.Direction);
        }


        [Fact]
        public void Turn_LeftWhiteFacingEast_TurnsNorth()
        {
            var left = Create(1, 3, Direction.East);
            left.Execute(_tableTop);

            Assert.Equal(Direction.North, _tableTop.ToyRobot.Direction);
        }


        private ICommand Create(int x, int y, Direction direction)
        {
            var command = new string[]
            {
                "PLACE",
                x.ToString(),
                y.ToString(),
                direction.ToString()
            };

            var place = CommandFactory.Create(command);
            place.Execute(_tableTop);

            return CommandFactory.Create(new string[] { "LEFT" });
        }
    }
}

