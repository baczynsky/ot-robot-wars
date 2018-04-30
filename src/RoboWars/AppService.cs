using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RoboWars.Game.Actors;
using RoboWars.Game.Commands;

namespace RoboWars
{
    public class AppService
    {
        private readonly ICommandParser _parser;
        private readonly IArena _arena;
        private readonly IEnumerable<IRobot> _robots;

        public AppService(ICommandParser parser, IArena arena, IEnumerable<IRobot> robots)
        {
            _parser = parser
                ?? throw new ArgumentException(nameof(parser));
            _arena = arena
                ?? throw new ArgumentException(nameof(arena));
            _robots = robots
                ?? throw new ArgumentException(nameof(robots));
        }
        public Task StartAsync()
        {
            ICommand command;

            command = _parser.Parse(Console.ReadLine());
            command.ExecuteOn(_arena);

            foreach (var robot in _robots)
            {
                command = _parser.Parse(Console.ReadLine());
                command.ExecuteOn(robot);
                command = _parser.Parse(Console.ReadLine());
                command.ExecuteOn(robot);
            }

            foreach (var robot in _robots)
            {
                Console.WriteLine($"{robot.Latitude} {robot.Longitude} {robot.Direction.ToString()[0]}");
            }

            return Task.CompletedTask;
        }

        public Task StopAsync()
        {
            return Task.CompletedTask;
        }
    }
}