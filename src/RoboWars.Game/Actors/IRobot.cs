using RoboWars.Game.Enums;

namespace RoboWars.Game.Actors
{
    public interface IRobot
    {
        uint Latitude { get; }
        uint Longitude { get; }
        Direction Direction { get; }

        void Locate(uint x, uint y, Direction direction);
        void RotateRight();
        void RotateLeft();
        void Move();
    }
}