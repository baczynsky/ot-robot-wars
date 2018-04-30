using FluentAssertions;
using NUnit.Framework;
using RoboWars.Game.Actors;

namespace RoboWars.Game.Tests.Actors
{
    [TestFixture]
    public class ArenaTests
    {
        private Arena _arena;

        [SetUp]
        public void BeforeEach()
        {
            _arena = new Arena();
        }

        [Test]
        public void Given_x_should_set_latitude()
        {
            _arena.SetSize(10, 0);

            _arena.Latitude.Should().Be(10);
        }

        [Test]
        public void Given_y_should_set_longitude()
        {
            _arena.SetSize(0, 5);

            _arena.Longitude.Should().Be(5);
        }
    }
}