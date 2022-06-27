namespace ToyRobotSimulator.Tests.RobotCommands
{
    public class ExampleTests
    {
        private readonly TableTop _tableTop = new();

        /// <summary>
        /// Executes Example 1 Test Case
        /// > PLACE 0,0,NORTH
        /// > MOVE
        /// > REPORT
        /// Output: 0,1,NORTH
        /// </summary>
        [Fact]
        public void Example1_Place_00North_Returns01North()
        {
            CommandHelper.CreateAndExecutePlaceCommand(
                _tableTop,
                0,
                0,
                Direction.North);
            CommandHelper.CreateAndExecuteMoveCommand(_tableTop);

            Assert.Equal(0, _tableTop.ToyRobot?.Position?.X);
            Assert.Equal(1, _tableTop.ToyRobot?.Position?.Y);
            Assert.Equal(Direction.North, _tableTop.ToyRobot?.Direction);

            CommandHelper.CreateAndExecuteReportCommand(_tableTop);
        }


        /// <summary>
        /// Executes Example 2 Test Case
        /// > PLACE 0,0,NORTH
        /// > LEFT
        /// > REPORT
        /// Output: 0,0,WEST
        /// </summary>
        [Fact]
        public void Example2_Place_00North_Left_Returns00West()
        {
            CommandHelper.CreateAndExecutePlaceCommand(
                _tableTop,
                0,
                0,
                Direction.North);
            CommandHelper.CreateAndExecuteLeftCommand(_tableTop);

            Assert.Equal(0, _tableTop.ToyRobot?.Position?.X);
            Assert.Equal(0, _tableTop.ToyRobot?.Position?.Y);
            Assert.Equal(Direction.West, _tableTop.ToyRobot?.Direction);

            CommandHelper.CreateAndExecuteReportCommand(_tableTop);
        }


        /// <summary>
        /// Executes Example 3 Test Case
        /// > PLACE 1,2,EAST
        /// > MOVE
        /// > MOVE
        /// > LEFT
        /// > MOVE
        /// > REPORT
        /// Output: 3,3,NORTH
        /// </summary>
        [Fact]
        public void Example3_Place_12East_Move_Returns33North()
        {
            CommandHelper.CreateAndExecutePlaceCommand(
                _tableTop,
                1,
                2,
                Direction.East);
            CommandHelper.CreateAndExecuteMoveCommand(_tableTop);
            CommandHelper.CreateAndExecuteMoveCommand(_tableTop);
            CommandHelper.CreateAndExecuteLeftCommand(_tableTop);
            CommandHelper.CreateAndExecuteMoveCommand(_tableTop);

            Assert.Equal(3, _tableTop.ToyRobot?.Position?.X);
            Assert.Equal(3, _tableTop.ToyRobot?.Position?.Y);
            Assert.Equal(Direction.North, _tableTop.ToyRobot?.Direction);

            CommandHelper.CreateAndExecuteReportCommand(_tableTop);
        }


        /// <summary>
        /// Executes Example 4 Test Case
        /// > PLACE 1,2,EAST
        /// > MOVE
        /// > LEFT
        /// > MOVE
        /// > PLACE 3,1
        /// > MOVE
        /// > REPORT
        /// Output: 3,2,NORTH
        /// </summary>
        [Fact]
        public void Example4_Place_12East_Move_Returns32North()
        {
            CommandHelper.CreateAndExecutePlaceCommand(
                _tableTop,
                1,
                2,
                Direction.East);
            CommandHelper.CreateAndExecuteMoveCommand(_tableTop);
            CommandHelper.CreateAndExecuteLeftCommand(_tableTop);
            CommandHelper.CreateAndExecuteMoveCommand(_tableTop);
            CommandHelper.CreateAndExecutePlaceCommand(_tableTop, 3, 1);
            Console.WriteLine(_tableTop.ToyRobot?.Direction);
            CommandHelper.CreateAndExecuteMoveCommand(_tableTop);

            Assert.Equal(3, _tableTop.ToyRobot?.Position?.X);
            Assert.Equal(2, _tableTop.ToyRobot?.Position?.Y);
            Assert.Equal(Direction.North, _tableTop.ToyRobot?.Direction);

            CommandHelper.CreateAndExecuteReportCommand(_tableTop);
        }
    }
}

