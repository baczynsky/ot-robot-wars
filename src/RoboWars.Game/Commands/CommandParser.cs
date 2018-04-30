using System;
using System.Collections.Generic;
using RoboWars.Game.Enums;

namespace RoboWars.Game.Commands
{
    public class CommandParser : ICommandParser
    {
        private readonly IDictionary<char, Func<Direction>> _handleDirection;
        public CommandParser()
        {
            _handleDirection = new Dictionary<char, Func<Direction>>
            {
                { 'N', () => Direction.North},
                { 'S', () => Direction.South},
                { 'E', () => Direction.East},
                { 'W', () => Direction.West}
            };
        }
        public ICommand Parse(string cmd)
        {
            if (cmd.IsValidInitialiseCommand())
            {
                var pos = cmd.Split(' ');
                var coords = GetCoords(pos);
                var direction = Direction.North;

                if (pos.Length == 3)
                    direction = _handleDirection[Convert.ToChar(pos[2])]();

                return new InitialiseCommand(coords.Item1, coords.Item2, direction);
            }

            if (cmd.IsValidMoveCommand())
            {
                return new MoveCommand(GetMoves(cmd));
            }
            throw new InvalidOperationException("Invalid command");
        }
        private static Tuple<uint, uint> GetCoords(string[] pos)
        {
            uint.TryParse(pos[0], out var latitude);
            uint.TryParse(pos[1], out var longitude);

            return new Tuple<uint, uint>(latitude, longitude);
        }

        private static IEnumerable<char> GetMoves(string cmd)
        {
            return new List<char>(cmd);
        }
    }
}