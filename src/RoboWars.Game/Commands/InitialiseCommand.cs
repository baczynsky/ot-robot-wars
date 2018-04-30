using RoboWars.Game.Actors;
using RoboWars.Game.Enums;

namespace RoboWars.Game.Commands
{
    public class InitialiseCommand : ICommand
    {
        public uint Latitude { get; }
        public uint Longitude { get; }
        public Direction Direction { get; }

        public InitialiseCommand(uint x, uint y, Direction direction)
        {
            Latitude = x;
            Longitude = y;
            Direction = direction;
        }

        public void ExecuteOn(IRobot robot)
        {
            robot.Locate(Latitude, Longitude, Direction);
        }

        public void ExecuteOn(IArena arena)
        {
            arena.SetSize(Latitude, Longitude);
        }
    }
}