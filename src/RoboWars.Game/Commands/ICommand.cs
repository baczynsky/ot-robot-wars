using RoboWars.Game.Actors;

namespace RoboWars.Game.Commands
{
    public interface ICommand
    {   
        void ExecuteOn(IRobot robot);
        void ExecuteOn(IArena arena);
    }
}