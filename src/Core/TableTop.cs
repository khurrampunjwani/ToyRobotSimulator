namespace ToyRobotSimulator.Core
{
    public class TableTop
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        public ToyRobot ToyRobot { get; private set; } = new ToyRobot();

    }
}

