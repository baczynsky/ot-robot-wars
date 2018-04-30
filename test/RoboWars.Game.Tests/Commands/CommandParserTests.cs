using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using RoboWars.Game.Commands;
using RoboWars.Game.Enums;

namespace RoboWars.Game.Tests.Commands
{
    [TestFixture]
    public class CommandParserTests
    {
        private CommandParser _commandParser;

        [SetUp]
        public void BeforeEach()
        {
            _commandParser = new CommandParser();
        }

        [Test]
        public void Given_arena_initialise_should_return_initialise_command()
        {
            var result = _commandParser.Parse("5 5");

            result.Should().BeOfType<InitialiseCommand>();
        }

        [Test]
        public void Given_robot_initialise_should_return_initialise_command()
        {
            var result = _commandParser.Parse("1 2 E");

            result.Should().BeOfType<InitialiseCommand>();
        }

        [Test]
        public void Given_coords_should_return_coords()
        {
            var result = _commandParser.Parse("5 4");

            var initialiseCmd = result.Should().BeOfType<InitialiseCommand>().Subject;
            initialiseCmd.Latitude.Should().Be(5);
            initialiseCmd.Longitude.Should().Be(4);
        }

        [Test]
        public void Given_direction_should_return_direction()
        {
            var result = _commandParser.Parse("5 4 E");

            var initialiseCmd = result.Should().BeOfType<InitialiseCommand>().Subject;
            initialiseCmd.Direction.Should().Be(Direction.East);
        }

        [Test]
        public void Given_robot_movement_should_return_move_command()
        {
            var result = _commandParser.Parse("LRM");

            result.Should().BeOfType<MoveCommand>();
        }

        [Test]
        public void Given_moves_should_return_list_of_moves()
        {
            var result = _commandParser.Parse("LRMMRL");

            var moveCmd = result.Should().BeOfType<MoveCommand>().Subject;
            moveCmd.Moves.Should().BeEquivalentTo(new List<char>("LRMMRL"));
        }

        [Test]
        public void Given_invalid_command_should_thrown_invalid_operation_exception()
        {
            Assert.Throws<InvalidOperationException>(
                () => { _commandParser.Parse("INVALID COMMAND"); }
            );
        }
    }
}