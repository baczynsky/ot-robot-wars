using FluentAssertions;
using Moq;
using NUnit.Framework;
using RoboWars.Game.Actors;
using RoboWars.Game.Commands;
using RoboWars.Game.Enums;

namespace RoboWars.Game.Tests.Commands
{
    [TestFixture]
    public class InitialiseCommandTests
    {
        private InitialiseCommand _initialiseCommand;
        private Mock<IRobot> _robot;
        private Mock<IArena> _arena;

        [SetUp]
        public void BeforeEach()
        {
            _initialiseCommand = new InitialiseCommand(10, 15, Direction.North);
            _robot = new Mock<IRobot>();
            _arena = new Mock<IArena>();
        }

        [Test]
        public void Given_arena_when_execute_should_set_size()
        {
            var set = false;
            _arena.Setup(x => x.SetSize(It.IsAny<uint>(), It.IsAny<uint>())).Callback(() => { set = true; });

            _initialiseCommand.ExecuteOn(_arena.Object);

            set.Should().BeTrue();
        }

        [Test]
        public void Given_robot_when_execute_should_locate_it()
        {
            var located = false;
            _robot.Setup(x => x.Locate(It.IsAny<uint>(), It.IsAny<uint>(), It.IsAny<Direction>())).Callback(() => { located = true; });

            _initialiseCommand.ExecuteOn(_robot.Object);

            located.Should().BeTrue();
        }
    }
}