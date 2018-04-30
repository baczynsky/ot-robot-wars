using System;
using System.Collections.Generic;
using RoboWars.Game.Actors;

namespace RoboWars.Game.Commands
{
    public class MoveCommand : ICommand
    {
        public IEnumerable<char> Moves { get; }
        private readonly IDictionary<char, Action<IRobot>> _handleOperation;

        public MoveCommand(IEnumerable<char> moves)
        {
            Moves = moves
                ?? throw new ArgumentNullException(nameof(IEnumerable<char>));

            _handleOperation = new Dictionary<char, Action<IRobot>>
            {
                {'M', robot => { robot.Move(); } },
                {'L', robot => { robot.RotateLeft(); } },
                {'R', robot => { robot.RotateRight(); } }
            };
        }

        public void ExecuteOn(IRobot robot)
        {
            foreach (var move in Moves)
            {
                _handleOperation[move](robot);
            }
        }

        public void ExecuteOn(IArena arena)
        {
            throw new InvalidOperationException($"Cannot use {nameof(MoveCommand)} on {nameof(IArena)}");
        }
    }
}