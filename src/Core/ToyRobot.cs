namespace ToyRobotSimulator.Core
{
    public class ToyRobot
    {
        public Position? Position { get; set; }
        public Direction? Direction { get; set; }

        public bool IsPlaced => Position != null && Direction != null;
    }
}

