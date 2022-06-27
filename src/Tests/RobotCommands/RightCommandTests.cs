using ToyRobotSimulator.Core.RobotCommands;

namespace ToyRobotSimulator.Tests
{
    public class RightCommandTests
    {
        private readonly TableTop _tableTop = new();


        [Fact]
        public void Turn_RightWithoutPlacing_ThrowsInvalidOperationException()
        {
            var right = CommandFactory.Create(new string[] { "RIGHT" });
            var rightExecution = () => right.Execute(_tableTop);

            Assert.Throws<InvalidOperationException>(rightExecution);
        }


        [Fact]
        public void Turn_RightWhiteFacingNorth_TurnsEast()
        {
            var right = Create(1, 3, Direction.North);
            right.Execute(_tableTop);

            Assert.Equal(Direction.East, _tableTop.ToyRobot.Direction);
        }


        [Fact]
        public void Turn_RightWhiteFacingEast_TurnsSouth()
        {
            var right = Create(1, 3, Direction.East);
            right.Execute(_tableTop);

            Assert.Equal(Direction.South, _tableTop.ToyRobot.Direction);
        }


        [Fact]
        public void Turn_RightWhiteFacingSouth_TurnsWest()
        {
            var right = Create(1, 3, Direction.South);
            right.Execute(_tableTop);

            Assert.Equal(Direction.West, _tableTop.ToyRobot.Direction);
        }


        [Fact]
        public void Turn_RightWhiteFacingWest_TurnsNorth()
        {
            var right = Create(1, 3, Direction.West);
            right.Execute(_tableTop);

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

            return CommandFactory.Create(new string[] { "RIGHT" });
        }
    }
}

