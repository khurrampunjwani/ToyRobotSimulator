namespace ToyRobotSimulator.Core
{
    public class TableTop
    {
        public int Rows { get; private set; } = 5;
        public int Columns { get; private set; } = 5;

        public ToyRobot ToyRobot { get; private set; } = new ToyRobot();

    }
}

