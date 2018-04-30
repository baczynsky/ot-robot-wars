namespace RoboWars.Game.Commands
{
    public interface ICommandParser
    {   
        ICommand Parse(string cmd);
    }
}