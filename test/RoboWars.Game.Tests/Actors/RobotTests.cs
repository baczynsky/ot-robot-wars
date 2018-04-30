using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using RoboWars.Game.Actors;
using RoboWars.Game.Enums;

namespace RoboWars.Game.Tests.Actors
{
    [TestFixture]
    public class RobotTests
    {
        private Robot _robot;
        private Mock<IArena> _arena;

        [SetUp]
        public void BeforeEach()
        {
            _arena = new Mock<IArena>();
            _arena.SetupGet(x => x.Latitude).Returns(100);
            _arena.SetupGet(x => x.Longitude).Returns(100);

            _robot = new Robot(_arena.Object);
        }

        [Test]
        public void Given_x_should_set_latitude()
        {
            _robot.Locate(20, 0, Direction.North);

            _robot.Latitude.Should().Be(20);
        }

        [Test]
        public void Given_y_should_set_longitude()
        {
            _robot.Locate(0, 15, Direction.North);

            _robot.Longitude.Should().Be(15);
        }

        [Test]
        public void Given_exceeded_x_should_throw_argument_exception()
        {
            Assert.Throws<ArgumentException>(
                () => { _robot.Locate(1000, 0, Direction.North); }
            );
        }

        [Test]
        public void Given_exceeded_y_should_throw_argument_exception()
        {
            Assert.Throws<ArgumentException>(
                () => { _robot.Locate(0, 1000, Direction.North); }
            );
        }

        [Test]
        public void Given_west_direction_should_be_facing_north()
        {
            _robot.Locate(0, 15, Direction.West);

            _robot.Direction.Should().Be(Direction.West);
        }

        [Test]
        public void Given_north_direction_and_left_rotation_should_be_facing_west()
        {
            _robot.Locate(0, 15, Direction.North);

            _robot.RotateLeft();

            _robot.Direction.Should().Be(Direction.West);
        }

        [Test]
        public void Given_east_direction_and_left_rotation_should_be_facing_north()
        {
            _robot.Locate(0, 15, Direction.East);

            _robot.RotateLeft();

            _robot.Direction.Should().Be(Direction.North);
        }

        [Test]
        public void Given_south_direction_and_left_rotation_should_be_facing_east()
        {
            _robot.Locate(0, 15, Direction.South);

            _robot.RotateLeft();

            _robot.Direction.Should().Be(Direction.East);
        }

        [Test]
        public void Given_west_direction_and_left_rotation_should_be_facing_south()
        {
            _robot.Locate(0, 15, Direction.West);

            _robot.RotateLeft();

            _robot.Direction.Should().Be(Direction.South);
        }

        [Test]
        public void Given_north_direction_and_right_rotation_should_be_facing_east()
        {
            _robot.Locate(0, 15, Direction.North);

            _robot.RotateRight();

            _robot.Direction.Should().Be(Direction.East);
        }

        [Test]
        public void Given_east_direction_and_right_rotation_should_be_facing_south()
        {
            _robot.Locate(0, 15, Direction.East);

            _robot.RotateRight();

            _robot.Direction.Should().Be(Direction.South);
        }

        [Test]
        public void Given_south_direction_and_right_rotation_should_be_facing_west()
        {
            _robot.Locate(0, 15, Direction.South);

            _robot.RotateRight();

            _robot.Direction.Should().Be(Direction.West);
        }

        [Test]
        public void Given_west_direction_and_right_rotation_should_be_facing_north()
        {
            _robot.Locate(0, 15, Direction.West);

            _robot.RotateRight();

            _robot.Direction.Should().Be(Direction.North);
        }

        [Test]
        public void Given_north_direction_and_moved_should_increase_longitude()
        {
            _robot.Locate(0, 10, Direction.North);

            _robot.Move();

            _robot.Longitude.Should().Be(11);
        }

        [Test]
        public void Given_south_direction_and_moved_should_decrease_longitude()
        {
            _robot.Locate(0, 10, Direction.South);

            _robot.Move();

            _robot.Longitude.Should().Be(9);
        }

        [Test]
        public void Given_east_direction_and_moved_should_increase_latitude()
        {
            _robot.Locate(10, 0, Direction.East);

            _robot.Move();

            _robot.Latitude.Should().Be(11);
        }

        [Test]
        public void Given_west_direction_and_moved_should_decrease_latitude()
        {
            _robot.Locate(10, 0, Direction.West);

            _robot.Move();

            _robot.Latitude.Should().Be(9);
        }

        [Test]
        public void Given_north_direction_on_edge_and_moved_should_not_increase_longitude()
        {
            _robot.Locate(0, 100, Direction.North);

            _robot.Move();

            _robot.Longitude.Should().Be(100);
        }

        [Test]
        public void Given_south_direction_on_edge_and_moved_should_not_decrease_longitude()
        {
            _robot.Locate(0, 0, Direction.South);

            _robot.Move();

            _robot.Longitude.Should().Be(0);
        }

        [Test]
        public void Given_east_direction_on_edge_and_moved_should_not_increase_latitude()
        {
            _robot.Locate(100, 0, Direction.East);

            _robot.Move();

            _robot.Latitude.Should().Be(100);
        }

        [Test]
        public void Given_west_direction_on_edge_and_moved_should_not_decrease_latitude()
        {
            _robot.Locate(0, 0, Direction.West);

            _robot.Move();

            _robot.Latitude.Should().Be(0);
        }
    }
}