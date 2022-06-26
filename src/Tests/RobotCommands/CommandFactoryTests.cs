using System;
using ToyRobotSimulator.Core.RobotCommands;

namespace ToyRobotSimulator.Tests
{
    
    public class CommandFactoryTests
    {
        [Fact]
        public void Create_EmptyCommand_ThrowsInvalidOperationException()
        {
            var actual = () => CommandFactory.Create(Array.Empty<string>());

            Assert.Throws<InvalidOperationException>(actual);
        }


        [Fact]
        public void Create_WhitespaceCommand_ThrowsInvalidOperationException()
        {
            var actual = () => CommandFactory.Create(new string[] { "" });

            Assert.Throws<InvalidOperationException>(actual);
        }


        [Fact]
        public void Create_InvalidCommand_ThrowsInvalidOperationException()
        {
            string invalidRandomCommand = DateTime.Now.ToString();
            var actual = () => CommandFactory.Create(new string[] { invalidRandomCommand });

            Assert.Throws<InvalidOperationException>(actual);
        }
    }
}

