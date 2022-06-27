namespace ToyRobotSimulator.Core.RobotCommands
{
    public class MoveCommand : ICommand
    {
        public void Execute(TableTop tableTop)
        {
            var toyRobot = tableTop.ToyRobot;

            if (toyRobot is null
                || toyRobot.Position is null
                || toyRobot.Direction is null)
                throw new InvalidOperationException("Robot is null");

            switch (toyRobot.Direction)
            {
                case Direction.North:
                    toyRobot.Position = toyRobot.Position with
                    {
                        Y = toyRobot.Position.Y + 1
                    };
                    break;
                case Direction.South:
                    toyRobot.Position = toyRobot.Position with
                    {
                        Y = toyRobot.Position.Y - 1
                    };
                    break;
                case Direction.West:
                    toyRobot.Position = toyRobot.Position with
                    {
                        X = toyRobot.Position.X - 1
                    };
                    break;
                case Direction.East:
                    toyRobot.Position = toyRobot.Position with
                    {
                        X = toyRobot.Position.X + 1
                    };
                    break;
                default:
                    break;
            }

        }
    }
}

