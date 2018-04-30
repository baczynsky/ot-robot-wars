using System;
using System.Collections.Generic;
using RoboWars.Game.Enums;

namespace RoboWars.Game.Actors
{
    public class Robot : IRobot
    {
        public uint Latitude { get; private set; }
        public uint Longitude { get; private set; }
        public Direction Direction { get; private set; }

        private readonly IArena _arena;
        private readonly IDictionary<Direction, Action> _handleMovement;

        public Robot(IArena arena)
        {
            _arena = arena
                ?? throw new ArgumentException(nameof(arena));

            _handleMovement = new Dictionary<Direction, Action>
            {
                {Direction.North, () => { if (Longitude < _arena.Longitude) Longitude++; }},
                {Direction.South, () => { if (Longitude > 0) Longitude--; }},
                {Direction.East, () => { if (Latitude < _arena.Latitude) Latitude++; }},
                {Direction.West, () => { if (Latitude > 0) Latitude--; }}
            };
        }

        public void Locate(uint x, uint y, Direction direction)
        {
            if (x > _arena.Latitude || y > _arena.Longitude)
                throw new ArgumentException("Robot's coordinates are out of the arena");

            Latitude = x;
            Longitude = y;
            Direction = direction;
        }

        public void RotateRight() => Direction = (Direction)(((int)Direction + 1) % 4);

        public void RotateLeft() => Direction = (Direction)(((int)Direction + 3) % 4);

        public void Move()
        {
            _handleMovement[Direction]();
        }
    }
}