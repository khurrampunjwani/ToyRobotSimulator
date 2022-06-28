// See https://aka.ms/new-console-template for more information

using System.Reflection;
using ToyRobotSimulator.Core;
using ToyRobotSimulator.Core.RobotCommands;

var defaultConsoleForegroundColor = Console.ForegroundColor;

var appVersion = Assembly.GetEntryAssembly()?.GetName().Version;

var WELCOME_MESSAGE =
@$"
Toy Robot Simulator ({appVersion})

Simulate executing commands on a Toy Robot on a 6 x 6 Table Top.

Commands:

    place x,y,direction     Place the robot on X Y with direction North, East, South or West.
    move                    Move the robot one unit forward.
    left                    Rotate the robot 90 degrees clockwise.
    right                   Rotate the robot 90 degrees anti-clockwise.
    report                  Print X, Y and direction of the toy robot.
    quit                    Quit the application.
";

Console.WriteLine(WELCOME_MESSAGE);

var tableTop = new TableTop();

do
{
    try
    {
        Console.ForegroundColor = defaultConsoleForegroundColor;

        var input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input)) continue;

        if (input.Equals("quit", StringComparison.OrdinalIgnoreCase)) break;

        var command = CommandFactory.Create(input.Split(' '));
        command.Execute(tableTop);

    }
    catch (Exception exception)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Error.WriteLine(exception.Message);
    }

}
while (true);