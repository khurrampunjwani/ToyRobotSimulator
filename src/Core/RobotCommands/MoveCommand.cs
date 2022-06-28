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
                throw new InvalidOperationException("Please place the robot on the table first by using the pace command.");

            switch (toyRobot.Direction)
            {
                case Direction.North:
                    if (toyRobot.Position.Y >= tableTop.Rows)
                        throw new InvalidOperationException("No more space left on the table for the robot to move");

                    toyRobot.Position = toyRobot.Position with
                    {
                        Y = toyRobot.Position.Y + 1
                    };
                    break;
                case Direction.South:
                    if (toyRobot.Position.Y <= 0)
                        throw new InvalidOperationException("No more space left on the table for the robot to move");

                    toyRobot.Position = toyRobot.Position with
                    {
                        Y = toyRobot.Position.Y - 1
                    };
                    break;
                case Direction.West:
                    if (toyRobot.Position.X <= 0)
                        throw new InvalidOperationException("No more space left on the table for the robot to move");

                    toyRobot.Position = toyRobot.Position with
                    {
                        X = toyRobot.Position.X - 1
                    };
                    break;
                case Direction.East:
                    if (toyRobot.Position.X >= tableTop.Columns)
                        throw new InvalidOperationException("No more space left on the table for the robot to move");

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

