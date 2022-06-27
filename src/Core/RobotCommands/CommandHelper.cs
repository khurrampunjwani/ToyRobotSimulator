using System;
namespace ToyRobotSimulator.Core.RobotCommands
{
    public static class CommandHelper
    {
        private const string PLACE_COMMAND = "PLACE";
        private const string REPORT_COMMAND = "REPORT";
        private const string MOVE_COMMAND = "MOVE";
        private const string LEFT_COMMAND = "LEFT";
        private const string RIGHT_COMMAND = "RIGHT";

        public static ICommand CreatePlaceCommand(int x, int y, Direction? direction = null) =>
            CommandFactory.Create(
                PLACE_COMMAND,
                x.ToString(),
                y.ToString(),
                $"{direction}");


        public static ICommand CreateReportCommand() => CommandFactory.Create(REPORT_COMMAND);


        public static ICommand CreateMoveCommand() => CommandFactory.Create(MOVE_COMMAND);


        public static ICommand CreateLeftCommand() => CommandFactory.Create(LEFT_COMMAND);


        public static ICommand CreateRightCommand() => CommandFactory.Create(RIGHT_COMMAND);


        public static void CreateAndExecutePlaceCommand(TableTop tableTop, int x, int y, Direction? direction = null) =>
            CommandFactory.Create(
                PLACE_COMMAND,
                x.ToString(),
                y.ToString(),
                $"{direction}")
            .Execute(tableTop);


        public static void CreateAndExecuteReportCommand(TableTop tableTop) => CommandFactory.Create(REPORT_COMMAND).Execute(tableTop);


        public static void CreateAndExecuteMoveCommand(TableTop tableTop) => CommandFactory.Create(MOVE_COMMAND).Execute(tableTop);


        public static void CreateAndExecuteLeftCommand(TableTop tableTop) => CommandFactory.Create(LEFT_COMMAND).Execute(tableTop);


        public static void CreateAndExecuteRightCommand(TableTop tableTop) => CommandFactory.Create(RIGHT_COMMAND).Execute(tableTop);
    }
}

