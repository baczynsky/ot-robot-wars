using System.Collections.Generic;
using RoboWars.Game.Actors;
using RoboWars.Game.Commands;
using StructureMap;

namespace RoboWars.Infrastructure
{
    public class AppRegistry : Registry
    {
        public AppRegistry()
        {
            For<ICommandParser>().Use<CommandParser>();
            For<IArena>().Use<Arena>();
            For<IRobot>().Use<Robot>();
            For<IEnumerable<IRobot>>()
                .Use(ctx => new List<IRobot> { new Robot(ctx.GetInstance<IArena>()), new Robot(ctx.GetInstance<IArena>()) });
        }
    }
}