using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using RoboWars.Game.Actors;
using RoboWars.Game.Commands;

namespace RoboWars.Game.Tests.Commands
{
    [TestFixture]
    public class MoveCommandTests
    {
        private MoveCommand _moveCommand;
        private IEnumerable<char> _moves;
        private Mock<IRobot> _robot;

        [SetUp]
        public void BeforeEach()
        {
            _moves = new List<char>();
            _robot = new Mock<IRobot>();
        }

        [Test]
        public void Given_arena_when_execute_should_throw_invalid_operation_exception()
        {
            _moveCommand = new MoveCommand(_moves);
            Assert.Throws<InvalidOperationException>(
                () => { _moveCommand.ExecuteOn(new Arena()); }
            );
        }

        [Test]
        public void Given_r_command_should_rotate_right()
        {
            _moves = new List<char> { 'R' };
            var rotated = false;
            _robot.Setup(x => x.RotateRight()).Callback(() => { rotated = true; });
            _moveCommand = new MoveCommand(_moves);

            _moveCommand.ExecuteOn(_robot.Object);

            rotated.Should().BeTrue();
        }

        [Test]
        public void Given_l_command_should_rotate_left()
        {
            _moves = new List<char> { 'L' };
            var rotated = false;
            _robot.Setup(x => x.RotateLeft()).Callback(() => { rotated = true; });
            _moveCommand = new MoveCommand(_moves);

            _moveCommand.ExecuteOn(_robot.Object);

            rotated.Should().BeTrue();
        }

        [Test]
        public void Given_m_command_should_move()
        {
            _moves = new List<char> { 'M' };
            var moved = false;
            _robot.Setup(x => x.Move()).Callback(() => { moved = true; });
            _moveCommand = new MoveCommand(_moves);

            _moveCommand.ExecuteOn(_robot.Object);

            moved.Should().BeTrue();
        }
    }
}